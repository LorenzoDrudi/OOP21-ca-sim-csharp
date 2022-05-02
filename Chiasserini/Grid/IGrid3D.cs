using System;
using Zama.Coordinates;

namespace Chiasserini.Grid
{
    /// <summary>
    /// The 3-dimensional grid.
    /// </summary>
    /// <param name="T">Type of data contained in IGrid3D.</param>
    public interface IGrid3D<T> : IGrid<Coordinates3D, T>
    {
        /// <summary>
        /// Return the depth of the cell.
        /// </summary>
        public int Depth { get; }
        
        /// <summary>
        /// Return the value at given coordinates.
        /// </summary>
        /// <param name="row">The row of the element to get.</param>
        /// <param name="column">The column of the element to get.</param>
        /// <param name="depth">The depth of the element to get.</param>
        public T Get(int row, int column, int depth);
        
        /// <summary>
        /// Return a new IGrid3D applying a mapper function to the elements of grid.
        /// </summary>
        /// <param name="mapper">The map function.</param>
        /// <typeparam name="O">The type if the element of the output grid.</typeparam>
        /// <returns></returns>
        public IGrid3D<O> Map<O>(Func<T, O> mapper);
    }
}