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

        Brush funBorderBrush = new SolidColorBrush(Color.FromRgb(153, 51, 255));
        Brush normalBorderBrush = new SolidColorBrush(Color.FromRgb(112, 112, 112));
        public MainWindow()
        {
            model = new Model("restauracje.json");
            mainViewModel = new MainViewModel(model);
            DataContext = mainViewModel;


            InitializeComponent();
            filter.SelectedIndex = 0;
            kBestComboBox.SelectedIndex = 0;
            useSelectedBtn.BorderThickness = new Thickness(2);
            useSelectedBtn.BorderBrush = funBorderBrush;
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
            useSelectedBtn_Click(sender, e);
        }

        private void useWithoutAddingButton_Click(object sender, RoutedEventArgs e)
        {
            fromOptionsOnly = true;
            tabControl.SelectedIndex = 1;
            kBestRestaurantList.ItemsSource = mainViewModel.KBestRestaurants = SelectBestRestaurants((int)kSlider.Value, (ValidLocations)kBestComboBox.SelectedItem);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fromOptionsOnly = false;
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
            //attrComboBox.SelectedIndex = -1;
        }

        private void choseAttributesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!onlyAttrClicked)
            {
                customClicked = false;
                onlyAttrClicked = true;
                Option1.Visibility = Visibility.Hidden;
                Option2.Visibility = Visibility.Hidden;
                Option3.Visibility = Visibility.Visible;
                choseAttributesBtn.BorderThickness = new Thickness(2);
                choseAttributesBtn.BorderBrush = funBorderBrush;
                useSelectedBtn.BorderThickness = new Thickness(1);
                useSelectedBtn.BorderBrush = normalBorderBrush;
                addCutomBtn.BorderThickness = new Thickness(1);
                addCutomBtn.BorderBrush = normalBorderBrush;
            }
            else
            {
                onlyAttrClicked = false;
            }
        }
        private void useSelectedBtn_Click(object sender, RoutedEventArgs e)
        {
            if (onlyAttrClicked || customClicked)
            {
                Option1.Visibility = Visibility.Visible;
                Option2.Visibility = Visibility.Hidden;
                Option3.Visibility = Visibility.Hidden;
                useSelectedBtn.BorderThickness = new Thickness(2);
                useSelectedBtn.BorderBrush = funBorderBrush;
                choseAttributesBtn.BorderThickness = new Thickness(1);
                choseAttributesBtn.BorderBrush = normalBorderBrush;
                addCutomBtn.BorderThickness = new Thickness(1);
                addCutomBtn.BorderBrush = normalBorderBrush;
            }
        }
        private void addCutomBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!customClicked)
            {
                customClicked = true;
                onlyAttrClicked = false;
                Option1.Visibility = Visibility.Hidden;
                Option2.Visibility = Visibility.Visible;
                Option3.Visibility = Visibility.Hidden;
                addCutomBtn.BorderThickness = new Thickness(2);
                addCutomBtn.BorderBrush = funBorderBrush;
                useSelectedBtn.BorderThickness = new Thickness(1);
                useSelectedBtn.BorderBrush = normalBorderBrush;
                choseAttributesBtn.BorderThickness = new Thickness(1);
                choseAttributesBtn.BorderBrush = normalBorderBrush;
            }
            else
            {
                customClicked = false;

            }
        }


    }
}
