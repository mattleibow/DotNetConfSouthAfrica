using DotNetConfSouthAfrica.Core.Services;
using DotNetConfSouthAfrica.Website;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<IGeoLocation, OfflineGeoLocationService>();
builder.Services.AddSingleton<IWeather, OfflineWeatherService>();

await builder.Build().RunAsync();
