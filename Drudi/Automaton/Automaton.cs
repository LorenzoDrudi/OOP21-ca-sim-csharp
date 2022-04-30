using System.Collections.Generic;

namespace Drudi.Automaton
{
    public abstract class Automaton<TState, TGrid> : IAutomaton<TState, TGrid>
    {
        private int IterationCounter { get; set; }
        public TGrid Grid { get; }

        protected Automaton(TGrid grid)
        {
            this.Grid = grid;
        }

        //public Stats<TState> Stats => new Stats<TState>(IterationCounter, CreateStatesMap());

        public abstract bool HasNext();

        public TGrid Next()
        {
            this.IterationCounter++;
            return DoStep();
        }

        /// <summary>
        /// Method used to obtain the next <see cref="Automaton{TState,TGrid}"/> step.
        /// </summary>
        /// <returns>A grid describing the next step.</returns>
        protected abstract TGrid DoStep();
        //TODO
        //protected Dictionary<TState, int> CreateStatesMap()
        //{
        //    return Grid;
        //}
    }
}