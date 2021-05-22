using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ai_restauracje
{
    class FilterMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var value = values[0];
            if (value == null || (Locations)value == Locations.All)
            {
                return values[1];
            }
            string filter = ((Locations)value).ToString();
            var restaurants = (IEnumerable<Restaurant>)values[1];
            List<Restaurant> filteredRestaurants = new List<Restaurant>();
            foreach (var res in restaurants)
                if (res.Location == filter)
                    filteredRestaurants.Add(res);
            return filteredRestaurants;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
