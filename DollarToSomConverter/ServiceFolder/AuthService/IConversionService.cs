using DollarToSomConverter.Domain.Entities;
namespace DollarToSomConverter.ServiceFolder.AuthService;

public interface IConversionService
{
    Task<Conversion> ConvertAsync(decimal dollarAmount, long userId);
    Task<IEnumerable<Conversion>> GetAllAsync();
    Task<Conversion> GetByIdAsync(long id);
}
