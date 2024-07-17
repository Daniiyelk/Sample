using Microsoft.Extensions.Configuration;
using Sample.Application.Common.Interfaces;
using Sample.Application;
using Sample.Infrastructure.Persistence.Repositories;

namespace Sample.Infrastructure.Persistence.UnitOfWork;

public class ApplicationUnitOfWork : IApplicationUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration configuration;

    public ApplicationUnitOfWork(ApplicationDbContext context, IConfiguration configuration)
    {
        _context = context;
        this.configuration = configuration;
    }


    public ICommandRepository<T> CommandRepository<T>() where T : class
    {
        return new CommandRepository<T>(_context);
    }

    public IQueryRepository<T> QueryRepository<T>() where T : class
    {
        return new QueryRepository<T>(configuration.GetConnectionString("ApplicationDbContext"));
    }



    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
        GC.SuppressFinalize(this);
    }
}
