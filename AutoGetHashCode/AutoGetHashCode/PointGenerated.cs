using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGetHashCode
{
    public partial class Point
    {
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + X;
                hash = hash * 23 + Y;
                return hash;
            }
        }
    }
}
