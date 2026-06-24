using Example.Application.Abstractions;
using Example.Application.Abstractions.Repositories;
using Example.Application.Mappings;
using Example.Contracts.DTOs;
using MediatR;

namespace Example.Application.Todos.Commands.CreateTodo
{
    public class CreateTodoCommandHandler(ITodoRepository repository, IUnitOfWork uow, TimeProvider timeProvider) : IRequestHandler<CreateTodoCommand, TodoDto>
    {
        private readonly IUnitOfWork _unitOfWork = uow ?? throw new ArgumentNullException(nameof(uow));
        private readonly ITodoRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        private readonly TimeProvider _timeProvider = timeProvider ?? throw new ArgumentNullException(nameof(timeProvider));

        public async Task<TodoDto> Handle(CreateTodoCommand command, CancellationToken cancellationToken)
        {
            var todo = command.ToDomain();
            todo.CreatedAt = _timeProvider.GetUtcNow().UtcDateTime;
            todo.UpdatedAt = null;
            await _repository.AddAsync(todo, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return todo.ToDto();
        }
    }
}
