using Microsoft.Maui.Essentials;

namespace DotNetConfSouthAfrica.Core.Mobile.Services;

public class DeviceGeoLocationService : IGeoLocation
{
    public async Task<GeoCoordinates> GetCurrentLocationAsync(CancellationToken cancellationToken = default)
    {
        var location = await Geolocation.GetLocationAsync(
            new GeolocationRequest(GeolocationAccuracy.High), cancellationToken);

        return new GeoCoordinates(
            location.Latitude,
            location.Longitude);
    }

    public async Task<GeoCoordinates?> GetCityAsync(double latitude, double longitude, CancellationToken cancellationToken = default)
    {
        var places = await Geocoding.GetPlacemarksAsync(latitude, longitude);

        var place = places?.FirstOrDefault();
        if (place is null)
            return null;

        return new GeoCoordinates(
            place.Location.Latitude,
            place.Location.Longitude,
            $"{place.Locality}, {place.AdminArea}");
    }

    public async Task<GeoCoordinates?> GetLocationAsync(string cityName, CancellationToken cancellationToken = default)
    {
        var locations = await Geocoding.GetLocationsAsync(cityName);

        var location = locations?.FirstOrDefault();
        if (location is null)
            return null;

        return new GeoCoordinates(
            location.Latitude,
            location.Longitude,
            cityName);
    }
}
