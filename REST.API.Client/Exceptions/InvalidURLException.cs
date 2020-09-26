using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.API.Client.Exceptions
{
    public class InvalidURLException: Exception
    {
        public InvalidURLException(string message): base(message)
        {

        }
    }
}
