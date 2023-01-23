using Microsoft.AspNetCore.Components;
using WebApi.Client;

namespace Scaletronix.Client.Pages;

public partial class Index
{
    [Inject]
    IItemClient ItemApi { get; set; }

    private List<ItemDto> Items { get; set; } = new List<ItemDto>();

    protected override async Task OnInitializedAsync()
    {
        var items = await ItemApi.GetItemsAsync();
        Items = items.ToList();
        StateHasChanged();
    }
}