using System;
using System.Collections.Generic;
using System.Text;

namespace Flights__Project
{
    public interface ICustomerDAO : IBasicDB<Customer>
    {
        Customer GetCustomerByUserame(string name);
    }
}
