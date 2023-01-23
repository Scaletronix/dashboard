using Application.Item.Commands.AddItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scaletronix.Server.Common.Controlling;

namespace Scaletronix.Server.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class ItemController : ApiControllerBase
{
    public ItemController(IMediator mediator) : base(mediator) { }

    public async Task<ActionResult> AddItem([FromBody] AddItemCommand command)
    {
        await Mediator.Send(command);

        return Ok();
    }
}