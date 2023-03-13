using Application.Employee.Commands.CreateEmployee;
using Application.Employee.Queries.GetCurrentWorkState;
using Application.Employee.Queries.GetEmployeeByIdentifier;
using Domain.Employee;
using Domain.Employee.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Common.Controlling;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class EmployeeController : ApiControllerBase
{
    public EmployeeController(IMediator mediator) : base(mediator) { }

    [HttpPost]
    public async Task<ActionResult> CreateEmployee([FromBody] CreateEmployeeCommand command)
    {
        await Mediator.Send(command);

        return Ok();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<EmployeeDto>> GetEmployeeByIdentifier(string id)
    {
        var query = new GetEmployeeByIdentifierQuery { Id = id };

        var result = await Mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("work-state/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<WorkStateEnum>> GetCurrentWorkState(string id)
    {
        var query = new GetCurrentWorkStateQuery { Id = id };

        var result = await Mediator.Send(query);

        return Ok(result);
    }
}