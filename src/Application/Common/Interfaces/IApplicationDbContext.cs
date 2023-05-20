using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<EmployeeDto> Employees { get; }

    public DbSet<TimeEntryDto> TimeEntries { get; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}