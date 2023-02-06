using Application.Common.Interfaces;
using Domain.Employee;
using Domain.TimeEntry;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public sealed class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
    { 
        Database.EnsureCreated();
    }

    public DbSet<EmployeeDto> Employees { get; set; }

    public DbSet<TimeEntryDto> TimeEntries { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}