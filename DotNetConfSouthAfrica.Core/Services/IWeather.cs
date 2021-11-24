namespace DotNetConfSouthAfrica.Core.Services;

public interface IWeather
{
    Task<WeatherResult> GetDailyWeatherAsync(double latitude, double longitude, CancellationToken cancellationToken = default);
}
