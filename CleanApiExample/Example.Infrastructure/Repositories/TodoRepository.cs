using Example.Application.Abstractions.Repositories;
using Example.Infrastructure.Persistence;

namespace Example.Infrastructure.Repositories
{
    public sealed class TodoRepository(AppDbContext dbContext) : Repository<Domain.Entities.Todo>(dbContext), ITodoRepository
    { }
}
