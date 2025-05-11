using DollarToSomConverter.Domain.Entities;
namespace DollarToSomConverter.Service_folder.AuthService;

public interface IConversionService
{
    Task<Conversion> ConvertAsync(decimal dollarAmount, long userId);
    Task<IEnumerable<Conversion>> GetAllAsync();
    Task<Conversion> GetByIdAsync(long id);
}
