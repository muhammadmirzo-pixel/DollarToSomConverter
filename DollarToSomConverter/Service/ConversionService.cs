using DollarToSomConverter.Data.DbContexts;
using DollarToSomConverter.Data.IRepositories;
using DollarToSomConverter.Domain.Entities;
using DollarToSomConverter.IServices;

namespace DollarToSomConverter.Service;
public class ConversionService : IConversionService
{
    private dynamic somConvert = 12850m;
    private readonly IRepository<Conversion> conversionRepository;

    public ConversionService(IRepository<Conversion> repository)
    {
        conversionRepository = repository;
    }

    public async Task<Conversion> ConvertAsync(decimal dollarAmount, long userId)
    {
        var somAmount = dollarAmount * somConvert;

        var conversion = new Conversion
        {
            DollarAmount = dollarAmount,
            SomAmount = somAmount,
            UserId = userId,
            CreatedAt = DateTime.UtcNow
        };

        var result = await conversionRepository.CreateAsync(conversion);
        await conversionRepository.SaveChangeAsync();

        return result;
    }

    public async Task<IEnumerable<Conversion>> GetAllAsync()
    {
        return await conversionRepository.GetAllAsync();
    }

    public async Task<Conversion> GetByIdAsync(long id)
    {
        var conversion = await conversionRepository.GetByIdAsync(id);
        return conversion ?? throw new Exception("Conversion not found");
    }
}