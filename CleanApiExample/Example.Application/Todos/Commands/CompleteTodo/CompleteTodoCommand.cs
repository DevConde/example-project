using Example.Contracts.DTOs;
using MediatR;

namespace Example.Application.Todos.Commands.CompleteTodo
{
    public record CompleteTodoCommand(int Id) : IRequest<TodoDto>
    { }
}
