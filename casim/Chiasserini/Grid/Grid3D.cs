using System;
using System.Collections.Generic;
using System.Linq;
using casim.Zama.Coordinates;
using Sanzani.RangeUtils;

namespace casim.Chiasserini.Grid
{
    /// <summary>
    /// The implementation of a Grid3D.
    /// </summary>
    /// <typeparam name="T">Type of data contained in Grid3D.</typeparam>
    public class Grid3D<T> : IGrid3D<T>
    {
        private readonly int _rows;
        private readonly int _columns;
        private readonly int _depth;
        
        private List<List<List<T>>> Grid { get; set; }
        public int Height => _rows;
        public int Width => _columns;
        public int Depth => _depth;

        /// <summary>
        /// Construct a new Grid3D with a function that maps coordinates to values.
        /// </summary>
        /// <param name="rows">the number of the rows of the Grid3D</param>
        /// <param name="columns">the number of the column of the Grid3D</param>
        /// <param name="depth">the depth of the Grid3D</param>
        /// <param name="defaultValue">the function that maps coordinates to value.</param>
        public Grid3D(int rows, int columns, int depth, Func<T> defaultValue)
        {
            _rows = rows;
            _columns = columns;
            _depth = depth;
            Grid = Ranges.Of(0, depth).AsQueryable()
                .Select(z => Ranges.Of(0, rows, 1).AsQueryable()
                .Select(x => Ranges.Of(0, columns, 1).AsQueryable()
                .Select(y => defaultValue.Invoke())
                .ToList())
                .ToList())
                .ToList();
        }
        
        /// <summary>
        /// Construct a new Grid3D with a function that maps coordinates to values.
        /// </summary>
        /// <param name="rows">the number of the rows of the Grid3D</param>
        /// <param name="columns">the number of the column of the Grid3D</param>
        /// <param name="depth">the depth of the Grid3D</param>
        /// <param name="valueFunction">the function that maps coordinates to value.</param>
        public Grid3D(int rows, int columns, int depth, Func<Coordinates3D, T> valueFunction)
        {
            _rows = rows;
            _columns = columns;
            _depth = depth;
            Grid = Ranges.Of(0, depth).AsQueryable()
                .Select(z => Ranges.Of(0, rows, 1).AsQueryable()
                .Select(x => Ranges.Of(0, columns, 1).AsQueryable()
                .Select(y => valueFunction.Invoke(CoordinatesUtil.Of(x, y, z)))
                .ToList())
                .ToList())
                .ToList();
        }
        
        public T Get(Coordinates3D coord)
        {
            return this.Grid[coord.X][coord.Y][coord.Z];
        }

        public void Set(Coordinates3D coord, T value)
        {
            this.Grid[coord.X][coord.Y][coord.Z]=value;
        }
        
        public T Get(int row, int column, int depth)
        {
            return this.Grid[row][column][depth];
        }

        public void Set(int row, int column, int depth, T value)
        {
            this.Grid[row][column][depth]=value;
        }
        
        public bool IsCoordValid(Coordinates3D coord)
        {
            return CoordinatesUtil.IsValid(coord, _rows, _columns, _depth);
        }

        public IQueryable<T> Stream()
        {
            return Grid.AsQueryable().SelectMany(x=>x.AsQueryable().SelectMany(y => y.AsQueryable()));
        }
        public IGrid3D<TOut> MapTo<TOut>(Func<T, TOut> mapper) where TOut : class
        {
            return new Grid3D<TOut>(
                _rows, 
                _columns,
                _depth,
                (coord) => 
                    mapper.Invoke(Get(coord)));
        }
    }
}