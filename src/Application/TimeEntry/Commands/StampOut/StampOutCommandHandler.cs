using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.TimeEntry.Commands.StampOut;

public sealed class StampOutCommandHandler : IRequestHandler<StampOutCommand, Unit>
{
    private readonly IApplicationDbContext _dbContext;

    public StampOutCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(StampOutCommand request, CancellationToken cancellationToken)
    {
        var employee = await _dbContext.Employees
            .Where(e => e.Id == request.Id)
            .FirstOrDefaultAsync();

        var latestTimeEntry = await _dbContext.TimeEntries
            .Where(t => t.Employee == employee && t.EndedAt == null)
            .FirstOrDefaultAsync();

        latestTimeEntry.EndedAt = DateTime.UtcNow;

        _dbContext.TimeEntries.Update(latestTimeEntry);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}