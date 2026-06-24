using Example.Contracts.DTOs;
using MediatR;

namespace Example.Application.Todos.Queries.GetTodo
{
    public sealed record GetTodoQuery : IRequest<IEnumerable<TodoDto>>
    {
        public bool? IsComplete { get; set; }
        public int? Id { get; set; }
    }
}
