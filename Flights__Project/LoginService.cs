using System;
using System.Collections.Generic;
using System.Text;

namespace Flights__Project
{
    class LoginService : ILoginService
    {
        private IAirlineDAO _arilineDAO;
        private ICustomerDAO _customerDAO;
        private IAdministratorDAO adminDAO;

        public bool Login(string userName, string password, out LoginToken<IUser> token, out FacadeBase facade)
        {
            // that function needs to return a Facade

            // in program its gonna be like that:
            // Facade c = LoginService.Login(someName, somePassword, out LoginToken l) // the login token in
            // the out is just a new LoginToken that i create in the out

            token = new LoginToken<IUser>();
            facade = new FacadeBase();
            UserDAOPGSQL u = new UserDAOPGSQL();
            List<User> users = u.GetAll();
            for (int i = 0; i < users.Count; i++)
            {
                
                if (users[i].Username == userName && users[i].Password == password)
                {
                    if (users[i].UserRole == 1)
                    {
                        AdministratorDAOPGSQL ad = new AdministratorDAOPGSQL();
                        List<Administrator> administrators = ad.GetAll();
                        for (int b = 0; b < administrators.Count; b++)
                        {
                            if(administrators[b].User_id == users[i].Id)
                                token.User = administrators[b];
                        }
                        facade = new LoggedInAdministratorFacade();
                        return true;
                    }
                    else if (users[i].UserRole == 2)
                    {
                        AirlineDAOPGSQL ar = new AirlineDAOPGSQL();
                        List<AirlineCompany> airlines = ar.GetAll();

                        for (int b = 0; b < airlines.Count; b++)
                        {
                            if (airlines[b].UserId == users[i].Id)
                                token.User = airlines[b];
                        }
                        facade = new LoggedInAirlineFacade();
                        return true;
                    }
                    else if (users[i].UserRole == 3)
                    {
                        CustomerDAOPGSQL c = new CustomerDAOPGSQL();
                        List<Customer> customers = c.GetAll();
                        for (int b = 0; b < customers.Count; b++)
                        {
                            if (customers[b].User_id == users[i].Id)
                                token.User = customers[b];
                        }
                        facade = new LoggedInCustomerFacade();
                        return true;
                    }
                }
                
            }
            throw new WrongCredentialsException();
        }
    }
}
