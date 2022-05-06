using System.Collections.Generic;
using System.Linq;
using casim.Zama.Coordinates;
using NUnit.Framework;

namespace casim.Zama.Test
{
    [TestFixture]
    public class CoordinatesUtilTest
    {
        private static readonly List<Coordinates2D> Neighbors2D = new List<Coordinates2D> 
        { 
            CoordinatesUtil.Of(1, 0), CoordinatesUtil.Of(0, 1), 
            CoordinatesUtil.Of(-1, 0), CoordinatesUtil.Of(0, -1)
        };
        private static readonly Coordinates2D BottomRight2D = CoordinatesUtil.Of(30, 28);
        private static readonly Coordinates2D TopLeft2D = CoordinatesUtil.Of(2, 5);
        private static readonly List<Coordinates3D> Neighbors3D = new List<Coordinates3D>
        {
            CoordinatesUtil.Of(1, 0, 0), CoordinatesUtil.Of(0, 1, 0), CoordinatesUtil.Of(0, 0, 1),
            CoordinatesUtil.Of(-1, 0, 0), CoordinatesUtil.Of(0, -1, 0), CoordinatesUtil.Of(0, 0, -1)
        };
        private static readonly Coordinates3D BottomRight3D = CoordinatesUtil.Of(30, 24, 49);
        private static readonly Coordinates3D TopLeft3D = CoordinatesUtil.Of(2, 5, 3);

        [Test]
        public void TestIsValid2D()
        {
            var coord01 = CoordinatesUtil.Of(10, 7);
            var coord02 = CoordinatesUtil.Of(39, 20);
            Assert.True(CoordinatesUtil.IsValid(coord01, TopLeft2D, BottomRight2D));
            Assert.False(CoordinatesUtil.IsValid(coord02, TopLeft2D, BottomRight2D));
        }

        [Test]
        public void TestIsValid2DWithOneCoord()
        {
            var coord01 = CoordinatesUtil.Of(10, 6);
            var coord02 = CoordinatesUtil.Of(-20, 3);
            Assert.True(CoordinatesUtil.IsValid(coord01, BottomRight2D));
            Assert.False(CoordinatesUtil.IsValid(coord02, BottomRight2D));
        }

        [Test]
        public void TestIsValid2DWithNumbers()
        {
            var coord01 = CoordinatesUtil.Of(10, 6);
            var coord02 = CoordinatesUtil.Of(-24, 9);
            Assert.True(CoordinatesUtil.IsValid(coord01, BottomRight2D.X, BottomRight2D.Y));
            Assert.False(CoordinatesUtil.IsValid(coord02, BottomRight2D.X, BottomRight2D.Y));
        }

        [Test]
        public void TestGet2DNeighbors() => 
            Assert.AreEqual(Neighbors2D.Select(x => x + BottomRight2D),
                CoordinatesUtil.Get2DNeighbors(BottomRight2D));

        [Test]
        public void TestIsValid3D()
        {
            var coord01 = CoordinatesUtil.Of(10, 20, 14);
            var coord02 = CoordinatesUtil.Of(28, 48, 12);
            Assert.True(CoordinatesUtil.IsValid(coord01, TopLeft3D, BottomRight3D));
            Assert.False(CoordinatesUtil.IsValid(coord02, TopLeft3D, BottomRight3D));
        }

        [Test]
        public void TestIsValid3DWithOneCoord()
        {
            var coord01 = CoordinatesUtil.Of(10, 6, 4);
            var coord02 = CoordinatesUtil.Of(-20, 12, -9);
            Assert.True(CoordinatesUtil.IsValid(coord01, BottomRight3D));
            Assert.False(CoordinatesUtil.IsValid(coord02, BottomRight3D));
        }

        [Test]
        public void TestIsValid3DWithNumbers()
        {
            var coord01 = CoordinatesUtil.Of(10, 5, 12);
            var coord02 = CoordinatesUtil.Of(-21, 50, 12);
            Assert.True(CoordinatesUtil.IsValid(coord01, BottomRight3D.X, BottomRight3D.Y, BottomRight3D.Z));
            Assert.False(CoordinatesUtil.IsValid(coord02, BottomRight3D.X, BottomRight3D.Y, BottomRight3D.Z));
        }

        [Test]
        public void TestGet3DNeighbors()
        {
            Assert.AreEqual(Neighbors3D.Select(x => x + BottomRight3D),
                CoordinatesUtil.Get3DNeighbors(BottomRight3D));
        }
    }
}