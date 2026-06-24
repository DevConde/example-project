using Example.Contracts.DTOs;

namespace Example.Application.Mappings
{
    public static class TodoMapping
    {
        public static Domain.Entities.Todo ToDomain(this TodoDto dto)
        {
            return new Domain.Entities.Todo
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                IsCompleted = dto.IsCompleted,
                DueDate = dto.DueDate,
            };
        }

        public static TodoDto ToDto(this Domain.Entities.Todo entity)
        {
            return new TodoDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                IsCompleted = entity.IsCompleted,
                DueDate = entity.DueDate,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
            };
        }
    }
}
