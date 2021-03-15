using System;
using System.Collections.Generic;
using System.Text;

namespace Flights__Project
{
    public class Customer : IPoco, IUser
    {
        public Customer()
        {
        }

        public Customer(string first_name, string last_name, string adress, string phone, string credit_card_no, long user_id)
        {
            First_name = first_name;
            Last_name = last_name;
            Adress = adress;
            Phone = phone;
            Credit_card_no = credit_card_no;
            User_id = user_id;
        }

        public Customer(long id, string first_name, string last_name, string adress, string phone, string credit_card_no, long user_id)
        {
            Id = id;
            First_name = first_name;
            Last_name = last_name;
            Adress = adress;
            Phone = phone;
            Credit_card_no = credit_card_no;
            User_id = user_id;
        }

        public long Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Credit_card_no { get; set; }
        public long User_id { get; set; }
        public override bool Equals(object obj)
        {
            return this.Id == ((Customer)obj).Id;
        }

        public override int GetHashCode()
        {
            return (int)this.Id;
        }
        public static bool operator ==(Customer customer1, Customer customer2)
        {
            return customer1.Id == customer2.Id;
        }
        public static bool operator !=(Customer customer1, Customer customer2)
        {
            return !(customer1 == customer2);
        }


        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }
    }
}
