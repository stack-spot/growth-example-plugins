namespace {{project_name}}.Domain.UnitTests.Models;

public class HelloWorldResponseTests
{
    [Fact]
    public void Should_Fill_All_Properties()
    {
        //arrange
        var helloWorldResponse = new HelloWorldResponse
        {
            UserName = "test",
            UserId = Guid.NewGuid(),
            Level = (int)UserLevel.Admin
        };

        //act
        //assert
        foreach (var property in helloWorldResponse.GetType().GetProperties())
            Assert.False(property.GetValue(helloWorldResponse) == default, $"{property.DeclaringType}.{property.Name} is default value.");
    }
}