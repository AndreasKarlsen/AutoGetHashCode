using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGetHashCode.Exceptions
{
    public class NotOverridingEqualsException : Exception
    {
        public NotOverridingEqualsException(string message)
            : base(message)
        {

        }
    }
}
