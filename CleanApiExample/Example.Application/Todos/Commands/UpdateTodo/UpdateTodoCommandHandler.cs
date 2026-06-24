using Example.Application.Abstractions;
using Example.Application.Abstractions.Repositories;
using Example.Application.Mappings;
using Example.Application.Specifications;
using Example.Contracts.DTOs;
using MediatR;

namespace Example.Application.Todos.Commands.UpdateTodo
{
    public sealed class UpdateTodoCommandHandler(ITodoRepository repository, IUnitOfWork unitOfWork, TimeProvider timeProvider) : IRequestHandler<UpdateTodoCommand, TodoDto>
    {
        private readonly ITodoRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly TimeProvider _timeProvider = timeProvider;

        public async Task<TodoDto> Handle(UpdateTodoCommand command, CancellationToken cancellationToken)
        {
            var todo = await _repository.FirstOrDefaultAsync(new TodoFilterSpec(command.Todo.Id), cancellationToken);

            if (todo == null)
            {
                throw new InvalidOperationException("Todo not found");
            }

            todo.Title = command.Todo.Title;
            todo.Description = command.Todo.Description;
            todo.IsCompleted = command.Todo.IsCompleted;
            todo.UpdatedAt = _timeProvider.GetUtcNow().UtcDateTime;

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return todo.ToDto();
        }
    }
}
