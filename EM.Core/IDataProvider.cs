namespace EM.Core;

public interface IDataProvider<T>
{
    public Task<IEnumerable<T>> GetAllAsync();
}
