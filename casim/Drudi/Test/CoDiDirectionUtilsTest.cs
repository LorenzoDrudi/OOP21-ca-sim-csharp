using Drudi.Cell.CoDiCell;
using NUnit.Framework;
using Zama.Coordinates;

namespace Drudi.Test
{
    /// <summary>
    /// Class test for <see cref="CoDiDirectionUtils"/>.
    /// </summary>
    [TestFixture]
    public class CoDiDirectionUtilsTest
    {
        /// <summary>
        /// Test method for GetDirectionOffset() in <see cref="CoDiDirectionUtils"/>.
        /// </summary>
        [Test]
        public void GetDirectionOffsetTest()
        {
            Assert.AreEqual(CoordinatesUtil.Of(0, 0, 1), CoDiDirectionUtils.GetDirectionOffset(CoDiDirection.North));
            Assert.AreEqual(CoordinatesUtil.Of(0, 0, -1), CoDiDirectionUtils.GetDirectionOffset(CoDiDirection.South));
            Assert.AreEqual(CoordinatesUtil.Of(-1, 0, 0), CoDiDirectionUtils.GetDirectionOffset(CoDiDirection.West));
            Assert.AreEqual(CoordinatesUtil.Of(1, 0, 0), CoDiDirectionUtils.GetDirectionOffset(CoDiDirection.East));
            Assert.AreEqual(CoordinatesUtil.Of(0, 1, 0), CoDiDirectionUtils.GetDirectionOffset(CoDiDirection.Top));
            Assert.AreEqual(CoordinatesUtil.Of(0, -1, 0), CoDiDirectionUtils.GetDirectionOffset(CoDiDirection.Bottom));

        }
        
        /// <summary>
        /// Test method for GetOppositeDirection() in <see cref="CoDiDirectionUtils"/>.
        /// </summary>
        [Test]
        public void GetOppositeDirectionTest()
        {
            Assert.AreEqual(CoDiDirection.South, CoDiDirectionUtils.GetOppositeDirection(CoDiDirection.North));
            Assert.AreEqual(CoDiDirection.North, CoDiDirectionUtils.GetOppositeDirection(CoDiDirection.South));
            Assert.AreEqual(CoDiDirection.West, CoDiDirectionUtils.GetOppositeDirection(CoDiDirection.East));
            Assert.AreEqual(CoDiDirection.East, CoDiDirectionUtils.GetOppositeDirection(CoDiDirection.West));
            Assert.AreEqual(CoDiDirection.Bottom, CoDiDirectionUtils.GetOppositeDirection(CoDiDirection.Top));
            Assert.AreEqual(CoDiDirection.Top, CoDiDirectionUtils.GetOppositeDirection(CoDiDirection.Bottom));
        }
    }
}