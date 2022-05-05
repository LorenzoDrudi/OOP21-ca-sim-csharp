using Sanzani.States;
using Zama;

namespace Chiasserini.GameOfLIfe
{
    /// <summary>
    /// Cell of Game Of Life.
    /// </summary>
    public class GameOfLifeCell : AbstractCell<GameOfLifeState>
    {
        /// <summary>
        ///Package-private.
        /// </summary>
        /// <param name="state">the current state of the GameOfLifeCell.</param>
        public GameOfLifeCell(GameOfLifeState state) : base(state){}

    }
}