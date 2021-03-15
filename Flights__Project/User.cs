using System;
using System.Collections.Generic;
using System.Text;

namespace Flights__Project
{
    public class User : IPoco
    {
        public User()
        {
        }

        public User(string username, string password, string email, int userRole)
        {
            Username = username;
            Password = password;
            Email = email;
            UserRole = userRole;
        }

        public User(long id, string username, string password, string email, int userRole)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
            UserRole = userRole;
        }

        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int UserRole { get; set; }
        public override bool Equals(object obj)
        {
            return this.Id == ((User)obj).Id;
        }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }
        public static bool operator ==(User user1, User user2)
        {
            return user1.Id == user2.Id;
        }
        public static bool operator !=(User user1, User user2)
        {
            return !(user1 == user2);
        }


        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }

    }
}
