using Example.Contracts.DTOs;
using MediatR;

namespace Example.Application.Todos.Commands.CreateTodo
{
    public record CreateTodoCommand : IRequest<TodoDto>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
