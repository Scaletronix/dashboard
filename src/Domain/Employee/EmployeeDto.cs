using Domain.Common.Entities;
using Domain.Employee.Enums;
using Domain.TimeEntry;

namespace Domain.Employee;

public sealed class EmployeeDto : EntityBase
{
    public string Identifier { get; set; }

    public string Name { get; set; }

    public WorkStateEnum WorkState { get; set; } = WorkStateEnum.NotWorking;

    public IEnumerable<TimeEntryDto> TimeEntries { get; set; }
}