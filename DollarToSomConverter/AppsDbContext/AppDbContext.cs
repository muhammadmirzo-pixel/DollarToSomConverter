using DollarToSomConverter.Domain_folder.Entities;
using DollarToSomConverter.Entities;
using Microsoft.EntityFrameworkCore;

namespace DollarToSomConverter.AppsDbContext;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Conversion> Conversions { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
