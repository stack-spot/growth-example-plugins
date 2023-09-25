namespace {{project_name}}.{{project_type}}.IntegrationTests.Controllers;

public class HelloWorldControllerTests
{
    private readonly TestFixture _testFixture;

    public HelloWorldControllerTests()
    {
        _testFixture = new TestFixture();
    }

    [Fact]
    public async Task Should_Hello_World_Create_Return_Success()
    {
        var command = new CreateHelloWorldCommand
        {
            UserName = "test",
            Level = UserLevel.Admin
        };

        var content = new HttpRequestMessage(HttpMethod.Post, $"HelloWorld")
        {
            Content = new StringContent(JsonSerializer.Serialize(command), Encoding.UTF8, "application/json")
        };

        var response = await _testFixture.CreateClient().SendAsync(content);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Should_Hello_World_Create_Return_Bad_Request()
    {
        var command = new CreateHelloWorldCommand
        {
            Level = UserLevel.Admin
        };

        var content = new HttpRequestMessage(HttpMethod.Post, $"HelloWorld")
        {
            Content = new StringContent(JsonSerializer.Serialize(command), Encoding.UTF8, "application/json")
        };

        var response = await _testFixture.CreateClient().SendAsync(content);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}