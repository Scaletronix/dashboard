using Application.Common.Interfaces;
using Domain.Entities;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TimeEntryDto>()
            .HasOne(te => te.Employee)
            .WithMany(e => e.TimeEntries)
            .HasForeignKey(te => te.EmployeeId);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}