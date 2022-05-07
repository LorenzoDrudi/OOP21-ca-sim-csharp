using System.Collections.Generic;
using System.Linq;
using casim.Sanzani.RangeUtils;
using NUnit.Framework;

namespace casim.Sanzani.Test
{
    [TestFixture]
    public class RangesTest
    {
        private const int IntRangeStart = 0;
        private const int IntRangeEnd = 10;
        private const int IntRangeStep = 2;
        private const double DoubleRangeStart = 0.5;
        private const double DoubleRangeEnd = 5.0;
        private const double DoubleRangeStep = 1.5;

        [Test]
        public void TestOfGeneric()
        {
            var emptyRange = Ranges.Of(IntRangeStart, IntRangeStart, x => x + 1);
            var expectedEmpty = new List<int>();
            var range1 = Ranges.Of(IntRangeStart, IntRangeEnd, x => x + IntRangeStep);
            var expectedRange1 = new List<int>(new int[] { 0, 2, 4, 6, 8 });
            var range2 = Ranges.Of(DoubleRangeStart, DoubleRangeEnd, x => x + DoubleRangeStep);
            var expectedRange2 = new List<double>(new double[] {0.5, 2, 3.5});

            Assert.AreEqual(expectedEmpty, emptyRange.AsQueryable().ToList());
            Assert.AreEqual(expectedRange1, range1.AsQueryable().ToList());
            Assert.AreEqual(expectedRange2, range2.AsQueryable().ToList());
        }

        [Test]
        public void TestOfIntegerWithStep()
        {
            var emptyRange = Ranges.Of(IntRangeStart, IntRangeStart, IntRangeStep);
            var expectedEmpty = new List<int>();
            var range1 = Ranges.Of(IntRangeStart, IntRangeEnd, IntRangeStep);
            var expected1 = new List<int>(new int[] { 0, 2, 4, 6, 8 });

            Assert.AreEqual(expectedEmpty, emptyRange);
            Assert.AreEqual(expected1, range1.AsQueryable().ToList());
        }

        [Test]
        public void TestOfDouble()
        {
            var range = Ranges.Of(DoubleRangeStart, DoubleRangeEnd, DoubleRangeStep);
            var expected = new List<double>(new double[] {0.5, 2, 3.5});
            Assert.AreEqual(expected, range.AsQueryable().ToList());
        }
    }
}