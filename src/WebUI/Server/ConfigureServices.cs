using MediatR;
using System.Reflection;

namespace Server;

public static class ConfigureServices
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllersWithViews();
        services.AddRazorPages();

        services.AddEndpointsApiExplorer();

        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddOpenApiDocument(document =>
        {
            document.Version = configuration.GetValue<string>("Swagger:Version");
            document.Title = configuration.GetValue<string>("Swagger:Title");
            document.Description = configuration.GetValue<string>("Swagger:Description");
        });

        services.AddHttpContextAccessor();
        services.AddMemoryCache();
        services.AddHttpClient();

        return services;
    }
}