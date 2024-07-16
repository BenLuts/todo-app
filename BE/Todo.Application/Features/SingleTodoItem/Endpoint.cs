using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Common.Response;

namespace Todo.Application.Features.ReadSingleTodoItem;

[ApiController]
[Route("todo")]
public class Endpoint : ControllerBase
{
    private readonly ILogger<Endpoint> _logger;
    private readonly IMediator _mediator;

    public Endpoint(
        ILogger<Endpoint> logger,
        IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> ReadById(Guid id, CancellationToken cancellationToken = default)
    {
        if (id == Guid.Empty)
            return Ok(new Empty<SingleTodoItem>());

        if (id.ToString() == "185d4571-172e-44a8-a5cb-b5334cf73c99")
            throw new Exception("");


        var foundItem = await _mediator.Send(new ReadById(id), cancellationToken);

        return Ok(new Success<SingleTodoItem>(foundItem));
    }

    [HttpGet("assigned/tome")]
    public IActionResult ReadAssignedToMe()
    {
        return Ok(new Success<SingleTodoItem[]>([new() { AssignedTo = [new() { Id = new("3f684fa9-b4c7-4498-88c7-7d86951359d6") }] }]));
    }
}
