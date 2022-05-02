namespace Zama
{
    /// <summary>
    /// Abstract implementation of ICell.
    /// This cell war copied from Lorenzo Drudi's implementation.
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