using casim.Zama.Coordinates;
using NUnit.Framework;

namespace casim.Zama.Test
{
    [TestFixture]
    public class Coordinates3DTest
    {
        [Test]
        public void TestXProperty()
        {
            var xValue = 5;
            var yValue = 13;
            var zValue = 4;
            var coord = CoordinatesUtil.Of(xValue, yValue, zValue);
            Assert.AreEqual(xValue, coord.X);
        }

        [Test]
        public void TestYProperty()
        {
            var xValue = 5;
            var yValue = 10;
            var zValue = 3;
            var coord = CoordinatesUtil.Of(xValue, yValue, zValue);
            Assert.AreEqual(yValue, coord.Y);
        }

        [Test]
        public void TestZProperty()
        {
            var xValue = 20;
            var yValue = 10;
            var zValue = 4;
            var coord = CoordinatesUtil.Of(xValue, yValue, zValue);
            Assert.AreEqual(zValue, coord.Z);
        }

        [Test]
        public void TestAddOperator()
        {
            var value01 = 3;
            var value02 = 18;
            var value03 = 14;
            var a = CoordinatesUtil.Of(value01, value02, value03);
            var b = CoordinatesUtil.Of(value02, value02, value01);
            Assert.AreEqual(a.X + b.X, (a + b).X);
            Assert.AreEqual(a.Y + b.Y, (a + b).Y);
            Assert.AreEqual(a.Z + b.Z, (a + b).Z);
        }

        [Test]
        public void TestSubtractOperator()
        {
            var value01 = 3;
            var value02 = 18;
            var value03 = 14;
            var a = CoordinatesUtil.Of(value01, value02, value03);
            var b = CoordinatesUtil.Of(value02, value02, value01);
            Assert.AreEqual(a.X - b.X, (a - b).X);
            Assert.AreEqual(a.Y - b.Y, (a - b).Y);
            Assert.AreEqual(a.Z - b.Z, (a - b).Z);
        }
    }
}