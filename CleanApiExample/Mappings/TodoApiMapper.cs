using Example.Contracts.Base.Get;
using Example.Contracts.DTOs;
using Example.Contracts.Response;

namespace Example.Web.Mappings
{
    public static class TodoApiMapper
    {
        public static GetSingleResponseBase<TodoDto> ToSingleResponse(this TodoDto dto)
        {
            return new CreateTodoResponse
            {
                Item = dto
            };
        }
    }
}
