using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Diagnostics;
using Avalonia.Layout;
using Debug = System.Diagnostics.Debug;

namespace Avalonia.NETCoreApp
{
    public class MessageAlignmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (value.ToString().ToUpper() == "LEFT")
            {
                //TODO: add debug to program to test debug
                return HorizontalAlignment.Left;
            }
            else
            {
                return HorizontalAlignment.Right;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "not implemented";
        }
    }
}