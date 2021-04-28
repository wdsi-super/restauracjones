﻿using System;
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
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Model model;
		MainViewModel mainViewModel;


		public MainWindow()
		{
			InitializeComponent();

			model = new Model();
			mainViewModel = new MainViewModel(model);
			DataContext = mainViewModel;
		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            model.Restaurants.Add(new Restaurant("Cośtam", "Kraków", model.AttributesNames.Count));
        }
    }
}
