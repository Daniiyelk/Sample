using Sample.Application.Common.Interfaces;

namespace Sample.Application;

public interface IApplicationUnitOfWork : IDisposable, IAsyncDisposable
{
    public Task SaveChangesAsync(CancellationToken cancellationToken = default);


    ICommandRepository<T> CommandRepository<T>() where T : class;
    IQueryRepository<T> QueryRepository<T>() where T : class;
}