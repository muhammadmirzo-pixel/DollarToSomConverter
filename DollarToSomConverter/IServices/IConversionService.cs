using DollarToSomConverter.Domain.Entities;
namespace DollarToSomConverter.IServices;

public interface IConversionService
{
    Task<Conversion> ConvertAsync(decimal dollarAmount, long userId);
    Task<IEnumerable<Conversion>> GetAllAsync();
    Task<Conversion> GetByIdAsync(long id);
}
