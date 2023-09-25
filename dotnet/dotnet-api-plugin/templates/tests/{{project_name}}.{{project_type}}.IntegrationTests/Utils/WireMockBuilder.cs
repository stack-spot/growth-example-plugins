using WireMock.Server;

namespace {{project_name}}.{{project_type}}.IntegrationTests.Utils;

public class WireMockBuilder
{
    protected WireMockBuilder()
    {

    }

    private static volatile WireMockServer? _server;
    private static object _syncRoot = new Object();

    public static WireMockServer Build(int port = 5006)
    {
        if (_server is null)
        {
            lock (_syncRoot)
            {
                if (_server is null)
                    _server = WireMockServer.Start(port);
            }
        }
        return _server;
    }
}