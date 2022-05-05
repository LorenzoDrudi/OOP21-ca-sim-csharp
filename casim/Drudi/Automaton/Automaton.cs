using System.Collections.Generic;
using System.Linq;
using Chiasserini.Grid;
using Drudi.Cell;
using Drudi.Stats;
using Zama.Coordinates;

namespace Drudi.Automaton
{
    public abstract class Automaton<TCell, TState> : IAutomaton<TCell, TState> where TCell : AbstractCell<TState>
    {
        private int IterationCounter { get; set; }
        
        public IGrid<Coordinates2D, TCell> Grid { get; }

        protected Automaton(IGrid<Coordinates2D, TCell> grid)
        {
            this.Grid = grid;
        }

        public IStats<TState> Stats => new Stats<TState>(IterationCounter, CreateStatesMap());

        public abstract bool HasNext();

        public IGrid<Coordinates2D, TCell> Next()
        {
            this.IterationCounter++;
            return DoStep();
        }

        /// <summary>
        /// Method used to obtain the next <see cref="Automaton{TState,TGrid}"/> step.
        /// </summary>
        /// <returns>A grid describing the next step.</returns>
        protected abstract IGrid<Coordinates2D, TCell> DoStep();
        
        protected Dictionary<TState, int> CreateStatesMap()
        {
            return this.Grid.Stream()
                .GroupBy(e => e.State)
                .Select(e => new {Value = e.Key, Count = e.Count()})
                .ToDictionary(e => e.Value, e => e.Count);
        }
    }
}