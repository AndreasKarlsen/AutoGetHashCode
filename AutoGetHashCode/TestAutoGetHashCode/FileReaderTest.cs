using System;
using System.Linq;
using AutoGetHashCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestAutoGetHashCode
{
    [TestClass]
    public class FileReaderTest
    {
        private FileReader _fileReader;

        [TestInitialize]
        public void SetUp()
        {
            _fileReader = new FileReader();
        }

        [TestMethod]
        public void LoadAllFilesInSolutionTest()
        {
            var result = _fileReader.GetFilesInSolution();
            Assert.AreEqual(1, result.Count());
        }
    }
}
