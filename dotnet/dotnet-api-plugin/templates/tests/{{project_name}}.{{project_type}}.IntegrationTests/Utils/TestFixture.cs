using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using WireMock.Server;

namespace {{project_name}}.{{project_type}}.IntegrationTests.Utils;

class TestFixture : WebApplicationFactory<Program>
{
    public WireMockServer? _mockServer;

    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureAppConfiguration((hostingContext, config) =>
        {
            config.AddJsonFile("appsettings.json");
        }).UseEnvironment("Development");

        _mockServer = WireMockBuilder.Build();

        return base.CreateHost(builder);
    }
}