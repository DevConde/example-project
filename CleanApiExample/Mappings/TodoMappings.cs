using Example.Application.Todos.Commands.CreateTodo;
using Example.Application.Todos.Commands.UpdateTodo;
using Example.Contracts.Request;

namespace Example.Web.Mappings
{
    public static class TodoMappings
    {
        public static CreateTodoCommand ToCommand(this CreateTodoRequest request)
        {
            return new CreateTodoCommand
            {
                Title = request.Item.Title,
                Description = request.Item.Description,
                IsCompleted = request.Item.IsCompleted,
                DueDate = request.Item.DueDate
            };
        }

        public static UpdateTodoCommand ToCommand(this UpdateTodoRequest request) => new UpdateTodoCommand(request.Item);
    }
}
