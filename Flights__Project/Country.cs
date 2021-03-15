using System;
using System.Collections.Generic;
using System.Text;

namespace Flights__Project
{
    public class Country : IPoco
    {
        public Country(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Country(string name)
        {
            Name = name;
        }

        public Country()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public override bool Equals(object obj)
        {
            return this.Id == ((Country)obj).Id;
        }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }
        public static bool operator ==(Country country1, Country country2)
        {
            return country1.Id == country2.Id;
        }
        public static bool operator !=(Country country1, Country country2)
        {
            return !(country1 == country2);
        }


        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }
    }
}
