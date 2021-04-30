using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ai_restauracje
{
    public class MainViewModel : ViewModelBase
    {
        Model _model;

        public List<string> AttributeNames 
        { 
            get => _model.AttributeNames;
        }

        public RestaurantToCreate RestaurantToCreate 
        {
            get => _model.RestaurantToCreate;
            set
            {
                _model.RestaurantToCreate = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Restaurant> Restaurants
        {
            get => _model.Restaurants;
            set => _model.Restaurants = value;
        }

        public MainViewModel(Model model)
        {
            _model = model;
        }
    }
}
