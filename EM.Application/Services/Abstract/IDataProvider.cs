namespace EM.Application.Services.Abstract;

public interface IDataProvider<T>
{
    public Task<IEnumerable<T>> GetAllAsync();
    
    public Task SaveAllAsync(IEnumerable<T> entities);
}
