namespace Sample.Application.Common.Interfaces;

public interface IQueryRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
}
