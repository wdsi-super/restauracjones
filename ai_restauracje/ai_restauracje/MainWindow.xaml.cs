using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ai_restauracje
{
	public partial class MainWindow : Window
	{
		Model model;
		MainViewModel mainViewModel;


		public MainWindow()
		{
			model = new Model("restauracje.json");
			mainViewModel = new MainViewModel(model);
			DataContext = mainViewModel;
			
			App.Current.Resources.Add("modelView", mainViewModel);

			InitializeComponent();
			filter.SelectedIndex = 0;
		}

        private void filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			var selected = filter.SelectedIndex;
        }
    }
}
