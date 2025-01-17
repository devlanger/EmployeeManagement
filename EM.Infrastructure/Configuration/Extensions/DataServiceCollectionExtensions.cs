using EM.Application;
using EM.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EM.Infrastructure.Configuration.Extensions;

public static class DataServiceCollectionExtensions
{
    public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<TxtDataSettings>(configuration.GetSection("TxtDataSettings"));
        services.AddScoped<IDataProvider<Employee>, TxtFileDataProvider>();
    }
}