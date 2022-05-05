using System.Collections.Generic;
using Zama.Coordinates;

namespace Zama
{
    public class Direction
    {
        public static Direction North { get; } = new Direction(CoordinatesUtil.Of(0, 1));
        public static Direction East { get; } = new Direction(CoordinatesUtil.Of(1, 0));
        public static Direction South { get; } = new Direction(CoordinatesUtil.Of(0, -1));
        public static Direction West { get; } = new Direction(CoordinatesUtil.Of(-1, 0));

        /// <summary>
        /// <see cref="Dictionary{TKey,TValue}"/> of that maps every <see cref="Direction"/>
        /// to it's left and right directions.
        /// </summary>
        public static readonly Dictionary<Direction, (Direction Left, Direction Right)> TurnMap 
            = new Dictionary<Direction, (Direction, Direction)> 
            { 
                [North] = (West, East),
                [East] = (North, South),
                [South] = (East, West),
                [West] = (South, North)
            };

        /// <summary>
        /// Movement information of the <see cref="Direction"/>.
        /// </summary>
        public Coordinates2D MoveInfo { get; }

        private Direction(Coordinates2D moveInfo)
        {
            MoveInfo = moveInfo;
        }
    }
}