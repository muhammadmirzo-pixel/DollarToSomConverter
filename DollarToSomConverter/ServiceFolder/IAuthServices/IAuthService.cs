using DollarToSomConverter.Domain.Entities;

namespace DollarToSomConverter.ServiceFolder.IAuthServices;

public interface IAuthService
{
    Task<User> CreateAsync(User user);
    Task<User> UpdateAsync(User user, long id);
    Task<User> DeleteAsync(long id);
    Task<User> GetByIdAsync(long id);
    Task<IEnumerable<User>> GetAllAsync();
}
