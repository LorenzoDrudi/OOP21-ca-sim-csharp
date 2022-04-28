using NUnit.Framework;
using Sanzani.Ranges;

namespace SanzaniTest;

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
        var emptyRange = Ranges.Of(IntRangeStart, IntRangeStart, x => x + 1).GetEnumerator();
        var range1 = Ranges.Of(IntRangeStart, IntRangeEnd, x => x + IntRangeStep).GetEnumerator();
        var range2 = Ranges.Of(DoubleRangeStart, DoubleRangeEnd, x => x + DoubleRangeStep).GetEnumerator();

        Assert.False(emptyRange.MoveNext());

        for (int i = IntRangeStart; i < IntRangeEnd; i += IntRangeStep)
        {
            Assert.AreEqual(range1.Current, i);
            if (i + IntRangeStep < IntRangeEnd)
            {
                Assert.True(range1.MoveNext());
            }
        }

        Assert.False(range1.MoveNext());

        for (double i = DoubleRangeStart; i < DoubleRangeEnd; i += DoubleRangeStep)
        {
            Assert.AreEqual(range2.Current, i);
            if (i + DoubleRangeStep < DoubleRangeEnd)
            {
                Assert.True(range2.MoveNext());
            }
        }

        Assert.False(range2.MoveNext());
        emptyRange.Dispose();
        range1.Dispose();
        range2.Dispose();
    }

    [Test]
    public void TestOfIntegerWithStep()
    {
        var emptyRange = Ranges.Of(IntRangeStart, IntRangeStart, IntRangeStep).GetEnumerator();
        var range1 = Ranges.Of(IntRangeStart, IntRangeEnd, IntRangeStep).GetEnumerator();

        Assert.False(emptyRange.MoveNext());
        
        for (int i = IntRangeStart; i < IntRangeEnd; i += IntRangeStep)
        {
            Assert.AreEqual(range1.Current, i);
            if (i + IntRangeStep < IntRangeEnd)
            {
                Assert.True(range1.MoveNext());
            }
        }

        Assert.False(range1.MoveNext());
        emptyRange.Dispose();
        range1.Dispose();
    }

    [Test]
    public void TestOfDouble()
    {
        var range = Ranges.Of(DoubleRangeStart, DoubleRangeEnd, DoubleRangeStep).GetEnumerator();
        
        for (double i = DoubleRangeStart; i < DoubleRangeEnd; i += DoubleRangeStep)
        {
            Assert.AreEqual(range.Current, i);
            if (i + DoubleRangeStep < DoubleRangeEnd)
            {
                Assert.True(range.MoveNext());
            }
        }

        Assert.False(range.MoveNext());
        
        range.Dispose();
    }
}