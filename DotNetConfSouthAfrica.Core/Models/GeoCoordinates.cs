namespace DotNetConfSouthAfrica.Core.Models;

public class GeoCoordinates
{
    public GeoCoordinates(double latitude, double longitude, string? cityName = null)
    {
        Latitude = latitude;
        Longitude = longitude;
        CityName = cityName;
    }

    public double Latitude { get; }

    public double Longitude { get; }

    public string? CityName { get; }
}
