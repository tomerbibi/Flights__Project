using System;
using System.Collections.Generic;
using System.Text;

namespace Flights__Project
{
    class LoginToken<T> where T : IUser
    {
        public T User { get; set; }
    }
}
