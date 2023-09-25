using {{project_name}}.Domain.Interfaces.Services;

namespace {{project_name}}.Application.CreateHelloWorld;

public class CreateHelloWorldHandler : IRequestHandler<CreateHelloWorldCommand, CreateHelloWorldResult>
{
    private readonly ILogger<CreateHelloWorldHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IHelloWorldService _helloWorldService;


    public CreateHelloWorldHandler(ILogger<CreateHelloWorldHandler> logger,
                                    IMapper mapper,
                                    IHelloWorldService helloWorldService)
    {
        _logger = logger;
        _mapper = mapper;
        _helloWorldService = helloWorldService;
    }

    public async Task<CreateHelloWorldResult> Handle(CreateHelloWorldCommand request, CancellationToken cancellationToken)
    {
        _logger.LogDebug("Init Handle");

        var response = await _helloWorldService.Create(request.UserName, (int)request.Level);
        return _mapper.Map<CreateHelloWorldResult>(response);
    }
}