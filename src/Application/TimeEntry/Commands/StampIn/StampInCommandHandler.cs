using Application.Common.Interfaces;
using Domain.TimeEntry;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.TimeEntry.Commands.StampIn;

public sealed class StampInCommandHandler : IRequestHandler<StampInCommand, Unit>
{
    private readonly IApplicationDbContext _dbContext;

    public StampInCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(StampInCommand request, CancellationToken cancellationToken)
    {
        var employee = await _dbContext.Employees
            .Where(e => e.Id == request.Id)
            .FirstOrDefaultAsync();

        var timeEntry = new TimeEntryDto
        {
            Employee = employee,
            StartedAt = DateTime.UtcNow
        };

        await _dbContext.TimeEntries.AddAsync(timeEntry);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}