namespace {{project_name}}.Domain.Models;

public class HelloWorldResponse
{
    public Guid UserId { get; set; }
    public string UserName { get; set; } = default!;
    public int Level { get; set; }
}