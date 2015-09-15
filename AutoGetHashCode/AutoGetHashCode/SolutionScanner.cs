using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;

namespace AutoGetHashCode
{
    public class SolutionScanner
    {
        private readonly string _path;

        public SolutionScanner(string path)
        {
            _path = path;
        }

        public Solution GetCompilation()
        {
            // start Roslyn workspace
            var workspace = MSBuildWorkspace.Create();

            // open solution we want to analyze
            Solution solutionToAnalyze =
                workspace.OpenSolutionAsync(_path).Result;

            return solutionToAnalyze;
        }
    }
}
