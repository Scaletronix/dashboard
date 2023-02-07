using Domain.Employee;
using MediatR;

namespace Application.Employee.Queries.GetEmployeeByIdentifier;

public sealed class GetEmployeeByIdentifierQuery : IRequest<EmployeeDto?>
{
    public string Identifier { get; set; }
}