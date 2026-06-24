using Example.Application.Abstractions;
using Example.Application.Abstractions.Repositories;
using Example.Application.Mappings;
using Example.Application.Specifications;
using Example.Contracts.DTOs;
using MediatR;

namespace Example.Application.Todos.Commands.CompleteTodo
{
    public class CompleteTodoCommandHandler(ITodoRepository todoRepository, IUnitOfWork uow, TimeProvider timeProvider) : IRequestHandler<CompleteTodoCommand, TodoDto>
    {
        private readonly ITodoRepository _repository = todoRepository;
        private readonly IUnitOfWork _unitOfWork = uow;
        private readonly TimeProvider _timeProvider = timeProvider;

        public async Task<TodoDto> Handle(CompleteTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = await _repository.FirstOrDefaultAsync(new TodoFilterSpec(request.Id), cancellationToken);

            if (todo is null)
                throw new InvalidOperationException("Todo not found");

            todo.Complete();
            todo.UpdatedAt = _timeProvider.GetUtcNow().UtcDateTime;

            await _unitOfWork.SaveChangesAsync();
            return todo.ToDto();
        }
    }
}
