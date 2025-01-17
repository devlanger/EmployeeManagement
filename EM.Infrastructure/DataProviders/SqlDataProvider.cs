using EM.Application.Services.Abstract;
using EM.Core.Models;
using EM.Infrastructure.Data;

namespace EM.Infrastructure.DataProviders;

public class SqlDataProvider : IDataProvider<Employee>
{
    private readonly ApplicationDbContext _dbContext;

    public SqlDataProvider(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task<IEnumerable<Employee>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Employee>>(_dbContext.Employees);
    }

    public async Task SaveAllAsync(IEnumerable<Employee> entities)
    {
        _dbContext.Employees.UpdateRange(entities);
        await _dbContext.SaveChangesAsync();
    }
}