namespace DotNetConfSouthAfrica.Core.Services;

public static class GeoLocationExtensions
{
    public static Task<GeoCoordinates?> GetCityAsync(this IGeoLocation service, GeoCoordinates coordinates, CancellationToken cancellationToken = default) =>
        service.GetCityAsync(coordinates.Latitude, coordinates.Longitude, cancellationToken);
}
