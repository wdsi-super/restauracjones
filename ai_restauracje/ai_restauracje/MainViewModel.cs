﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_restauracje
{
    public class MainViewModel : ViewModelBase
    {
        Model _model;

        public ObservableCollection<Restaurant> Restaurants
        {
            get
            {
                return _model.Restaurants;
            }
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