using EM.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EM.Application.Abstract.Services;

public interface IRepository<T>
{
    IQueryable<T> Query();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    void Update(T entity);
}