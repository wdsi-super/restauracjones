using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ai_restauracje
{
    public class MainViewModel : ViewModelBase
    {
        Model _model;

        public List<AttributeForNewRestaurant> data4Combobox = new List<AttributeForNewRestaurant>();
        public ObservableCollection<Restaurant> Restaurants
        {
            get => _model.Restaurants;
           // set => SetProperty(ref _model.Restaurants, value);
        }

        public string Tescik
        {
            get => _model.Test;
        }

        public MainViewModel(Model model)
        {
            _model = model;
            foreach (var attr in _model.AttributeNames)
                data4Combobox.Add(new AttributeForNewRestaurant() { AttributeName=attr, AttributeValue=false});
        }
    }

    public class AttributeForNewRestaurant
    {
        public bool AttributeValue { get; set; }
        public string AttributeName { get; set; }

    }
}
