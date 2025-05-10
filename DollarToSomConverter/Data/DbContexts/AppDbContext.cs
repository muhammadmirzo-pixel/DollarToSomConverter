using Microsoft.EntityFrameworkCore;
using DollarToSomConverter.Domain.Entities;

namespace DollarToSomConverter.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Conversion> Conversions { get; set; }

}
