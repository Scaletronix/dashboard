using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Employee.Queries.GetEmployeeByIdentifier;

public sealed class GetEmployeeByIdentifierQueryHandler : IRequestHandler<GetEmployeeByIdentifierQuery, IEnumerable<TimeEntryDto>?>
{
    private readonly IApplicationDbContext _dbContext;

    public GetEmployeeByIdentifierQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<TimeEntryDto>?> Handle(GetEmployeeByIdentifierQuery request, CancellationToken cancellationToken)
    {
        var fullDataOfEmployee = await _dbContext.TimeEntries
            .Where(e => e.EmployeeId == request.Id).ToListAsync();

        return fullDataOfEmployee;
    }
}