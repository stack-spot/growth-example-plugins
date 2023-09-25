namespace {{project_name}}.{{project_type}}.UnitTests.Controllers;

public class HelloWorldControllerTests
{
    [Fact]
    public async Task Should_Post_Hello_World_Command_To_Mediator()
    {
        //arrange
        var mediatorMock = new Mock<IMediator>();
        var createHelloWorldResult = new CreateHelloWorldResult();
        var command = new CreateHelloWorldCommand
        {
            UserName = "test",
            Level = UserLevel.Admin
        };

        //act
        mediatorMock.Setup(x => x.Send(command, CancellationToken.None)).ReturnsAsync(createHelloWorldResult);

        var controller = new HelloWorldController(mediatorMock.Object);
        var result = await controller.Post(command);

        //assert
        mediatorMock.VerifyAll();
        Assert.NotNull(result);
    }
}