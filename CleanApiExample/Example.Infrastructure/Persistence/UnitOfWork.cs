using Example.Application.Abstractions;

namespace Example.Infrastructure.Persistence
{
    public class UnitOfWork(AppDbContext db) : IUnitOfWork
    {
        private readonly AppDbContext _db = db ?? throw new ArgumentNullException(nameof(db));

        public int SaveChanges() => _db.SaveChanges();
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => await _db.SaveChangesAsync(cancellationToken);
    }
}
