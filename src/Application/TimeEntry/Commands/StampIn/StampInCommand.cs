using MediatR;

namespace Application.TimeEntry.Commands.StampIn;

public sealed class StampInCommand : IRequest<Unit>
{
    public string Id { get; set; }

    public DateTime StartedAt { get; set; }
}