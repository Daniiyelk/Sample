using Microsoft.EntityFrameworkCore;
using Sample.Domain.Entities;
using System.Reflection;

namespace Sample.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    #region DBSets

    public DbSet<Customer> Customers { get; set; }

    #endregion
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        base.OnModelCreating(modelBuilder);
    }
}
