using Domain.Item;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<ItemDto> Items { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}