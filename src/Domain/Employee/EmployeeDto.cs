using Domain.Employee.Enums;
using Domain.TimeEntry;
using System.ComponentModel.DataAnnotations;

namespace Domain.Employee;

public sealed class EmployeeDto
{
    [MaxLength(8)]
    public string Id { get; set; }

    public string Name { get; set; }

    public WorkStateEnum WorkState { get; set; } = WorkStateEnum.NotWorking;

    public IEnumerable<TimeEntryDto> TimeEntries { get; set; }
}