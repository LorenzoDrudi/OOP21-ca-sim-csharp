using casim.Chiasserini.Grid;
using casim.Drudi.Cell;
using casim.Drudi.Stats;
using casim.Zama.Coordinates;

namespace casim.Drudi.Automaton
{
    /// <summary>
    /// An interface which describe an <c>Automaton</c>.
    /// </summary>
    /// <typeparam name="TState">The states of the cells.</typeparam>
    /// <typeparam name="TCell">The cell implementation used by the Automaton.</typeparam>
    public interface IAutomaton<TCell, TState> where TCell:AbstractCell<TState>
    {
        /// <summary>
        /// Get the grid describing the current <c>Automaton</c> state.
        /// </summary>
        public IGrid<Coordinates2D, TCell> Grid { get; }

        /// <summary>
        /// Get the <see cref="IStats{T}"/> about the <c>Automaton</c>.
        /// </summary>
        public IStats<TState> Stats { get;  }

        /// <summary>
        /// Returns true if the <c>Automaton</c> can do a new step.
        /// </summary>
        /// <returns>True if there's a new admissible state.</returns>
        public bool HasNext();

        /// <summary>
        /// Compute and return the new state of the <c>Automaton.</c>
        /// </summary>
        /// <returns>The new state of the <c>Automaton.</c></returns>
        public IGrid<Coordinates2D, TCell> Next();
    }
}