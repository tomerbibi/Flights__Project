using System;
using System.Collections.Generic;
using System.Text;

namespace Flights__Project
{
    public class Administrator : IUser, IPoco
    {
        public Administrator()
        {
        }

        public Administrator(string firstName, string lastName, int level, long user_id)
        {
            FirstName = firstName;
            LastName = lastName;
            Level = level;
            User_id = user_id;
        }

        public Administrator(int id, string firstName, string lastName, int level, long user_id)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Level = level;
            User_id = user_id;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Level { get; set; }

        public long User_id { get; set; }
        public override bool Equals(object obj)
        {
            return this.Id == ((Administrator)obj).Id;
        }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }
        public static bool operator ==(Administrator administrator1, Administrator administrator2)
        {
            return administrator1.Id == administrator2.Id;
        }
        public static bool operator !=(Administrator administrator1, Administrator administrator2)
        {
            return !(administrator1 == administrator2);
        }


        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }

    }
}
