using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_restauracje
{
	public class Model
	{
		public List<string> AttributesList;
		public ObservableCollection<Restaurant> Restaurants;
		public string Test { get => "Dziaa"; }


		public Model(string filepath = "")
        {
			// TODO: Load JSON file

			// TODO: Load AttributesList from JSON
			AttributesList = new List<string>
			{
				"atrybut 1",
				"atrrrrrrrr"
			};

			// TODO: Load from JSON
			// coś jak Restaurants = JSON.LoadFile(class=List<Restaurant>, filepath);

			Restaurants = new ObservableCollection<Restaurant>
			{
				new Restaurant("wielkie szyncle", "warszaw", AttributesList.Count),
				new Restaurant("u szwejka", "warszawa", AttributesList.Count),
				new Restaurant("u szwejka 2", "krakuf", AttributesList.Count),
			};
		}
	}

	public class Restaurant
    {
		public string Name { get; set; }
		public string Location { get; set; }
		public double[] Attributes { get; set; }

		public double Sim(Restaurant other)
        {
			return 0.0;
        }

		public Restaurant(string name, string location, int attributesCount)
        {
			Name = name;
			Location = location;
			Attributes = new double[attributesCount];
        }
    }
}
