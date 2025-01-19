using EM.Application.Services.Abstract;
using EM.Core.Models;
using EM.Infrastructure.Data;

namespace EM.Infrastructure.DataProviders;

public class SqlDataProvider : IDataProvider<ApplicationUser>
{
    private readonly ApplicationDbContext _dbContext;

    public SqlDataProvider(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task<IEnumerable<ApplicationUser>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<ApplicationUser>>(_dbContext.Users);
    }

    public async Task SaveAllAsync(IEnumerable<ApplicationUser> entities)
    {
        _dbContext.Users.UpdateRange(entities);
        await _dbContext.SaveChangesAsync();
    }
}