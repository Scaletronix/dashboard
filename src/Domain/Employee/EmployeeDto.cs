using Domain.Common.Entities;
using Domain.TimeEntry;

namespace Domain.Employee;

public sealed class EmployeeDto : EntityBase
{
    public IEnumerable<TimeEntryDto> TimeEntries { get; set; }
}