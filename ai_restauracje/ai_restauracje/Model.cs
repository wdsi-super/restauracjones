using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace ai_restauracje
{
	public class Model
	{
		public List<string> AttributesNames;
		public ObservableCollection<Restaurant> Restaurants;
		public string Test { get => "Dziaa"; }

		

		public Model(string filepath = "")
        {
			// TODO: Load JSON file

			ICollection<Restaurant> restaurants = new List<Restaurant>();
			string fileName = "restauracje.json";
			string jsonString = File.ReadAllText(fileName);
			restaurants = JsonSerializer.Deserialize<ICollection<Restaurant>>(jsonString);
			AttributesNames = 
			// TODO: Load AttributesNames from JSON
			AttributesNames = new List<string>
			{
				"atrybut 1",
				"atrrrrrrrr"
			};

			// TODO: Load from JSON
			// coś jak Restaurants = JSON.LoadFile(class=List<Restaurant>, filepath);


			Restaurants = new ObservableCollection<Restaurant>(restaurants);
			//Restaurants = new ObservableCollection<Restaurant>
			//{
			//	new Restaurant("Wielkie Szyncle", "Warszawa", AttributesNames.Count),
			//	new Restaurant("U szwejka", "Warszawa", AttributesNames.Count),
			//	new Restaurant("U szwejka 2", "Kraków", AttributesNames.Count),
			//};
			int a = 0;
		}
	}

	public class Restaurant
    {
		public Restaurant()
        {

        }
		public string Name { get; set; }
		public string Location { get; set; }
		public int[] Attributes { get; set; }

		public double Sim(Restaurant other)
        {
			return 0.0;
        }

		public Restaurant(string Name, string Location, int AttributesCount)
        {
			Name = Name;
			Location = Location;
			Attributes = new int[AttributesCount];
        }
    }
}
