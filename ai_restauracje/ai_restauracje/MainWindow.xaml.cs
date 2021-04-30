using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ai_restauracje
{
    public partial class MainWindow : Window
    {
        Model model;
        MainViewModel mainViewModel;

        bool customClicked = false;

        public MainWindow()
        {
            model = new Model("restauracje.json");
            mainViewModel = new MainViewModel(model);
            DataContext = mainViewModel;


            InitializeComponent();
            filter.SelectedIndex = 0;
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

        private void addCutomBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!customClicked)
            {
                addCutomBtn.Background = new SolidColorBrush(Color.FromRgb(240,240,240));
                customClicked = true;
                gridToHide1.Visibility = Visibility.Visible;
                gridToHide2.Visibility = Visibility.Visible;
            }
            else
            {
                customClicked = false;
                addCutomBtn.Background = new SolidColorBrush(Color.FromRgb(221,221,221));
                gridToHide1.Visibility = Visibility.Hidden;
                gridToHide2.Visibility = Visibility.Hidden;
            }
        }

        private void useSelectedBtn_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void useWithoutAddingButton_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }
    }
}
