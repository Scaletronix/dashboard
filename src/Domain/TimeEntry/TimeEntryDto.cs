using Domain.Employee;

namespace Domain.TimeEntry;

public sealed class TimeEntryDto
{
    public Guid Id { get; set; }

    public EmployeeDto Employee { get; set; }

    public DateTime? StartedAt { get; set; }

    public DateTime? EndedAt { get; set; }
}