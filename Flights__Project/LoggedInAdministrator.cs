using System;
using System.Collections.Generic;
using System.Text;

namespace Flights__Project
{
    class LoggedInAdministrator : AnonymousUserFacade, ILoggedInAdministrator
    {
        public void CreateAdmin(LoginToken<Administrator> token, Administrator admin)
        {
            if (token.User.Level > 2)
                _adminDAOPGSQL.Add(admin);
        }

        public void CreateNewAirline(LoginToken<Administrator> token, AirlineCompany airline)
        {
            if(token.User.Level > 1)
               _airlineDAOPGSQL.Add(airline);
        }

        public void CreateNewCustomer(LoginToken<Administrator> token, Customer customer)
        {
            if (token.User.Level > 1)
                _customerDAOPGSQL.Add(customer);
        }

        public List<Customer> GetAllCustomers(LoginToken<Administrator> token)
        {
            return _customerDAOPGSQL.GetAll();
        }

        public void RemoveAdmin(LoginToken<Administrator> token, Administrator admin)
        {
            if (token.User.Level > 2 && admin.Level < 3)
                _adminDAOPGSQL.Remove(admin);
        }

        public void RemoveAirline(LoginToken<Administrator> token, AirlineCompany airline)
        {
            if (token.User.Level > 1)
                _airlineDAOPGSQL.Remove(airline);
        }

        public void RemoveCustomer(LoginToken<Administrator> token, Customer customer)
        {
            if (token.User.Level > 1)
                _customerDAOPGSQL.Remove(customer);
        }

        public void UpdateAdmin(LoginToken<Administrator> token, Administrator admin)
        {
            if (token.User.Level > 2 && admin.Level < 3)
                _adminDAOPGSQL.Update(admin);
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
