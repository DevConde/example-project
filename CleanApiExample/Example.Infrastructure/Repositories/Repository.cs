using Example.Application.Abstractions.Repositories;
using Example.Application.Specifications;
using Example.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
namespace Example.Infrastructure.Repositories
{
    public class Repository<T>(AppDbContext db) : IRepository<T> where T : class
    {
        private readonly AppDbContext _db = db;

        public async Task<IList<T>> ListAsync(Specification<T> spec, CancellationToken ct)
        {
            IQueryable<T> query = _db.Set<T>();

            query = ApplySpecification(query, spec);

            return await query.ToListAsync(ct);
        }

        public async Task<T?> FirstOrDefaultAsync(Specification<T> spec, CancellationToken ct)
        {
            IQueryable<T> query = _db.Set<T>();

            query = ApplySpecification(query, spec);

            return await query.FirstOrDefaultAsync(ct);
        }

        private IQueryable<T> ApplySpecification(IQueryable<T> query, Specification<T> spec)
        {
            if (spec.Criteria != null)
                query = query.Where(spec.Criteria);

            query = spec.Includes.Aggregate(
                query,
                (current, include) => current.Include(include));

            if (spec.OrderBy != null)
                query = query.OrderBy(spec.OrderBy);

            if (spec.OrderByDescending != null)
                query = query.OrderByDescending(spec.OrderByDescending);

            if (spec.Skip.HasValue)
                query = query.Skip(spec.Skip.Value);

            if (spec.Take.HasValue)
                query = query.Take(spec.Take.Value);

            return query;
        }

        public async Task AddAsync(T entity, CancellationToken ct)
        {
            await _db.Set<T>().AddAsync(entity, ct);
        }

        public void Update(T entity)
        {
            _db.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
        }
    }
}
