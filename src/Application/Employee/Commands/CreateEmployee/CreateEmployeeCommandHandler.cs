using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Employee.Commands.CreateEmployee;

public sealed class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Unit>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateEmployeeCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = new EmployeeDto
        {
            Id = request.Id,
            Name = request.Name
        };

        await _dbContext.Employees.AddAsync(employee, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}