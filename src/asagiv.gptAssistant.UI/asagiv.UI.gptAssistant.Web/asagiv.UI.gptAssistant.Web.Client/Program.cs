using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services
    .AddBlazorise(o =>
    {
        o.Immediate = true;
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();

var builder = WebAssemblyHostBuilder.CreateDefault(args);

await builder.Build().RunAsync();
