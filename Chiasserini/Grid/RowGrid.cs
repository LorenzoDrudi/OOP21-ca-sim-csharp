using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sanzani.RangeUtils;
using Zama.Coordinates;

namespace Chiasserini.Grid
{
    public class RowGrid<T> : IGrid2D<T> where T : class
    {
        private readonly int _rows;
        private readonly int _columns;
        
        private Grid2D<T> Grid { get; set; }
        public int Height => _rows;
        public int Width => _columns;
        
        internal RowGrid(Grid2D<T> Grid)
        {
            this.Grid = Grid;
        }

        public IList<T> GetRow(int row)
        {
            IList<T> list = new List<T>();
            Ranges.Of(0, this.Width).ToList().ForEach(column => list.Add(this.Get(row, column)));
            return list;
        }
        public T Get(Coordinates2D coord)
        {
            throw new NotImplementedException();
        }

        public void Set(Coordinates2D coord, T value)
        {
            throw new NotImplementedException();
        }

        public bool IsCoordValid(Coordinates2D coord)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Stream()
        {
            throw new NotImplementedException();
        }

        public T Get(int row, int column)
        {
            throw new NotImplementedException();
        }

        public void Set(int row, int column, T value)
        {
            throw new NotImplementedException();
        }

        public IGrid2D<O> MapTo<O>(Func<T, O> mapper) where O : class
        {
            throw new NotImplementedException();
        }
    }
}