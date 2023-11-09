using System.Linq.Expressions;

namespace BookingApp.Facade.Repositories;

public interface IRepositoryBase<TEntity>
{
    TEntity Get(params object[] id);
    IQueryable<TEntity> Set(Expression<Func<TEntity, bool>> predicate);
    IQueryable<TEntity> Set();
    void Insert(TEntity entity);
    void Update(TEntity entity);
    void Delete(object id);
    void Delete(TEntity entity);
}