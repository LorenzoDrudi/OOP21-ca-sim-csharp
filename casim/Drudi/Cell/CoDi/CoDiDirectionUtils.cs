using System;
using System.Collections.Generic;
using casim.Zama.Coordinates;

namespace casim.Drudi.Cell.CoDi
{
    /// <summary>
    /// Utility method for <see cref="CoDiDirection"/> class.
    /// </summary>
    public static class CoDiDirectionUtils
    {
        private const string NoDirection = "Direction not present!";
        private static readonly Dictionary<CoDiDirection, Coordinates3D> DirectionOffset =
            new Dictionary<CoDiDirection, Coordinates3D>
            {
                {CoDiDirection.North, CoordinatesUtil.Of(0, 0, 1)},
                {CoDiDirection.South, CoordinatesUtil.Of(0, 0, -1)},
                {CoDiDirection.West, CoordinatesUtil.Of(-1, 0, 0)},
                {CoDiDirection.East, CoordinatesUtil.Of(1, 0, 0)},
                {CoDiDirection.Top, CoordinatesUtil.Of(0, 1, 0)},
                {CoDiDirection.Bottom, CoordinatesUtil.Of(0, -1, 0)}
            };

        private static readonly Dictionary<CoDiDirection, CoDiDirection> OppositeDirection =
            new Dictionary<CoDiDirection, CoDiDirection>()
            {
                {CoDiDirection.North, CoDiDirection.South},
                {CoDiDirection.South, CoDiDirection.North},
                {CoDiDirection.West, CoDiDirection.East},
                {CoDiDirection.East, CoDiDirection.West},
                {CoDiDirection.Top, CoDiDirection.Bottom},
                {CoDiDirection.Bottom, CoDiDirection.Top}
            };
        
        /// <summary>
        /// Get the offset related to a <see cref="CoDiDirection"/>.
        /// </summary>
        /// <param name="direction">The direction of which return the offset.</param>
        /// <returns>The offset related to the direction.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static Coordinates3D GetDirectionOffset(CoDiDirection direction)
        {
            CheckDirection(direction);
            return DirectionOffset[direction];
        }

        /// <summary>
        /// Get the opposite <see cref="CoDiDirection"/> to the one take as input.
        /// </summary>
        /// <param name="direction">The direction of which return the opposite.</param>
        /// <returns>The opposite direction to the one taken as input.</returns>
        public static CoDiDirection GetOppositeDirection(CoDiDirection direction)
        {
            CheckDirection(direction);
            return OppositeDirection[direction];
        }

        private static void CheckDirection(CoDiDirection direction)
        {
            if (!DirectionOffset.ContainsKey(direction))
            {
                throw new ArgumentException(NoDirection);
            }
        }
    }
}