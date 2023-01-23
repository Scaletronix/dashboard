using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public sealed class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}