using MediatR;

namespace Example.Application.Todos.Commands.DeleteTodo
{
    public record DeleteTodoCommand(int Id) : IRequest
    { }
}
