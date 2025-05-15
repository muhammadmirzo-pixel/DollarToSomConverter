using DollarToSomConverter.Domain.Entities;
using DollarToSomConverter.IServices.DTOs;
using DollarToSomConverter.Service.Paginations;

namespace DollarToSomConverter.IServices;

public interface IUserService
{
    Task<UserForResultDto> CreateAsync(UserForCreationDto dto);
    Task<User> UpdateAsync(UserForUpdateDto dto, long id);
    Task<bool> DeleteAsync(long id);
    Task<User> GetByIdAsync(long id);
    Task<IEnumerable<UserForResultDto>> GetAllAsync(Pagination pagination);
}
