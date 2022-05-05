using System;
using System.Collections.Generic;
using System.Linq;
using Zama.Coordinates;
using Sanzani.RangeUtils;

namespace Chiasserini.Grid
{
    /// <summary>
    /// The implementation of a Grid2D.
    /// </summary>
    /// <typeparam name="T">Type of data contained in Grid2D.</typeparam>
    public class Grid2D<T> : IGrid2D<T> where T : class
    {
        private readonly int _rows;
        private readonly int _columns;
        
        private List<List<T>> Grid { get; set; }
        public int Height => _rows;
        public int Width => _columns;
        
        
        /// <summary>
        /// Construct a new Grid2D filled with nulls.
        /// </summary>
        /// <param name="rows">the number of the rows of the Grid2D</param>
        /// <param name="columns">the number of the columns of the Grid2D</param>
        internal Grid2D(int rows, int columns) : this(rows, columns, (x) => null) 
        {
        }
        
        /// <summary>
        /// Construct a new Grid2D with a function that maps coordinates to values.
        /// </summary>
        /// <param name="rows">the number of the rows of the Grid2D</param>
        /// <param name="columns">the number of the columns of the Grid2D</param>
        /// <param name="defaultValue">the function that maps coordinates to value.</param>
        public Grid2D(int rows, int columns, Func<T> defaultValue)
        {
            _rows = rows;
            _columns = columns;
            Grid = Ranges.Of(0, rows).AsQueryable()
                .Select(x => Ranges.Of(0, columns, 1).AsQueryable()
                .Select(y => defaultValue.Invoke())
                .ToList())
                .ToList();
        }

        /// <summary>
        /// Construct a new Grid2D with a function that maps coordinates to values.
        /// </summary>
        /// <param name="rows">the number of the rows of the Grid2D</param>
        /// <param name="columns">the number of the columns of the Grid2D</param>
        /// <param name="valueFunction">the function that maps coordinates to value.</param>
        public Grid2D(int rows, int columns, Func<Coordinates2D, T> valueFunction)
        {
            _rows = rows;
            _columns = columns;
            Grid = Ranges.Of(0, rows).AsQueryable()
                .Select(x => Ranges.Of(0, columns, 1).AsQueryable()
                .Select(y => valueFunction.Invoke(CoordinatesUtil.Of(x, y)))
                .ToList())
                .ToList();
        }

        public T Get(Coordinates2D coord)
        {
            return this.Grid[coord.X][coord.Y];
        }

        public void Set(Coordinates2D coord, T value)
        {
            this.Grid[coord.X][coord.Y]=value;
        }

        public T Get(int row, int column)
        {
            return this.Grid[row][column];
        }

        public void Set(int row, int column, T value)
        {
            this.Grid[row][column]=value;
        }

        public bool IsCoordValid(Coordinates2D coord)
        {
            return CoordinatesUtil.IsValid(coord, _rows, _columns);
        }

        public IQueryable<T> Stream()
        {
            return Grid.AsQueryable().SelectMany(x => x.AsQueryable());
        }

        public IGrid2D<O> MapTo<O>(Func<T, O> mapper) where O : class
        {
            return new Grid2D<O>(
                _rows, 
                _columns, 
                (coord) => 
                    mapper.Invoke(Get(coord)));
        }
    }
}