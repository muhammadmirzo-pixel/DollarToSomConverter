using DollarToSomConverter.Domain.Commons;

namespace DollarToSomConverter.Data.IRepositories;

public interface IRepository<TEntity> where TEntity : Auditable
{
    Task<TEntity> GetByIdAsync(long id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity, long id);
    Task<bool> DeleteAsync(long id);
}