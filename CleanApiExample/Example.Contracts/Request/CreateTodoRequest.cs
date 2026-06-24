using Example.Contracts.Base.Create;
using Example.Contracts.DTOs;

namespace Example.Contracts.Request
{
    public record CreateTodoRequest : CreateRequestBase<TodoDto>
    { }
}
