using BookingApp.Facade.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookingApp.Repository;

public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
    where TEntity : class
{
    protected readonly BookingAppDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public RepositoryBase(BookingAppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = context.Set<TEntity>();
    }

    public TEntity Get(params object[] id) => _dbSet.Find(id) ?? throw new KeyNotFoundException($"Record with key {id} not found");

    public IQueryable<TEntity> Set(Expression<Func<TEntity, bool>> predicate) => _dbSet.Where(predicate).AsNoTracking();

    public IQueryable<TEntity> Set() => _dbSet;

    public void Insert(TEntity entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        _dbSet.Add(entity);
    }

    public void Update(TEntity entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        _dbSet.Update(entity);
    }

    public void Delete(object id)
    {
        if (id is null) throw new ArgumentNullException(nameof(id));

        Delete(Get(id));
    }

    public void Delete(TEntity entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        _dbSet.Remove(entity);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _context.Set<TEntity>().ToList();
    }
}