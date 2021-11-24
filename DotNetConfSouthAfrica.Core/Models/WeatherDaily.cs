namespace DotNetConfSouthAfrica.Core.Models;

public class WeatherDaily
{
    public DateTimeOffset Timestamp { get; set; }

    public string? Description { get; set; }

    public string? Icon { get; set; }

    public double TemperatureC { get; set; }

    public double TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public double Humidity { get; set; }

    public double WindSpeed { get; set; }
}
