namespace DotNetConfSouthAfrica.Core.Models;

public record class GeoCoordinates(
    double Latitude,
    double Longitude,
    string? CityName = null);
