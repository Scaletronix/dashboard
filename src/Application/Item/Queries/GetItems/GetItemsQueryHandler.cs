using Application.Common.Interfaces;
using Domain.Item;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Item.Queries.GetItems;

public sealed class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, List<ItemDto>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetItemsQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<ItemDto>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Items.ToListAsync(cancellationToken);
    }
}