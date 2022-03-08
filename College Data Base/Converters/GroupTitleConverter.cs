namespace College_Data_Base.Converters;

using System;
using System.Globalization;
using System.Windows.Data;

internal class GroupTitleConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => $"Группа: {value}";

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
}