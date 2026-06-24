using Example.Application.Abstractions;
using Example.Application.Abstractions.Repositories;
using Example.Application.Specifications;
using MediatR;

namespace Example.Application.Todos.Commands.DeleteTodo
{
    public class DeleteTodoCommandHandler(ITodoRepository todoRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteTodoCommand>
    {
        private readonly ITodoRepository _repository = todoRepository ?? throw new ArgumentNullException(nameof(todoRepository));
        private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

        public async Task Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = await _repository.FirstOrDefaultAsync(new TodoFilterSpec(request.Id), cancellationToken) ?? throw new InvalidOperationException("Todo not found");
            _repository.Delete(todo);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
