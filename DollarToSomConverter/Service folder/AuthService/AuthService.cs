using DollarToSomConverter.Data.DbContexts;
using DollarToSomConverter.Data.IRepositories;
using DollarToSomConverter.Domain.Entities;
using DollarToSomConverter.Service_folder.IAuthServices;

namespace DollarToSomConverter.Service_folder.AuthService;

public class AuthService : IAuthService
{
    private readonly IRepository<User> userRepository;
    private readonly AppDbContext appDbContext;

    public AuthService(IRepository<User> repository, AppDbContext appDbContext)
    {
        this.userRepository = repository;
        this.appDbContext = appDbContext;
    }

    public async Task<User> CreateAsync(User user)
    {
        var existingUsers = await userRepository.GetAllAsync();
        var existingUser = existingUsers.FirstOrDefault(u => u.Email.ToLower() == user.Email.ToLower());
        if (existingUser != null)
            throw new Exception("This email is already registered.");

        var createdUser = await userRepository.CreateAsync(user);
        user.CreatedAt = DateTime.UtcNow;
        await appDbContext.SaveChangesAsync();
        return createdUser;
    }

    public async Task<User> DeleteAsync(long id)
    {
        var user = await userRepository.GetByIdAsync(id);
        if (user is null)
            throw new Exception("User not found");

        var isDeleted = await userRepository.DeleteAsync(id);
        if (!isDeleted)
            throw new Exception("User could not be deleted");

        await appDbContext.SaveChangesAsync();
        return user;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await userRepository.GetAllAsync();
    }

    public async Task<User> GetByIdAsync(long id)
    {
        var user = await userRepository.GetByIdAsync(id);
        if (user is null)
            throw new Exception("User not found");
        return user; 
    }

    public async Task<User> UpdateAsync(User user, long id)
    {
        var existingUser = await userRepository.GetByIdAsync(id);
        if (existingUser is null)
            throw new Exception("User not found");

        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.Email = user.Email;
        existingUser.PasswordHash = user.PasswordHash;
        existingUser.UpdatedAt = DateTime.UtcNow;

        var updatedUser = await this.userRepository.UpdateAsync(existingUser, id);
        await appDbContext.SaveChangesAsync();
        return updatedUser;
    }
}
