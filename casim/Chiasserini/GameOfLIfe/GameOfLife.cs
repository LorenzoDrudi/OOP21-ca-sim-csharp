using casim.Chiasserini.Grid;
using casim.Drudi.AbstractionUtils;
using casim.Drudi.Automaton;
using casim.Zama.Coordinates;

namespace casim.Chiasserini.GameOfLIfe
{
    /// <summary>
    /// Class that models the Game Of Life.
    /// </summary>
    public class GameOfLife : Automaton<GameOfLifeCell, GameOfLifeState>
    {
        private Grid2D<GameOfLifeCell> state;
        private GameOfLifeUpdateRule updateRule = new GameOfLifeUpdateRule(
                    NeighborsFunctions.MooreNeighborsFunction<GameOfLifeCell, GameOfLifeState>);
        
        public GameOfLife(IGrid<Coordinates2D, GameOfLifeCell> grid) : base(grid)
        {
        }

        /// <summary>
        /// hasNext method.
        /// </summary>
        /// <returns>always true.</returns>
        public override bool HasNext()
        {
            return true;
        }

        /// <summary>
        /// Function that advances of one step according to the GameOfLife's rules.
        /// </summary>
        /// <returns>the new state of the cell.</returns>
        protected override IGrid<Coordinates2D, GameOfLifeCell> DoStep()
        {
            var newState = new Grid2D<GameOfLifeCell>(this.state.Height, this.state.Width, ()=> null);

            for (int x = 0; x <  this.state.Height; x++)
            {
                for (int y = 0; y < this.state.Width; y++)
                {
                    var coord = CoordinatesUtil.Of(x, y);
                    newState.Set(coord, this.updateRule.GetNextCell(Tuple.Create(coord, this.state.Get(coord)), this.state));
                }
            }

            this.state = newState;
            return this.state;
        }

        
    }
}