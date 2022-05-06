using System.Collections.Generic;

namespace casim.Drudi.Stats
{
    /// <summary>
    /// Interface used to describe the Automaton's stats.
    /// </summary>
    /// <typeparam name="T">The enumeration which contains the Automaton's state.</typeparam>
    public interface IStats<T>
    {
        /// <summary>
        /// The current iterations' number.
        /// </summary>
        public int Iteration { get; }

        /// <summary>
        /// A <c>Dictionary</c> which map to each cell state the number of alive cell.
        /// </summary>
        public Dictionary<T, int> CellStats { get; }

        /// <summary>
        /// Return a string representation of the stats.
        /// </summary>
        /// <returns>The string representation of the stats.</returns>
        public string ToString();
    }
}