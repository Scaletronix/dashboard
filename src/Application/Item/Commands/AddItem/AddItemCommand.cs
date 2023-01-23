using MediatR;

namespace Application.Item.Commands.AddItem;

public sealed class AddItemCommand : IRequest<Unit>
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal InitialWeight { get; set; }
}