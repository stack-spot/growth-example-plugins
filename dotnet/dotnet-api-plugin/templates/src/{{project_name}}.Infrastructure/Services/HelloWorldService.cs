using {{project_name}}.Domain.Interfaces.Services;
using {{project_name}}.Domain.Models;

namespace {{project_name}}.Infrastructure.Services
{
    public class HelloWorldService : IHelloWorldService
    {
        public async Task<HelloWorldResponse> Create(string userName, int userLevel)
        {
            await Task.Delay(2000);
            return new HelloWorldResponse
            {
                UserId = Guid.NewGuid(),
                Level = userLevel,
                UserName = userName
            };
        }
    }
}