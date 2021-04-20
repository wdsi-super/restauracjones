using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_restauracje
{
	class MainViewModel : ViewModelBase
	{
		private string _openFileName;
		public string OpenFileName
		{
			get => _openFileName;
			set => SetProperty(ref _openFileName, value);
		}

	}
}
