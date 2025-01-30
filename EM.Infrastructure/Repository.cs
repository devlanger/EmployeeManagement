using EM.Application.Abstract.Services;
using EM.Core.Models;
using EM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EM.Infrastructure;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _dbContext;

    public Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task ExecuteSql(string sql)
    {
        await _dbContext.Database.ExecuteSqlRawAsync(sql);
    }

    public IQueryable<T> Query()
    {
        return _dbContext.Set<T>().AsQueryable();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var result = await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        
        if (result != null) 
            return result;

        return null;
    }

    public async Task AddAsync(T entity)
    {
        await _dbContext.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _dbContext.Update(entity);
    }
}