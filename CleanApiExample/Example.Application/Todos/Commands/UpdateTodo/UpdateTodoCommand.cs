using Example.Contracts.DTOs;
using MediatR;

namespace Example.Application.Todos.Commands.UpdateTodo
{
    public record UpdateTodoCommand(TodoDto Todo) : IRequest<TodoDto>
    { }
}
