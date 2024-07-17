using Dapper;
using Sample.Application.Common.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Sample.Infrastructure.Persistence.Repositories;

public class QueryRepository<T> : IQueryRepository<T> where T : class
{
    private readonly IDbConnection _dbConnection;

    public QueryRepository(string connectionString)
    {
        _dbConnection = new SqlConnection(connectionString);
    }

    public async Task<List<T>> GetAllAsync()
    {
        var tableName = typeof(T).Name + "s";
        var query = $"SELECT * FROM {tableName}";

        var result = await _dbConnection.QueryAsync<T>(query);
        return result.AsList();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        var tableName = typeof(T).Name + "s";
        var query = $"SELECT * FROM {tableName} WHERE Id = @Id";

        return await _dbConnection.QuerySingleOrDefaultAsync<T>(query, new { Id = id });
    }
}

