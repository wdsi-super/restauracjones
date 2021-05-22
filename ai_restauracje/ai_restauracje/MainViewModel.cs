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

        public ObservableCollection<SimilarRestaurant> KBestRestaurants
        {
            get => _model.KBestRestaurants;
            set => _model.KBestRestaurants = value;
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

        public List<AttributeForNewRestaurant> ComboboxOptions
        {
            get
            {
                return _model.ComboBoxOptions;
            }
            set
            {
                _model.ComboBoxOptions = value;
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
