﻿namespace Sample.Application.Common.Interfaces;

public interface ICommandRepository<T> where T : class
{
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task DeleteByIdAsync(Guid id);
}
