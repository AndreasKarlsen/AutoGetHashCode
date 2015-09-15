using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGetHashCode.Exceptions
{
    public class AlreadyOverridingGetHashCode : Exception
    {
        public AlreadyOverridingGetHashCode(string message)
            : base(message)
        {
            
        }

    }
}
