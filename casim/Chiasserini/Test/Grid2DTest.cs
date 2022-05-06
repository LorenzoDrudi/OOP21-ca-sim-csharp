using casim.Chiasserini.Grid;
using casim.Zama.Coordinates;
using NUnit.Framework;

namespace casim.Chiasserini.Test
{
    /// <summary>
    /// Test for Grid2D.
    /// </summary>
    public class Grid2DTest
    {
        private const int Rows = 3;
        private const int Columns = 2;
        private const int X = 0;
        private const int Y = 1;
        private const int NewValue = 2;
        private const int DefaultValue = 1;
        
        private Grid2D<int> TestGetGrid()
        {
            return new Grid2D<int>(Rows, Columns, () => DefaultValue);
        }
        
        private Grid2D<int> TestGridWithValues()
        {
            var grid = TestGetGrid();
            for(var x=0; x<Rows;x++)
            {
                for (int y = 0; y < Columns; y++)
                {
                    grid.Set(x, y, x+y);
                }
            }
            return grid;
        }

        [Test]
        public void TestGetWithInt()
        {
            var grid = TestGetGrid();
            Assert.DoesNotThrow(()=>grid.Set(X,Y,NewValue));
            Assert.AreEqual(NewValue, grid.Get(X, Y));
            Assert.Throws(typeof(IndexOutOfRangeException), ()=> grid.Get(X, Columns));
            Assert.Throws(typeof(IndexOutOfRangeException), ()=> grid.Get(Rows, Y));
        }
        
        [Test]
        public void TestGetWithCoordinates()
        {
            var coord = CoordinatesUtil.Of(X, Y);
            var grid = TestGetGrid();
            Assert.DoesNotThrow(()=>grid.Set(coord, NewValue));
            Assert.AreEqual(NewValue, grid.Get(coord));
            Assert.Throws(typeof(IndexOutOfRangeException), ()=> grid.Get(CoordinatesUtil.Of(X, Columns)));
            Assert.Throws(typeof(IndexOutOfRangeException), ()=> grid.Get(CoordinatesUtil.Of(Rows, Y)));
        }
        
        [Test]
        public void TestGetHeight()
        {
            Assert.AreEqual(Rows, TestGetGrid().Height);
        }
        
        [Test]
        public void TestGetWidth()
        {
            Assert.AreEqual(Columns, TestGetGrid().Width);
        }

        [Test]
        public void TestIsCoordValid()
        {
            var grid = TestGetGrid();
            for(var x=0; x<Rows;x++)
            {
                for (int y = 0; y < Columns; y++)
                {
                    Assert.True(grid.IsCoordValid(CoordinatesUtil.Of(x, y)));
                }
            }
            Assert.False(grid.IsCoordValid(CoordinatesUtil.Of(-1, 0)));
            Assert.False(grid.IsCoordValid(CoordinatesUtil.Of(0, -1)));
            Assert.False(grid.IsCoordValid(CoordinatesUtil.Of(-1, -1)));
            Assert.False(grid.IsCoordValid(CoordinatesUtil.Of(Rows, 0)));
            Assert.False(grid.IsCoordValid(CoordinatesUtil.Of(0, Columns)));
            Assert.False(grid.IsCoordValid(CoordinatesUtil.Of(Rows, Columns)));
        }

        [Test]
        public void TestSetWithInt()
        {
            var grid = TestGetGrid();
            Assert.DoesNotThrow(()=>grid.Set(X, Y, NewValue));
            Assert.AreEqual(NewValue, grid.Get(X, Y));
            Assert.Throws(typeof(IndexOutOfRangeException), ()=> grid.Set(X, Columns, NewValue));
            Assert.Throws(typeof(IndexOutOfRangeException), ()=> grid.Set(Rows, Y, NewValue));
        }
        
        [Test]
        public void TestSetWithCoordinates()
        {
            var coord = CoordinatesUtil.Of(X, Y);
            var grid = TestGetGrid();
            Assert.DoesNotThrow(()=>grid.Set(coord, NewValue));
            Assert.AreEqual(NewValue, grid.Get(coord));
            Assert.Throws(typeof(IndexOutOfRangeException), ()=> grid.Set(CoordinatesUtil.Of(X, Columns), NewValue));
            Assert.Throws(typeof(IndexOutOfRangeException), ()=> grid.Set(CoordinatesUtil.Of(Rows, Y), NewValue));
        }

        [Test]
        public void TestStream()
        {
            var grid = TestGridWithValues();
            var elements = new HashSet<int>();
            for(var x=0; x<Rows;x++)
            {
                for (int y = 0; y < Columns; y++)
                {
                    elements.Add(grid.Get(x, y));
                }
            }

            Assert.AreEqual(elements, grid.Stream());
        }
    }

}