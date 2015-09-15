using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGetHashCode
{
    public class FileReader
    {
        public FileReader() { }

        public IEnumerable<string> GetFilesInSolution()
        {
            var file = File.ReadAllText(@"C:\Users\andre\Documents\Visual Studio 2015\Projects\AutoGetHashCode\AutoGetHashCode\AutoGetHashCode\Point.cs");
            return new List<string>() {file};
        } 
    }
}
