using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Essentials;
using Microsoft.Maui.Hosting;

namespace DotNetConfSouthAfrica.Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .RegisterBlazorMauiWebView()
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.ConfigureEssentials(essentials => essentials
            .UseMapServiceToken(ApiKeys.BingMaps));

        builder.Services.AddBlazorWebView();
        builder.Services.AddTransient<WeatherViewModel, WeatherViewModel>();
        builder.Services.AddTransient<BlazorPage, BlazorPage>();
        builder.Services.AddTransient<XamlPage, XamlPage>();
        builder.Services.AddSingleton<IGeoLocation, DeviceGeoLocationService>();
        builder.Services.AddSingleton<IWeather>(new OpenWeatherService(ApiKeys.OpenWeatherMap));

        return builder.Build();
    }
}
