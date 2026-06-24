using Example.Application.Abstractions;
using Example.Application.Abstractions.Repositories;
using Example.Application.Mappings;
using Example.Application.Specifications;
using Example.Contracts.DTOs;
using MediatR;

namespace Example.Application.Todos.Queries.GetTodo
{
    public class GetTodoQueryHandler(ITodoRepository repository) : IRequestHandler<GetTodoQuery, IEnumerable<TodoDto>>
    {
        private readonly ITodoRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        public async Task<IEnumerable<TodoDto>> Handle(GetTodoQuery request, CancellationToken cancellationToken)
        {
            var todos = await _repository.ListAsync(new TodoFilterSpec(request.Id, request.IsComplete), cancellationToken);
            return todos.Select(todo => todo.ToDto());
        }
    }
}
