using Application.Item.Commands.AddItem;
using Application.Item.Queries.GetItems;
using Domain.Item;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Server.Common.Controlling;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class ItemController : ApiControllerBase
{
    public ItemController(IMediator mediator) : base(mediator) { }

    [HttpPost]
    public async Task<ActionResult> AddItem([FromBody] AddItemCommand command)
    {
        await Mediator.Send(command);

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<List<ItemDto>>> GetItems()
    {
        var query = new GetItemsQuery();

        var result = await Mediator.Send(query);

        return Ok(result);
    }
}