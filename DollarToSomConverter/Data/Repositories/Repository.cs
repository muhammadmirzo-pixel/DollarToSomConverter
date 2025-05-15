using DollarToSomConverter.Data.DbContexts;
using DollarToSomConverter.Data.IRepositories;
using DollarToSomConverter.Domain.Commons;
using Microsoft.EntityFrameworkCore;

namespace DollarToSomConverter.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    protected readonly AppDbContext context;
    private readonly DbSet<TEntity> dbSet;

    public Repository(AppDbContext context, DbSet<TEntity> dbSet)
    {
        this.context = context;
        dbSet = this.context.Set<TEntity>();
    }

    public async Task<TEntity> GetByIdAsync(long id)
    {
        var user = await dbSet.FindAsync(id);
        return user;

    }

    public async Task<IEnumerable<TEntity>> GetAllAsync() =>
        await dbSet.ToListAsync();

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        await dbSet.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

 
    public Task<TEntity> UpdateAsync(TEntity entity, long id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveChangeAsync()
        => await this.context.SaveChangesAsync() > 0;
}

