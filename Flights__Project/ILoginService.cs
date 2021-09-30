using System;
using System.Collections.Generic;
using System.Text;

namespace Flights__Project
{
    public interface ILoginService
    {
        bool Login(string userName, string password, out LoginToken<object> token, out FacadeBase facade);
    }
}
