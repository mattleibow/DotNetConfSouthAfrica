namespace DotNetConfSouthAfrica.Core.Services;

public class OfflineGeoLocationService : IGeoLocation
{
    private const double Epsilon = 0.0001;

    private static readonly GeoCoordinates CapeTown = new(-33.92528, 18.42389, "Cape Town");
    private static readonly GeoCoordinates Johannesburg = new(-26.19859, 28.04294, "Johannesburg");
    private static readonly GeoCoordinates Durban = new(-29.84918, 30.98731, "Durban");
    private static readonly GeoCoordinates Mothership = new(47.63709, -122.12374, "Mothership");

    private static readonly Dictionary<string, GeoCoordinates> CityAliases = new()
    {
        // cape town
        ["cape town"] = CapeTown,
        ["kaapstad"] = CapeTown,
        ["ikapa"] = CapeTown,
        ["mother city"] = CapeTown,
        // joburg
        ["johannesburg"] = Johannesburg,
        ["joburg"] = Johannesburg,
        // durban
        ["durban"] = Durban,
        ["durbs"] = Durban,
        // ms
        ["mothership"] = Mothership,
        ["microsoft"] = Mothership,
        ["hq"] = Mothership,
        ["bill"] = Mothership,
        ["microchips"] = Mothership,
    };

    public async Task<GeoCoordinates> GetCurrentLocationAsync(CancellationToken cancellationToken = default)
    {
        await Task.Delay(Random.Shared.Next(1_000, 3_000), cancellationToken);

        return CapeTown;
    }

    public async Task<GeoCoordinates?> GetLocationAsync(string cityName, CancellationToken cancellationToken = default)
    {
        await Task.Delay(Random.Shared.Next(1_000, 3_000), cancellationToken);

        foreach (var city in CityAliases)
        {
            if (city.Key.StartsWith(cityName, StringComparison.OrdinalIgnoreCase))
                return city.Value;
        }

        return null;
    }

    public async Task<GeoCoordinates?> GetCityAsync(double latitude, double longitude, CancellationToken cancellationToken = default)
    {
        await Task.Delay(Random.Shared.Next(1_000, 3_000), cancellationToken);

        foreach (var city in CityAliases)
        {
            if (IsNear(city.Value, latitude, longitude))
                return city.Value;
        }

        return null;
    }

    private static bool IsNear(GeoCoordinates coordinates, double x2, double y2) =>
        IsNear(coordinates.Latitude, coordinates.Longitude, x2, y2);

    private static bool IsNear(double x1, double y1, double x2, double y2) =>
        Math.Abs(x1 - x2) <= Epsilon && Math.Abs(y1 - y2) <= Epsilon;
}
