using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_restauracje
{
	public class Model
	{
		public List<string> AttributesList;
		public List<Restaurant> Restaurants;

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

			Restaurants = new List<Restaurant>
			{
				new Restaurant("wielkie szyncle", "warszaw", AttributesList.Count),
				new Restaurant("u szwejka", "warszawa", AttributesList.Count),
				new Restaurant("u szwejka 2", "krakuf", AttributesList.Count),
			};
		}
	}

	public class Restaurant
    {
		public string Name;
		public string Location;
        public double[] Attributes;

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
