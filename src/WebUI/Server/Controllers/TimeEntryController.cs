using Application.Employee.Queries.GetEmployeeByIdentifier;
using Application.TimeEntry.Commands.StampIn;
using Application.TimeEntry.Commands.StampOut;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Common.Controlling;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class TimeEntryController : ApiControllerBase
{
    public TimeEntryController(IMediator mediator) : base(mediator) { }

    [HttpPost("stamp-in")]
    public async Task<ActionResult> StampIn([FromBody] StampInCommand command)
    {
        await Mediator.Send(command);

        return Ok();
    }

    [HttpPost("stamp-out")]
    public async Task<ActionResult> StampOut([FromBody] StampOutCommand command)
    {
        await Mediator.Send(command);

        return Ok();
    }
}