using System;
using System.Collections.Generic;
using casim.Chiasserini.Grid;
using casim.Zama.Coordinates;

namespace casim.Chiasserini.GameOfLIfe
{
    /// <summary>
    /// The GameOfLife's rule used to update the GameOfLifeCell's state.
    /// </summary>
    public class GameOfLifeUpdateRule
    {
        private Func<Tuple<Coordinates2D, GameOfLifeCell>,
            IGrid<Coordinates2D, GameOfLifeCell>,
            List<Tuple<Coordinates2D, GameOfLifeCell>>> neighborsFunction;
        
        public GameOfLifeUpdateRule(Func<Tuple<Coordinates2D, GameOfLifeCell>,
                                                IGrid<Coordinates2D, GameOfLifeCell>,
                                                List<Tuple<Coordinates2D, GameOfLifeCell>>> neighborsFunction){}
        
        /// <summary>
        /// Return the next neighbor of the cell.
        /// </summary>
        /// <param name="cellTuple">Cell to analyze.</param>
        /// <param name="grid">Grid2D.</param>
        /// <returns>return the next neighbor.</returns>
        public GameOfLifeCell GetNextCell(Tuple<Coordinates2D, GameOfLifeCell> cellTuple, IGrid<Coordinates2D, GameOfLifeCell> grid)
        {
            return this.NextCell(cellTuple, this.neighborsFunction.Invoke(cellTuple, grid));
        }
        
        /// <summary>
        /// Function that analyze the neighbors of the GameOfLifeCell and calculates his next state.
        /// </summary>
        /// <param name="cellTuple">a Tuple that contains the GameOfLifeCell and his Coordinates2D.</param>
        /// <param name="neighborsTuple"> a List of all the GameOfLifeCell neighbors and his Coordinates2D.</param>
        /// <returns></returns>
        private GameOfLifeCell NextCell(Tuple<Coordinates2D, GameOfLifeCell> cellTuple, List<Tuple<Coordinates2D, GameOfLifeCell>> neighborsTuple)
        {
            int aliveCells = this.CountAliveNeighbors(neighborsTuple);

            if (cellTuple.Item2.State == GameOfLifeState.Alive)
            {
                if (aliveCells == 2 || aliveCells == 3)
                {
                    return new GameOfLifeCell(GameOfLifeState.Alive);
                }
                else
                {
                    return new GameOfLifeCell(GameOfLifeState.Dead);
                }
            }
            else
            {
                if (aliveCells == 3)
                {
                    return new GameOfLifeCell(GameOfLifeState.Alive);
                }
                else
                {
                    return new GameOfLifeCell(GameOfLifeState.Dead);
                }
            }
        }

        /// <summary>
        /// Utility function for count the number of neighbors alive of one Cell.
        /// </summary>
        /// <param name="neighborsTuple">an IEnumerable Tuple of GameOfLifeCell and his Coordinates2D.</param>
        /// <returns>count the number of the neighboring cells.</returns>
        private int CountAliveNeighbors(IEnumerable<Tuple<Coordinates2D, GameOfLifeCell>> neighborsTuple)
        {
            int count = 0;
            do
            {
                if (neighborsTuple.GetEnumerator().Current.Item2.State == GameOfLifeState.Alive)
                {
                    count++;
                }
            } while (neighborsTuple.GetEnumerator().MoveNext());

            return count;
        }
       
    }
}