using System;
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
        /// Returns an array containing all the <see cref="Direction"/>s.
        /// </summary>
        public static Direction[] Values { get; } = new[] { North, East, South, West };

        /// <summary>
        /// Movement information of the <see cref="Direction"/>.
        /// </summary>
        public Coordinates2D MoveInfo { get; }
    
        /// <summary>
        /// Returns the index of the <see cref="Direction"/> in the
        /// Values array.
        /// </summary>
        public int Ordinal => Array.IndexOf(Values, this);

        private Direction(Coordinates2D moveInfo) => MoveInfo = moveInfo;
    }
}