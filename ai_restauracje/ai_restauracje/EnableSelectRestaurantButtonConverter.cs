using System;
using System.Globalization;
using System.Windows.Data;

namespace ai_restauracje
{
    public class EnableSelectRestaurantButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return false;
            int index = (int)value;
            if (index >= 0) return true;
            else return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
