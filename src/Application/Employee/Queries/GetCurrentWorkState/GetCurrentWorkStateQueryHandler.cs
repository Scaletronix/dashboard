using Application.Common.Interfaces;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Employee.Queries.GetCurrentWorkState;

public sealed class GetCurrentWorkStateQueryHandler : IRequestHandler<GetCurrentWorkStateQuery, WorkStateEnum>
{
    private readonly IApplicationDbContext _dbContext;

    public GetCurrentWorkStateQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<WorkStateEnum> Handle(GetCurrentWorkStateQuery request, CancellationToken cancellationToken)
    {
        var currentWorkState = await _dbContext.Employees
            .Where(e => e.Id == request.Id)
            .Select(e => e.WorkState)
            .FirstOrDefaultAsync();

        return currentWorkState;
    }
}