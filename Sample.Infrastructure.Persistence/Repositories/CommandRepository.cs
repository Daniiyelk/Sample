using Microsoft.EntityFrameworkCore;
using Sample.Application.Common.Interfaces;

namespace Sample.Infrastructure.Persistence.Repositories;

public class CommandRepository<T> : ICommandRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet;

    public CommandRepository(ApplicationDbContext dbContext)
    {
        _dbSet = dbContext.Set<T>();
    }


    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
            Delete(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }
}
