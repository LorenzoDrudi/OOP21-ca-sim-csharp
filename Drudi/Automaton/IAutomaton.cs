namespace Drudi.Automaton
{
    /// <summary>
    /// An interface which describe an <c>Automaton</c>.
    /// </summary>
    /// <typeparam name="TState">The states of the cells.</typeparam>
    /// <typeparam name="TGrid">The <see cref="Cell"/> implementation used by the <c>Automaton.</c></typeparam>
    public interface IAutomaton<TState, out TGrid>
    {
        /// <summary>
        /// Get the grid describing the current <c>Automaton</c> state.
        /// </summary>
        public TGrid Grid { get; }

        /// <summary>
        /// Get the <see cref="IStats"/> about the <c>Automaton</c>.
        /// </summary>
        //public Stats<TState> Stats { get;  }

        /// <summary>
        /// Returns true if the <c>Automaton</c> can do a new step.
        /// </summary>
        /// <returns>True if there's a new admissible state.</returns>
        public bool HasNext();

        /// <summary>
        /// Compute and return the new state of the <c>Automaton.</c>
        /// </summary>
        /// <returns>The new state of the <c>Automaton.</c></returns>
        public TGrid Next();
    }
}