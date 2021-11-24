namespace DotNetConfSouthAfrica.Core.Services;

public static class WeatherExtensions
{
    public static Task<WeatherResult> GetDailyWeatherAsync(this IWeather service, GeoCoordinates coordinates, CancellationToken cancellationToken = default) =>
        service.GetDailyWeatherAsync(coordinates.Latitude, coordinates.Longitude, cancellationToken);
}
