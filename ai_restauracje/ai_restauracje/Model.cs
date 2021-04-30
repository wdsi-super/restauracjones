using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.IO;

namespace ai_restauracje
{
    public class Model
    {
        public List<string> AttributeNames { get; set; }
        public ObservableCollection<Restaurant> Restaurants { get; set; }


        public RestaurantToCreate RestaurantToCreate { get; set; }
        public Model() { }

        public Model(string filepath)
        {
            string jsonString = File.ReadAllText(filepath);
            Model m = JsonSerializer.Deserialize<Model>(jsonString);
            AttributeNames = m.AttributeNames;
            Restaurants = m.Restaurants;
            RestaurantToCreate = new RestaurantToCreate("", "", AttributeNames.Count, AttributeNames);
        }

    }

    public class Restaurant
    {
        public Restaurant() { }
        public string Name { get; set; }
        public string Location { get; set; }
        public int[] Attributes { get; set; }

        public int IsPub { get { return Attributes[0]; } }
        public int IsPizzeria { get { return Attributes[1]; } }
        public int IsCafe { get { return Attributes[2]; } }
        public int IsBar { get { return Attributes[3]; } }
        public int IsItalian { get { return Attributes[4]; } }
        public int IsPolish { get { return Attributes[5]; } }
        public int IsKebab { get { return Attributes[6]; } }
        public int IsOriental { get { return Attributes[7]; } }
        public int IsVegan { get { return Attributes[8]; } }
        public int IsIndian { get { return Attributes[9]; } }
        public int IsBurgerAndSteak { get { return Attributes[10]; } }
        public int IsFusion { get { return Attributes[11]; } }
        public int IsChildrenFriendly { get { return Attributes[12]; } }
        public int IsAnimalsFriendly { get { return Attributes[13]; } }



        public double Sim(Restaurant other)
        {
            double innerProduct = 0;
            for (int i = 0; i < Attributes.Length; i++)
                innerProduct += Attributes[i] * other.Attributes[i];
            double lenA = Math.Sqrt(this.Attributes.Sum());
            double lenB = Math.Sqrt(other.Attributes.Sum());
            return innerProduct / (lenA * lenB);
        }

        public Restaurant(string name, string location, int AttributesCount)
        {
            Name = name;
            Location = location;
            Attributes = new int[AttributesCount];
        }

    }

    public class RestaurantToCreate : Restaurant
    {
        public List<AttributeForNewRestaurant> ComboBoxOptions { get; set; }
        public ValidLocations LocationEnum { get; set; }
        public RestaurantToCreate(string name, string location, int attributesCount, List<string> attributeNames) : base(name, location, attributesCount)
        {
            ComboBoxOptions = new List<AttributeForNewRestaurant>();
            foreach (var attr in attributeNames)
                ComboBoxOptions.Add(new AttributeForNewRestaurant() { AttributeName = attr, AttributeValue = false });
        }
    }
    public class AttributeForNewRestaurant
    {
        public bool AttributeValue { get; set; }
        public string AttributeName { get; set; }

    }
}
