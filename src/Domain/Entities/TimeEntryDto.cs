namespace Domain.Entities;

public class TimeEntryDto
{
    public Guid Id { get; set; }

    public virtual EmployeeDto Employee { get; set; }

    public string EmployeeId { get; set; }

    public DateTime? StartedAt { get; set; }

    public DateTime? EndedAt { get; set; }
}