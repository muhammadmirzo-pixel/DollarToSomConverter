using DollarToSomConverter.Data.DbContexts;
using DollarToSomConverter.Data.IRepositories;
using DollarToSomConverter.Domain.Entities;
using DollarToSomConverter.IServices;
using DollarToSomConverter.IServices.DTOs;
using DollarToSomConverter.Service.Paginations;

namespace DollarToSomConverter.Service;

public class UserService : IUserService
{
    private readonly IRepository<User> repository;


    public UserService(IRepository<User> repository)
    {
        this.repository = repository;
    }

    public async Task<UserForResultDto> CreateAsync(UserForCreationDto dto)
    {
        var existingUsers = await this.repository.GetAllAsync();
        var existingUser = existingUsers.FirstOrDefault(u => u.Email.ToLower() == dto.Email.ToLower());
        if (existingUser != null)
            throw new Exception("This email is already registered.");

        var userEnt = new User
        {
            Email = dto.Email,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PasswordHash = dto.PasswordHash
        };
        var createdUser = await this.repository.CreateAsync(userEnt);
        createdUser.CreatedAt = DateTime.UtcNow;
        await this.repository.SaveChangeAsync();

        return new UserForResultDto
        {
            Email = createdUser.Email,
            FirstName = createdUser.FirstName,
            LastName = createdUser.LastName,
            CreatedAt = createdUser.CreatedAt,
            UpdatedAt = createdUser.UpdatedAt,
        };
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var user = await this.repository.GetByIdAsync(id);
        if (user is null)
            throw new Exception("User not found");

        var isDeleted = await this.repository.DeleteAsync(id);
        if (!isDeleted)
            throw new Exception("User could not be deleted");

        return await this.repository.SaveChangeAsync(); ;
    }


    public async Task<IEnumerable<UserForResultDto>> GetAllAsync(Pagination pagination)
    {
        pagination ??= new Pagination
        {
            PageNumber = 1,
            PageSize = 10
        };

        var userList = (await this.repository.GetAllAsync())
            .OrderBy(u => u.Id)
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToList();

        return userList.Select(user => new UserForResultDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        });
    }


    public async Task<User> GetByIdAsync(long id)
    {
        var user = await this.repository.GetByIdAsync(id);
        if (user is null)
            throw new Exception("User not found");
        return user; 
    }


    public async Task<User> UpdateAsync(UserForUpdateDto dto, long id)
    {
        var existingUser = await this.repository.GetByIdAsync(id);
        if (existingUser is null)
            throw new Exception("User not found");

        existingUser.FirstName = dto.FirstName;
        existingUser.LastName = dto.LastName;
        existingUser.Email = dto.Email;
        existingUser.PasswordHash = dto.PasswordHash;
        existingUser.UpdatedAt = DateTime.UtcNow;

        var updatedUser = await this.repository.UpdateAsync(existingUser, id);
        await this.repository.SaveChangeAsync();
        return updatedUser;
    }
}
