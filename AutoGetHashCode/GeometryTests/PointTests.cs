using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


namespace GeometryTests
{
    [TestClass]
    public class PointTests
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