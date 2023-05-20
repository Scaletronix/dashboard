using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class EmployeeDto
{
    [MaxLength(8)]
    public string Id { get; set; }

    public string Name { get; set; }

    public WorkStateEnum WorkState { get; set; } = WorkStateEnum.NotWorking;

    public virtual ICollection<TimeEntryDto> TimeEntries { get; set; }
}