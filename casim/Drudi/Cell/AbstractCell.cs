namespace casim.Drudi.Cell
{
    /// <summary>
    /// Abstract implementation of ICell.
    /// </summary>
    /// <typeparam name="T">The enumeration which contains the Automaton's state.</typeparam>
    public abstract class AbstractCell<T>: ICell<T>
    {
        public T State { get; protected set; }

        protected AbstractCell(T state)
        {
            this.State = state;
        }
    }
}