using System;
using System.Collections.Generic;
using System.Linq;

namespace Zama.Coordinates
{
    public static class CoordinatesUtil
    {
        public static Coordinates2D Of(int x, int y) => new Coordinates2D(x, y);

        public static bool IsValid(Coordinates2D coord, Coordinates2D topLeft, Coordinates2D bottomRight) =>
            coord.X.CompareTo(topLeft.X) >= 0 && coord.Y.CompareTo(topLeft.Y) >= 0
                                              && coord.X.CompareTo(bottomRight.X) < 0
                                              && coord.Y.CompareTo(bottomRight.Y) < 0;

        public static bool IsValid(Coordinates2D coord, Coordinates2D bottomRight) =>
            IsValid(coord, Of(0, 0), bottomRight);

        public static bool IsValid(Coordinates2D coord, int maxX, int maxY) =>
            IsValid(coord, Of(maxX, maxY));

        public static List<Coordinates2D> Get2DNeighbors(Coordinates2D coord) =>
            new List<Coordinates2D> {Of(1, 0), Of(0, 1), Of(-1, 0), Of(0, -1)}
                .Select(n => n + coord)
                .ToList();

        public static Coordinates2D random(int maxX, int maxY) =>
            Of(new Random().Next(0, maxX), new Random().Next(0, maxY));
    }
}