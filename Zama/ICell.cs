namespace Zama
{
    /// <summary>
    /// A cell of the grid.
    /// This interface was copied from Lorenzo Drudi's implementation.
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