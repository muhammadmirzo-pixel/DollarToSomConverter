using DollarToSomConverter.AppsDbContext;
using DollarToSomConverter.Domain_folder;
using DollarToSomConverter.Repository_folder.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DollarToSomConverter.Repository_folder.Repositories;

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

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        dbSet.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(TEntity entity)
    {
        dbSet.Remove(entity);
        return await context.SaveChangesAsync() > 0;
    }

    public Task<TEntity> UpdateAsync(TEntity entity, long id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }
}

