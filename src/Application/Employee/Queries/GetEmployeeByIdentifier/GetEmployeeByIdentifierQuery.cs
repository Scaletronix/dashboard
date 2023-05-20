using Domain.Entities;
using MediatR;

namespace Application.Employee.Queries.GetEmployeeByIdentifier;

public sealed class GetEmployeeByIdentifierQuery : IRequest<IEnumerable<TimeEntryDto>?>
{
    public string Id { get; set; }
}