//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a StackSpot.
//
//     Changes to this file may cause incorrect behavior.
// </auto-generated>
//------------------------------------------------------------------------------
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace {{project_name}}.Application.Common.StackSpot;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddStackSpot(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        return services;
    }

    public static IApplicationBuilder UseStackSpot(this IApplicationBuilder app, IConfiguration configuration, IWebHostEnvironment environment)
    {
        return app;
    }
}