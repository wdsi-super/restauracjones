using System.Collections.ObjectModel;

namespace ai_restauracje
{
    public class MainViewModel : ViewModelBase
    {
        Model _model;

        public ObservableCollection<Restaurant> Restaurants
        {
            get => _model.Restaurants;
            set => SetProperty(ref _model.Restaurants, value);
        }

        public string Tescik
        {
            get => _model.Test;
        }

        public MainViewModel(Model model)
        {
            _model = model;
        }
    }
}
