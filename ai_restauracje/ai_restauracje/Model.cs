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
        public List<string> AttributeNames { get; set; }
        public ObservableCollection<Restaurant> Restaurants { get; set; }
        public string Test { get => "Dziaa"; }

        public Model() { }

        public Model(string filepath)
        {
            string jsonString = File.ReadAllText(filepath);
            Model m = JsonSerializer.Deserialize<Model>(jsonString);
            AttributeNames = m.AttributeNames;
            Restaurants = m.Restaurants;
        }
    }

    public class Restaurant
    {
        public Restaurant() { }
        public string Name { get; set; }
        public string Location { get; set; }
        public int[] Attributes { get; set; }

        public double Sim(Restaurant other)
        {
            double innerProduct=0;
            for (int i = 0; i < Attributes.Length; i++)
                innerProduct += Attributes[i] * other.Attributes[i];
            double lenA = this.Attributes.Sum();
            double lenB = other.Attributes.Sum();
            return innerProduct / (lenA * lenB);
        }

        public Restaurant(string name, string location, int AttributesCount)
        {
            Name = name;
            Location = location;
            Attributes = new int[AttributesCount];
        }
    }
}
