using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGetHashCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var solutionScanner = new SolutionScanner(@"..\..\..\AutoGetHashCode.sln");
            var hashCodeGenerator = new HashCodeGenerator(solutionScanner);
            hashCodeGenerator.GenerateHashCode();
        }
    }
}
