using {{project_name}}.Application.Common.Mappings;

namespace {{project_name}}.Application.CreateHelloWorld;

public class CreateHelloWorldResult : IMapFrom<HelloWorldResponse>
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = default!;
    public UserLevel Level { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<HelloWorldResponse, CreateHelloWorldResult>()
            .ForMember(d => d.Level, opt => opt.MapFrom(s => (UserLevel)s.Level))
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.UserId));
    }
}