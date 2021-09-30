using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flights_Project_Api.Models
{
    public class AllCustomerDetails
    {
        public AllCustomerDetails()
        {
        }

        public AllCustomerDetails(string username, string password, string fisrtName, string lastName, 
            string email, string phoneNumber, string adress, string creditCardNumber)
        {
            Username = username;
            Password = password;
            FisrtName = fisrtName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Adress = adress;
            CreditCardNumber = creditCardNumber;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public string CreditCardNumber { get; set; }

    }
}
