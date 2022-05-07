using casim.Zama.Coordinates;

namespace casim.Chiasserini.Grid
{
    /// <summary>
    /// The bi-dimensional grid.
    /// </summary>
    /// <typeparam name="T">Type of data contained in IGrid2D.</typeparam>
    public interface IGrid2D<T> : IGrid<Coordinates2D, T>
    {
        /// <summary>
        /// Return the value at given coordinates.
        /// </summary>
        /// <param name="row">The row of the element to get.</param>
        /// <param name="column">The column of the element to get.</param>
        public T Get(int row, int column);
        
        /// <summary>
        /// Set an element to a given coordinates.
        /// </summary>
        /// <param name="row">The row of the element to set.</param>
        /// <param name="column">The column of the element to set.</param>
        /// <param name="value">The value to set.</param>
        public void Set(int row, int column, T value);
        
        /// <summary>
        /// Return a new IGrid2D applying a mapper function to the elements of grid.
        /// </summary>
        /// <param name="mapper">The map function.</param>
        /// <typeparam name="TOut">The type if the element of the output grid.</typeparam>
        /// <returns></returns>
        public IGrid2D<TOut> MapTo<TOut>(Func<T, TOut> mapper) where TOut : class;
    }
}