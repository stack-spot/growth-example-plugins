namespace {{project_name}}.Application.UnitTests.CreateHelloWorld;

public class CreateHelloWorldValidatorTests
{
    private readonly CreateHelloWorldValidator _validator;

    public CreateHelloWorldValidatorTests()
    {
        _validator = new CreateHelloWorldValidator();
    }

    [Fact]
    public void Should_UserNameIsEmpty()
    {
        //arrange
        var command = new CreateHelloWorldCommand
        {
            Level = UserLevel.Admin
        };

        //act
        var result = _validator.Validate(command);
        //assert
        Assert.False(result.IsValid);
    }

    [Fact]
    public void Should_IsValid()
    {
        //arrange
        var command = new CreateHelloWorldCommand
        {
            UserName = "Test",
            Level = UserLevel.Admin
        };

        //act
        var result = _validator.Validate(command);
        //assert
        Assert.True(result.IsValid);
    }
}