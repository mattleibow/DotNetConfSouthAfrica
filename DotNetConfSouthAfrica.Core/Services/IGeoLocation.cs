namespace DotNetConfSouthAfrica.Core.Services;

public interface IGeoLocation
{
    Task<GeoCoordinates> GetCurrentLocationAsync(CancellationToken cancellationToken = default);

    Task<GeoCoordinates?> GetLocationAsync(string cityName, CancellationToken cancellationToken = default);

    Task<GeoCoordinates?> GetCityAsync(double latitude, double longitude, CancellationToken cancellationToken = default);
}
