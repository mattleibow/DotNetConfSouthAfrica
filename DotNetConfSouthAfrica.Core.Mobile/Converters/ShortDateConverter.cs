using System.Globalization;

namespace DotNetConfSouthAfrica.Core.Mobile.Converters;

public class ShortDateConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is DateTimeOffset dateTime)
            return dateTime.ToLocalTime().ToString("d MMM");
        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
