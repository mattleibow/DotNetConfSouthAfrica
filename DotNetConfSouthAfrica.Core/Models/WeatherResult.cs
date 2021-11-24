namespace DotNetConfSouthAfrica.Core.Models;

public class WeatherResult
{
    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public IReadOnlyList<WeatherDaily> Daily { get; set; } = new List<WeatherDaily>();
}
