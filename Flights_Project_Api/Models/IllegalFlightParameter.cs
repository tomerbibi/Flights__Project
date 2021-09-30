using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Flights_Project_Api.Models
{
    [Serializable]
    public class IllegalFlightParameter : Exception
    {
        public IllegalFlightParameter()
        {
        }

        public IllegalFlightParameter(string message) : base(message)
        {
        }

        public IllegalFlightParameter(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IllegalFlightParameter(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

}
