using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoGetHashCode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TestAutoGetHashCode
{
    [TestClass]
    public class PointTester
    {
        private Point _point;
        [TestInitialize]
        public void SetUp()
        {
            _point = new Point(4, 4);
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            AreEqual(9089, _point.GetHashCode());
        }
    }
}
