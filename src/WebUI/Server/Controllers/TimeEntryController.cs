using Application.Employee.Queries.GetEmployeeByIdentifier;
using Application.TimeEntry.Commands.StampIn;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Common.Controlling;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class TimeEntryController : ApiControllerBase
{
    public TimeEntryController(IMediator mediator) : base(mediator) { }

    [HttpPost]
    public async Task<ActionResult> StampIn([FromBody] StampInCommand command)
    {
        await Mediator.Send(command);

        return Ok();
    }
}