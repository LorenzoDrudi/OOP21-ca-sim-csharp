using System;
using System.Collections.Generic;
using Chiasserini.Grid;
using NUnit.Framework;
using Zama.Coordinates;

namespace Chiasserini.Test
{
    /// <summary>
    /// Test for Grid3D.
    /// </summary>
    public class Grid3DTest
    {
        private const int Rows = 3;
        private const int Columns = 2;
        private const int Depth = 2;
        private const int X = 0;
        private const int Y = 1;
        private const int Z = 1;
        private const int NewValue = 2;
        private const int DefaultValue = 1;

        private Grid3D<int> TestGetGrid()
        {
            return new Grid3D<int>(Rows, Columns,Depth, () => DefaultValue);
        }
        
        private Grid3D<int> TestGridWithValues()
        {
            var grid = TestGetGrid();
            for(var x=0; x<Rows;x++)
            {
                for (int y = 0; y < Columns; y++)
                {
                    for (int z = 0; z < Depth; z++)
                    { 
                        grid.Set(x, y, z,x+y+z); 
                    }
                }
            }
            return grid;
        }
        
        [Test]
        public void TestGetWithInt()
        {
            var grid = TestGetGrid();
            Assert.DoesNotThrow(()=>grid.Set(X,Y,Z,NewValue));
            Assert.AreEqual(NewValue, grid.Get(X, Y,Z));
            Assert.Throws(typeof(IndexOutOfRangeException), ()=> grid.Get(X, Columns,Z));
            Assert.Throws(typeof(IndexOutOfRangeException), ()=> grid.Get(Rows, Y,Z));
            Assert.Throws(typeof(IndexOutOfRangeException), ()=> grid.Get(X, Y,Depth));
        }
        
        [Test]
        public void TestGetWithCoordinates()
        {
            var coord = CoordinatesUtil.Of(X, Y,Z);
            var grid = TestGetGrid();
            Assert.DoesNotThrow(()=>grid.Set(coord, NewValue));
            Assert.AreEqual(NewValue, grid.Get(coord));
            Assert.Throws(typeof(IndexOutOfRangeException), ()=> grid.Get(CoordinatesUtil.Of(X, Columns,Z)));
            Assert.Throws(typeof(IndexOutOfRangeException), ()=> grid.Get(CoordinatesUtil.Of(Rows, Y,Z)));
            Assert.Throws(typeof(IndexOutOfRangeException), ()=> grid.Get(CoordinatesUtil.Of(X, Y,Depth)));
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
        public void TestGetDepth()
        {
            Assert.AreEqual(Depth, TestGetGrid().Depth);
        }
        
        [Test]
        public void TestIsCoordValid()
        {
            var grid = TestGetGrid();
            for(var x=0; x<Rows;x++)
            {
                for (int y = 0; y < Columns; y++)
                {
                    for (int z = 0; z < Depth; z++)
                    {
                        Assert.True(grid.IsCoordValid(CoordinatesUtil.Of(x, y, z)));
                    }
                }
            }
            Assert.False(grid.IsCoordValid(CoordinatesUtil.Of(-1, 0, 0)));
            Assert.False(grid.IsCoordValid(CoordinatesUtil.Of(0, -1, 0)));
            Assert.False(grid.IsCoordValid(CoordinatesUtil.Of(0, 0, -1)));
            Assert.False(grid.IsCoordValid(CoordinatesUtil.Of(-1, -1, 0)));
            Assert.False(grid.IsCoordValid(CoordinatesUtil.Of(-1, 0, -1)));
            Assert.False(grid.IsCoordValid(CoordinatesUtil.Of(0, -1, -1)));
            Assert.False(grid.IsCoordValid(CoordinatesUtil.Of(-1, -1, -1)));
            Assert.False(grid.IsCoordValid(CoordinatesUtil.Of(Rows, 0, 0)));
            Assert.False(grid.IsCoordValid(CoordinatesUtil.Of(0, Columns, 0)));
            Assert.False(grid.IsCoordValid(CoordinatesUtil.Of(0, 0, Depth)));
            Assert.False(grid.IsCoordValid(CoordinatesUtil.Of(Rows, 0, Depth)));
            Assert.False(grid.IsCoordValid(CoordinatesUtil.Of(Rows, Columns, 0)));
            Assert.False(grid.IsCoordValid(CoordinatesUtil.Of(0, Columns, Depth)));
            Assert.False(grid.IsCoordValid(CoordinatesUtil.Of(Rows, Columns, Depth)));
        }
        
        [Test]
        public void TestSetWithInt()
        {
            var grid = TestGetGrid();
            Assert.DoesNotThrow(()=>grid.Set(X, Y, Z,NewValue));
            Assert.AreEqual(NewValue, grid.Get(X, Y,Z));
            Assert.Throws(typeof(IndexOutOfRangeException), () => grid.Set(X, Columns, Z,NewValue));
            Assert.Throws(typeof(IndexOutOfRangeException), ()=> grid.Set(Rows, Y, Z,NewValue));
            Assert.Throws(typeof(IndexOutOfRangeException), ()=> grid.Set(X, Y, Depth,NewValue));
        }
        
        [Test]
        public void TestSetWithCoordinates()
        {
            var coord = CoordinatesUtil.Of(X, Y, Z);
            var grid = TestGetGrid();
            Assert.DoesNotThrow(()=>grid.Set(coord, NewValue));
            Assert.AreEqual(NewValue, grid.Get(coord));
            Assert.Throws(typeof(IndexOutOfRangeException), () => grid.Set(CoordinatesUtil.Of(X, Columns, Z), NewValue));
            Assert.Throws(typeof(IndexOutOfRangeException), ()=> grid.Set(CoordinatesUtil.Of(Rows, Y, Z),NewValue));
            Assert.Throws(typeof(IndexOutOfRangeException), ()=> grid.Set(CoordinatesUtil.Of(X, Y, Depth),NewValue));
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
                    for (int z = 0; z < Depth; z++)
                    {
                        elements.Add(grid.Get(x, y, z));
                    }
                }
            }
            Assert.AreEqual(elements, grid.Stream());
        }
    }
}