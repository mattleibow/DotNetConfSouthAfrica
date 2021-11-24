#nullable enable
using System.Diagnostics;

namespace DotNetConfSouthAfrica.Core.Mobile.ViewModels;

public class WeatherViewModel : ObservableObject
{
    private GeoCoordinates? currentLocation;
    private WeatherResult? dailyWeather;
    private GeoCoordinates? weatherLocation;
    private string? searchText;

    public WeatherViewModel(IGeoLocation geolocation, IWeather weather)
    {
        GeoLocationService = geolocation;
        WeatherService = weather;
        SearchCommand = new Command(async () => await SearchAsync());
    }

    public IGeoLocation GeoLocationService { get; }

    public IWeather WeatherService { get; }

    public GeoCoordinates? CurrentLocation
    {
        get => currentLocation;
        set => SetProperty(ref currentLocation, value);
    }

    public WeatherResult? DailyWeather
    {
        get => dailyWeather;
        set => SetProperty(ref dailyWeather, value);
    }

    public GeoCoordinates? WeatherLocation
    {
        get => weatherLocation;
        set => SetProperty(ref weatherLocation, value);
    }

    public Command SearchCommand { get; }

    public string? SearchText
    {
        get => searchText;
        set => SetProperty(ref searchText, value);
    }

    public async Task RefreshDataAsync()
    {
        var currentLocation = await GeoLocationService.GetCurrentLocationAsync();
        var currentAddress = await GeoLocationService.GetCityAsync(currentLocation);
        CurrentLocation = currentAddress ?? new(currentLocation.Latitude, currentLocation.Longitude, "Your Location");

        DailyWeather = await WeatherService.GetDailyWeatherAsync(CurrentLocation);

        var weatherLocation = await GeoLocationService.GetCityAsync(DailyWeather.Latitude, DailyWeather.Longitude);
        WeatherLocation = weatherLocation ?? new(DailyWeather.Latitude, DailyWeather.Longitude, "Unknown");
    }

    public async Task SearchAsync()
    {
        if (string.IsNullOrWhiteSpace(SearchText))
            return;

        var searchLocation = await GeoLocationService.GetLocationAsync(SearchText);

        if (searchLocation is null)
        {
            Debug.WriteLine("No search results.");
            return;
        }

        DailyWeather = await WeatherService.GetDailyWeatherAsync(searchLocation);

        var weatherLocation = await GeoLocationService.GetCityAsync(DailyWeather.Latitude, DailyWeather.Longitude);
        WeatherLocation = weatherLocation ?? new(DailyWeather.Latitude, DailyWeather.Longitude, "Unknown");
    }
}
