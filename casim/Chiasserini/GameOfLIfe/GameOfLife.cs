using casim.Chiasserini.Grid;
using Drudi.Automaton;

namespace casim.Chiasserini.GameOfLIfe
{
    public class GameOfLife : Automaton<GameOfLifeCell, GameOfLifeState>
    {
        private Grid2D<GameOfLifeCell> state;
        private GameOfLifeUpdateRule updateRule = new GameOfLifeUpdateRule();
        
        public GameOfLife(IGrid<Coordinates2D, GameOfLifeCell> grid) : base(grid)
        {
        }

        public override bool HasNext()
        {
            throw new System.NotImplementedException();
        }

        protected override IGrid<Coordinates2D, TCell> DoStep()
        {
            throw new System.NotImplementedException();
        }

        
    }
}