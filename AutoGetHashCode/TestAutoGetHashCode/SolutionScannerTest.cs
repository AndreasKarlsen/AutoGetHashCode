using System;
using AutoGetHashCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAutoGetHashCode
{
    [TestClass]
    public class SolutionScannerTest
    {
        private SolutionScanner _solutionScanner;
        [TestInitialize]
        public void SetUp()
        {
            _solutionScanner = new SolutionScanner(@"..\..\..\AutoGetHashCode.sln");
        }

        [TestMethod]
        public void TestGetCompilation()
        {
            //_solutionScanner.GetCompilation();
        }
    }
}
