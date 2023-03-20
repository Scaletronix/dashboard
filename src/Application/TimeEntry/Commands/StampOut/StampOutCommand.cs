using MediatR;

namespace Application.TimeEntry.Commands.StampOut;

public sealed class StampOutCommand : IRequest<Unit>
{
    public string Id { get; set; }
}