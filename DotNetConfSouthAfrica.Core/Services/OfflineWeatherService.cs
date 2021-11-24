using System.Linq;

namespace DotNetConfSouthAfrica.Core.Services;

public class OfflineWeatherService : IWeather
{
    private static readonly string[] Descriptions =
    {
        "Freezing", "Bracing", "Chilly",
        "Cool", "Mild", "Warm", "Balmy",
        "Hot", "Sweltering", "Scorching"
    };

    public async Task<WeatherResult> GetDailyWeatherAsync(double latitude, double longitude, CancellationToken cancellationToken = default)
    {
        await Task.Delay(Random.Shared.Next(1_000, 3_000), cancellationToken);

        var weather = new WeatherResult
        {
            Latitude = latitude,
            Longitude = longitude,
            Daily = GenerateDailyWeather().ToArray(),
        };

        return weather;
    }

    private static IEnumerable<WeatherDaily> GenerateDailyWeather()
    {
        foreach (var index in Enumerable.Range(0, 7))
        {
            yield return new WeatherDaily
            {
                Timestamp = DateTime.UtcNow.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Description = Descriptions[Random.Shared.Next(Descriptions.Length)],
                Humidity = Random.Shared.Next(0, 100),
                WindSpeed = Random.Shared.Next(0, 100),
            };
        }
    }
}
