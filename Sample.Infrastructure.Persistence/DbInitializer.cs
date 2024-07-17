using Microsoft.EntityFrameworkCore;
using Sample.Application.Common.Interfaces;

namespace Sample.Infrastructure.Persistence;

public class DbInitializer : IDbInitializer
{
    private readonly ApplicationDbContext _context;

    public DbInitializer(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task InitialDb()
    {
        _context.Database.MigrateAsync();
        return Task.CompletedTask;
    }
}
