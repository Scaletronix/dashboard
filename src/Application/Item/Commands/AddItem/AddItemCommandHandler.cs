using Application.Common.Interfaces;
using Domain.Item;
using MediatR;

namespace Application.Item.Commands.AddItem;

public sealed class AddItemCommandHandler : IRequestHandler<AddItemCommand, Unit>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public AddItemCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Unit> Handle(AddItemCommand request, CancellationToken cancellationToken)
    {
        var item = new ItemDto
        {
            Title = request.Title,
            Description = request.Description,
            InitialWeight = request.InitialWeight
        };

        await _applicationDbContext.Items.AddAsync(item, cancellationToken);

        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}