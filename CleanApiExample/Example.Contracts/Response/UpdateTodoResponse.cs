using Example.Contracts.Base.Get;
using Example.Contracts.DTOs;

namespace Example.Contracts.Response
{
    public record UpdateTodoResponse : GetSingleResponseBase<TodoDto>
    { }
}
