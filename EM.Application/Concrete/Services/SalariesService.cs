using EM.Core.Models;

namespace EM.Application.Concrete.Services;

public class SalariesService
{
    private readonly string _dataFilePath;

    public SalariesService(string dataFilePath)
    {
        _dataFilePath = dataFilePath;
    }
}