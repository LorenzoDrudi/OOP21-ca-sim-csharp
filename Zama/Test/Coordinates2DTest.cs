using NUnit.Framework;
using Zama.Coordinates;

namespace Zama.Test
{
    public class Coordinates2DTest
    {
        [Test]
        public void TestXProperty()
        {
            var xValue = 5;
            var yValue = 10;
            var coord = CoordinatesUtil.Of(xValue, yValue);
            Assert.AreEqual(xValue, coord.X);
        }

        [Test]
        public void TestYProperty()
        {
            var xValue = 5;
            var yValue = 10;
            var coord = CoordinatesUtil.Of(xValue, yValue);
            Assert.AreEqual(yValue, coord.Y);
        }

        [Test]
        public void TestAddOperator()
        {
            var value01 = 5;
            var value02 = 12;
            var value03 = 7;
            var a = CoordinatesUtil.Of(value01, value02);
            var b = CoordinatesUtil.Of(value03, value02);
            Assert.AreEqual(a.X + b.X, (a + b).X);
            Assert.AreEqual(a.Y + b.Y, (a + b).Y);
        }
    }
}