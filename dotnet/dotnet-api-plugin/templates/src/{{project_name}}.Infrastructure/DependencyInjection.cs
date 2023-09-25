using {{project_name}}.Domain.Interfaces.Services;
using {{project_name}}.Infrastructure.Services;

namespace {{project_name}}.Infrastructure;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IHelloWorldService, HelloWorldService>();
        return services;
    }
}