using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace DotNetConfSouthAfrica.Core.Services;

public class OpenWeatherService : IWeather
{
    private HttpClient httpClient;

    public OpenWeatherService(string apiKey, string units = "metric")
    {
        ApiKey = apiKey;
        Units = units;

        httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/")
        };
    }

    public string ApiKey { get; }

    public string Units { get; }

    public async Task<WeatherResult> GetDailyWeatherAsync(double latitude, double longitude, CancellationToken cancellationToken = default)
    {
        var uri = $"onecall?lat={latitude:0.0}&lon={longitude:0.0}&appid={ApiKey}&units={Units}";

        using var jsonStream = await httpClient.GetStreamAsync(uri, cancellationToken);
        var result = await JsonSerializer.DeserializeAsync<OpenWeatherMapResult>(jsonStream, cancellationToken: cancellationToken);

        if (result is null)
            throw new InvalidOperationException("Either you don't exist, or there is no weather in your location.");

        return new WeatherResult
        {
            Latitude = result.lat,
            Longitude = result.lon,
            Daily = GetDaily(result).ToArray()
        };

        static IEnumerable<WeatherDaily> GetDaily(OpenWeatherMapResult result)
        {
            foreach (var day in result.daily)
            {
                yield return new WeatherDaily
                {
                    Description = day.weather[0].description,
                    Humidity = day.humidity,
                    Icon = day.weather[0].icon,
                    TemperatureC = day.temp.day,
                    Timestamp = DateTimeOffset.FromUnixTimeSeconds(day.dt),
                    WindSpeed = day.wind_speed,
                };
            }
        }
    }
}
