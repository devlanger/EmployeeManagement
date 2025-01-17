using EM.Application.Abstract;
using EM.Application.Concrete.DataProviders;
using EM.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EM.Infrastructure.Configuration.Extensions;

public static class DataServiceCollectionExtensions
{
    public static void ConfigureDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<TxtDataSettings>(configuration.GetSection("TxtDataSettings"));
        services.AddScoped<IDataProvider<Employee>, TxtFileDataProvider>();
    }
}