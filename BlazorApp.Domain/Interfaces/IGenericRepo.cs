using System.Linq.Expressions;

namespace BlazorApp.Domain.Interfaces
{
    public interface IGenericRepo<TEntity, TEntityInput, TEntityOutput> where TEntity : class
    {
        Task<int> Add(TEntityInput entity);
        Task<int> Update(TEntity entity);
        Task<int> Delete(long id);
        Task<TEntityOutput> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);
        Task<List<TEntityOutput>> GetAll(bool noTracking = true);
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);
    }
}
