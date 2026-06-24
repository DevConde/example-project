using Example.Application.Specifications;

namespace Example.Application.Abstractions.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> ListAsync(Specification<T> spec, CancellationToken ct);
        Task<T?> FirstOrDefaultAsync(Specification<T> spec, CancellationToken ct);
        Task AddAsync(T entity, CancellationToken ct);
        void Update(T entity);
        void Delete(T entity);
    }
}
