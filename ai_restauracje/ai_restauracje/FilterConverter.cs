using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ai_restauracje
{
    class FilterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || (Locations)value==Locations.Dowolne)
            {
                return (App.Current.Resources["modelView"] as MainViewModel).Restaurants;
            }
            string filter = ((Locations)value).ToString();
            var restaurants = (App.Current.Resources["modelView"] as MainViewModel).Restaurants;
            List<Restaurant> filteredRestaurants = new List<Restaurant>();
            foreach (var res in restaurants)
                if (res.Location == filter) 
                {
                    filteredRestaurants.Add(new Restaurant(res.Name, res.Location, res.Attributes.Length));
                    for (int i = 0; i < res.Attributes.Length; i++)
                        filteredRestaurants.Last().Attributes[i] = res.Attributes[i];
                }
            return filteredRestaurants;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
