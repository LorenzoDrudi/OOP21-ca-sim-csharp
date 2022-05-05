using Zama.Coordinates;

namespace Zama.LangtonsAnt
{
    public class Ant
    {
        public Coordinates2D Position { get; set; }
        public Direction Facing { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Ant"/> class.
        /// </summary>
        /// <param name="position">the position of the ant</param>
        /// <param name="facing">the direction of the ant</param>
        public Ant(Coordinates2D position, Direction facing)
        {
            Position = position;
            Facing = facing;
        }

        /// <summary>
        /// Moves the <see cref="Ant"/> by changing it's position based on it's current facing <see cref="Direction"/>.
        /// </summary>
        public void Move() => Position += Facing.MoveInfo;

        /// <summary>
        /// Changes the direction of the <see cref="Ant"/> based on the value of <see cref="state"/>.
        /// On -> turns left
        /// Off -> turns right
        /// </summary>
        /// <param name="state">current <see cref="LangtonsAntCellState"/> of the cell
        ///         the ant is on.</param>
        public void Turn(LangtonsAntCellState state)
        {
            Facing = state == LangtonsAntCellState.Off ? Direction.TurnMap[Facing].Right : Direction.TurnMap[Facing].Left;
        }
    }
}