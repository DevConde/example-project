using Example.Contracts.Base.Create;
using Example.Contracts.DTOs;

namespace Example.Contracts.Request
{
    public record UpdateTodoRequest : CreateRequestBase<TodoDto>
    { }
}
