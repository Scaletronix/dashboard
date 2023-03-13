using Application.Common.Interfaces;
using Domain.Employee;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Employee.Queries.GetEmployeeByIdentifier;

public sealed class GetEmployeeByIdentifierQueryHandler : IRequestHandler<GetEmployeeByIdentifierQuery, EmployeeDto?>
{
    private readonly IApplicationDbContext _dbContext;

    public GetEmployeeByIdentifierQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<EmployeeDto?> Handle(GetEmployeeByIdentifierQuery request, CancellationToken cancellationToken)
    {
        var employee = await _dbContext.Employees
            .Where(e => e.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        return employee;
    }
}