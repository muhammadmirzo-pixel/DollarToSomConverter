using DollarToSomConverter.Domain_folder;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;

namespace DollarToSomConverter.Repository_folder.IRepositories;

public interface IRepository<TEntity> where TEntity : Auditable
{
    Task<TEntity> GetByIdAsync(long id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity, long id);
    Task<bool> DeleteAsync(long id);
}