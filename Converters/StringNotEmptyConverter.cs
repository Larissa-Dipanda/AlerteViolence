namespace AlerteViolence.Converters;

public class StringNotEmptyConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
    {
        if (value is string stringValue)
            return !string.IsNullOrWhiteSpace(stringValue);
        return false;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}