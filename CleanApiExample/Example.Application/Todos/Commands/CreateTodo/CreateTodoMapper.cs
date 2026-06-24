namespace Example.Application.Todos.Commands.CreateTodo
{
    public static class CreateTodoMapper
    {
        public static Domain.Entities.Todo ToDomain(this CreateTodoCommand command)
        {
            return new Domain.Entities.Todo
            {
                Title = command.Title,
                Description = command.Description,
                IsCompleted = command.IsCompleted,
                DueDate = command.DueDate
            };
        }
    }
}
