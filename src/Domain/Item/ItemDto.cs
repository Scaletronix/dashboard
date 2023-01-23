using System.ComponentModel.DataAnnotations;

namespace Domain.Item;

public sealed class ItemDto
{
    [Key]
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal InitialWeight { get; set; }
}