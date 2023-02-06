using Domain.Common.Entities;
using Domain.Employee;

namespace Domain.TimeEntry;

public sealed class TimeEntryDto : EntityBase
{
    public EmployeeDto Employee { get; set; }

    public DateTime StartedAt { get; set; }

    public DateTime EndedAt { get; set; }
}