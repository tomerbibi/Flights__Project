using System;
using System.Collections.Generic;
using System.Text;

namespace Flights__Project
{
    public class LoginToken<T>
    {
        public T User { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
