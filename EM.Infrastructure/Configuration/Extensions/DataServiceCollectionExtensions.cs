using EM.Application.Abstract.Services;
using EM.Application.Concrete.Services;
using EM.Application.Services.Abstract;
using EM.Core.Models;
using EM.Infrastructure.DataProviders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EM.Infrastructure.Configuration.Extensions;

public static class DataServiceCollectionExtensions
{
    public static void ConfigureDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<TxtDataSettings>(configuration.GetSection("TxtDataSettings"));
        services.AddScoped<IBonusService, BonusService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IDataProvider<Employee>, SqlDataProvider>();
    }

    public static void ConfigureCQRS(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddMediatR();
    }
}