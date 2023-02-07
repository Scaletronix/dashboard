using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Client;
using WebApi.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.Scan(scan => scan
    .FromAssemblyOf<IEmployeeClient>()
    .AddClasses()
    .AsImplementedInterfaces()
    .WithScopedLifetime());

builder.Services.AddMudServices();

await builder.Build().RunAsync();