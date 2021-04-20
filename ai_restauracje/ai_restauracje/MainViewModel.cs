using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_restauracje
{
	public class MainViewModel : ViewModelBase
	{
		Model _model;

		private string _openFileName;
		public string OpenFileName
		{
			get => _openFileName;
			set => SetProperty(ref _openFileName, value);
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
