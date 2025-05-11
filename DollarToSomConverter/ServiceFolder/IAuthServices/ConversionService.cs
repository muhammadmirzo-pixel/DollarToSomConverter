using DollarToSomConverter.Data.DbContexts;
using DollarToSomConverter.Data.IRepositories;
using DollarToSomConverter.Domain.Entities;
using DollarToSomConverter.ServiceFolder.AuthService;

namespace DollarToSomConverter.ServiceFolder.IAuthServices;
public class ConversionService : IConversionService
{
    private const decimal somConvert = 12850;
    private readonly IRepository<Conversion> conversionRepository;
    private readonly AppDbContext dbContext;

    public ConversionService(IRepository<Conversion> repository, AppDbContext dbContext)
    {
        this.conversionRepository = repository;
        this.dbContext = dbContext;
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
        await dbContext.SaveChangesAsync();

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