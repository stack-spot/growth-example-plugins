using {{project_name}}.Application.CreateHelloWorld;

namespace {{project_name}}.{{project_type}}.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloWorldController : ControllerBase
{
    private readonly IMediator _mediator;

    public HelloWorldController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateHelloWorldResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Post([FromBody] CreateHelloWorldCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}