using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace ai_restauracje
{
    public partial class MainWindow : Window
    {
        Model model;
        MainViewModel mainViewModel;

        bool customClicked = false;
        bool onlyAttrClicked = false;
        bool fromOptionsOnly = false;
        public MainWindow()
        {
            model = new Model("restauracje.json");
            mainViewModel = new MainViewModel(model);
            DataContext = mainViewModel;


            InitializeComponent();
            filter.SelectedIndex = 0;
            kBestComboBox.SelectedIndex = 0;
        }

        private void attributeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            attributeComboBox.SelectedIndex = -1;
        }

        private void addToDatabaseButton_Click(object sender, RoutedEventArgs e)
        {
            RestaurantToCreate restaurant = mainViewModel.RestaurantToCreate;
            for (int i = 0; i < restaurant.ComboBoxOptions.Count; i++)
                restaurant.Attributes[i] = restaurant.ComboBoxOptions[i].AttributeValue ? 1 : 0;
            restaurant.Location = restaurant.LocationEnum.ToString();
            mainViewModel.Restaurants.Add(restaurant);
            mainViewModel.RestaurantToCreate = new RestaurantToCreate("", "", mainViewModel.AttributeNames.Count, mainViewModel.AttributeNames);

        }

        private void useSelectedBtn_Click(object sender, RoutedEventArgs e)
        {
            fromOptionsOnly = false;
            tabControl.SelectedIndex = 1;
            kBestRestaurantList.ItemsSource = mainViewModel.KBestRestaurants = SelectBestRestaurants((int)kSlider.Value, (ValidLocations)kBestComboBox.SelectedItem);
        }

        private void useWithoutAddingButton_Click(object sender, RoutedEventArgs e)
        {
            fromOptionsOnly = true;
            tabControl.SelectedIndex = 1;
            kBestRestaurantList.ItemsSource = mainViewModel.KBestRestaurants = SelectBestRestaurants((int)kSlider.Value, (ValidLocations)kBestComboBox.SelectedItem);
        }

        private ObservableCollection<SimilarRestaurant> SelectBestRestaurants(int k, ValidLocations location)
        {
            Restaurant selectedRestaurant;
            if (fromOptionsOnly)
            {
                selectedRestaurant = new Restaurant("", "", mainViewModel.AttributeNames.Count);
                for (int i = 0; i < mainViewModel.ComboboxOptions.Count; i++)
                {
                    selectedRestaurant.Attributes[i] = mainViewModel.ComboboxOptions[i].AttributeValue ? 1 : 0;
                }
            }
            else
            {
                if (listView.SelectedItem == null) return new ObservableCollection<SimilarRestaurant>();
                selectedRestaurant = (Restaurant)listView.SelectedItem;
            }
            List<SimilarRestaurant> restaurantsInTheSameCity = new List<SimilarRestaurant>();
            foreach (Restaurant res in mainViewModel.Restaurants)
                if (res.Location == location.ToString() && res.Name != selectedRestaurant.Name)
                {
                    var sim = (int)(Math.Round(selectedRestaurant.Sim(res), 2) * 100);
                    restaurantsInTheSameCity.Add(new SimilarRestaurant(res, sim.ToString() + "%"));
                }
            restaurantsInTheSameCity.Sort(
            delegate (SimilarRestaurant r1, SimilarRestaurant r2) 
            {
                if (r1.Similarity == "100%" && r2.Similarity == "100%") return 0;
                if (r1.Similarity == "100%") return -1;
                if (r2.Similarity == "100%") return 1;
                return r2.Similarity.CompareTo(r1.Similarity); 
            });
            ObservableCollection<SimilarRestaurant> similars = new ObservableCollection<SimilarRestaurant>();
            for (int i = 0; i < restaurantsInTheSameCity.Count && i < k; i++)
                similars.Add(restaurantsInTheSameCity[i]);
            return similars;
        }
        private void kSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (kBestComboBox != null && kBestComboBox.SelectedIndex != -1)
                kBestRestaurantList.ItemsSource = mainViewModel.KBestRestaurants = SelectBestRestaurants((int)kSlider.Value, (ValidLocations)kBestComboBox.SelectedItem);
        }

        private void kBestComboBox_Selected(object sender, RoutedEventArgs e)
        {
            kBestRestaurantList.ItemsSource = mainViewModel.KBestRestaurants = SelectBestRestaurants((int)kSlider.Value, (ValidLocations)kBestComboBox.SelectedItem);
        }

        private void attrComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            attrComboBox.SelectedIndex = -1;
        }

        private void choseAttributesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!onlyAttrClicked)
            {
                choseAttributesBtn.Background = new SolidColorBrush(Color.FromRgb(240, 240, 240));
                addCutomBtn.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                customClicked = false;
                onlyAttrClicked = true;
                gridToHide1.Visibility = Visibility.Hidden;
                gridToHide2.Visibility = Visibility.Visible;
            }
            else
            {
                onlyAttrClicked = false;
                choseAttributesBtn.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                gridToHide2.Visibility = Visibility.Hidden;
            }
        }
        private void addCutomBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!customClicked)
            {
                addCutomBtn.Background = new SolidColorBrush(Color.FromRgb(240, 240, 240));
                choseAttributesBtn.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                customClicked = true;
                onlyAttrClicked = false;
                gridToHide1.Visibility = Visibility.Visible;
                gridToHide2.Visibility = Visibility.Hidden;
            }
            else
            {
                customClicked = false;
                addCutomBtn.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                gridToHide1.Visibility = Visibility.Hidden;
            }
        }
    }
}
