using Domain.Item;
using MediatR;

namespace Application.Item.Queries.GetItems;

public sealed class GetItemsQuery : IRequest<List<ItemDto>>
{
}