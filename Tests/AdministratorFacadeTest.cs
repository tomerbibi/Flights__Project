using Flights__Project;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AdministratorFacadeTest
    {
        private LoggedInAdministratorFacade a = new LoggedInAdministratorFacade();
        private LoggedInCustomerFacade c = new LoggedInCustomerFacade();

        [TestInitialize]
        public void TestInitialize()
        {
           /* UserDAOPGSQL u = new UserDAOPGSQL();
            u.GetAll().ForEach(_ =>
            {
                u.Remove(_);
            });
            u.Add(new User("tomer", "bibi", "tomerbibi2002@gmail.com", 1));
            // reset the autoincrement for users and admins and then put that code out of comment
            new AdministratorDAOPGSQL().Add(new Administrator("tomer", "bibi", 3,5));*/
        }


        [TestMethod]
        public void TestMethod1()
        {
            LoginService l = new LoginService();
            l.Login("tomer", "bibi", out LoginToken<object> token, out FacadeBase facade);
            //Assert.IsTrue(token.User.GetType() == typeof(Administrator));
        }
    }
}
