using System;
using System.Collections.Generic;
using System.Linq;
using Sanzani.RangeUtils;
using Zama.Coordinates;

namespace casim.Chiasserini.Grid
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

        public void SetRow(int row, int column, List<T> list)
        {
            if (list.Count != this.Width)
            {
                throw new ArgumentException("Wrong list size");
            }
            Ranges.Of(0, list.Count).ToList().ForEach(column => this.Set(row, column, list.ElementAt(column)));
        }
        public T Get(Coordinates2D coord)
        {
            return this.Grid.Get(coord);
        }

        public void Set(Coordinates2D coord, T value)
        {
            this.Grid.Set(coord, value);
        }

        public bool IsCoordValid(Coordinates2D coord)
        {
            return this.Grid.IsCoordValid(coord);
        }

        public IQueryable<T> Stream()
        {
            return this.Grid.Stream();
        }

        public T Get(int row, int column)
        {
            return this.Grid.Get(row, column);
        }

        public void Set(int row, int column, T value)
        {
            this.Grid.Set(row, column, value);
        }

        public IGrid2D<O> MapTo<O>(Func<T, O> mapper) where O : class
        {
            return this.Grid.MapTo(mapper);
        }
    }
}