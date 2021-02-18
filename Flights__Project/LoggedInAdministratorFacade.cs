using System;
using System.Collections.Generic;
using System.Text;

namespace Flights__Project
{
    class LoggedInAdministratorFacade : AnonymousUserFacade, ILoggedInAdministrator
    {
        public void CreateAdmin(LoginToken<Administrator> token, Administrator admin)
        {
            if (token.User.Level > 2)
                _adminDAOPGSQL.Add(admin);
            else
             Console.WriteLine($"administrator level {token.User.Level} cant create administrators");
        }

        public void CreateNewAirline(LoginToken<Administrator> token, AirlineCompany airline)
        {
            if(token.User.Level > 1)
               _airlineDAOPGSQL.Add(airline);
            else
              Console.WriteLine("administrator level 1 cant create new airlines");
        }

        public void CreateNewCustomer(LoginToken<Administrator> token, Customer customer)
        {
            if (token.User.Level > 1)
                _customerDAOPGSQL.Add(customer);
            else
              Console.WriteLine("administrator level 1 cant create new customers");
            
        }

        public List<Customer> GetAllCustomers(LoginToken<Administrator> token)
        {
            return _customerDAOPGSQL.GetAll();
        }

        public void RemoveAdmin(LoginToken<Administrator> token, Administrator admin)
        {
            if (token.User.Level > 2 && admin.Level < 3)
                _adminDAOPGSQL.Remove(admin);
            else
            {
                if(token.User.Level < 3)
                    Console.WriteLine($"administrator level {token.User.Level} cant delete administrators");
                else
                    Console.WriteLine($"administrator level {token.User.Level} cant delete administrator" +
                        $" level {admin.Level}");
            }
        }

        public void RemoveAirline(LoginToken<Administrator> token, AirlineCompany airline)
        {
            if (token.User.Level > 1)
                _airlineDAOPGSQL.Remove(airline);
            else
                Console.WriteLine("administrator level 1 cant remove airlines");
        }

        public void RemoveCustomer(LoginToken<Administrator> token, Customer customer)
        {
            if (token.User.Level > 1)
                _customerDAOPGSQL.Remove(customer);
            else
                Console.WriteLine("administrator level 1 cant remove customers");
        }

        public void UpdateAdmin(LoginToken<Administrator> token, Administrator admin)
        {
            if (token.User.Level > 2 && admin.Level < 3)
                _adminDAOPGSQL.Update(admin);
            else
                Console.WriteLine($"administrator level {token.User.Level} cant update administrator" +
                    $" level {admin.Level}");
        }

        public void UpdateAirlineDetails(LoginToken<Administrator> token, AirlineCompany airline)
        {
            _airlineDAOPGSQL.Update(airline);
        }

        public void UpdateCustomerDetails(LoginToken<Administrator> token, Customer customer)
        {
            _customerDAOPGSQL.Update(customer);
        }
    }
}
