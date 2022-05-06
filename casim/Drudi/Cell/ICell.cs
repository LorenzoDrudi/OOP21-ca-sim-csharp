namespace casim.Drudi.Cell
{
    /// <summary>
    /// A cell of the grid.
    /// </summary>
    /// <typeparam name="T">The enumeration which contains the Automaton's state.</typeparam>
    public interface ICell<out T>
    {
        /// <summary>
        /// The current state of the cell.
        /// </summary>
        public T State { get; }
    }
}