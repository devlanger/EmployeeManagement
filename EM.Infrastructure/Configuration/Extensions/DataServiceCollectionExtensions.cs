using System.Reflection;
using EM.Application.Abstract.Services;
using EM.Application.Concrete.Services;
using EM.Application.CQRS.User.Queries.SearchUserQuery;
using EM.Application.Mapper;
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
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IBonusService, BonusService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IDataProvider<ApplicationUser>, SqlDataProvider>();
        services.AddAutoMapper(typeof(GlobalMappingProfile));
    }

    public static void ConfigureCQRS(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(SearchUserQuery).GetTypeInfo().Assembly));
    }
}