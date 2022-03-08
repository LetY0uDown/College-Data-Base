namespace College_Data_Base.Converters;

using College_Data_Base.MVVM.Model;
using System;
using System.Globalization;
using System.Windows.Data;

internal class SupervisedGroupTitleConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => $"Куратор у группы: {(value as Group)?.Title}";

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
}