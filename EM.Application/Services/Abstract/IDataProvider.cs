namespace EM.Application.Abstract;

public interface IDataProvider<T>
{
    public Task<IEnumerable<T>> GetAllAsync();
}
