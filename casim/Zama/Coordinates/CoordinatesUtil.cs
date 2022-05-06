using System;
using System.Collections.Generic;
using System.Linq;

namespace casim.Zama.Coordinates
{
    /// <summary>
    /// Ulitily class for <see cref="Coordinates2D"/> and <see cref="Coordinates3D"/>.
    /// </summary>
    public static class CoordinatesUtil
    {
        /// <summary>
        /// Creates a <see cref="Coordinates2D"/>.
        /// </summary>
        /// <param name="x">value to be used as coordinate x.</param>
        /// <param name="y">value to be used as coordinate y.</param>
        /// <returns></returns> a <see cref="Coordinates2D"/> with argument values.
        public static Coordinates2D Of(int x, int y) => new Coordinates2D(x, y);

        /// <summary>
        /// Checks if a given <see cref="Coordinates2D"/> is valid based
        /// on limits imposed by the rectangle formed by two other <see cref="Coordinates2D"/>
        /// </summary>
        /// <param name="coord">the coord to test.</param>
        /// <param name="topLeft">the top left angle.</param>
        /// <param name="bottomRight">the bottom right angle.</param>
        /// <returns>true if coord is inside the given limits, false otherwise.</returns>
        public static bool IsValid(Coordinates2D coord, Coordinates2D topLeft, Coordinates2D bottomRight) =>
            coord.X.CompareTo(topLeft.X) >= 0 &&
            coord.Y.CompareTo(topLeft.Y) >= 0 &&
            coord.X.CompareTo(bottomRight.X) < 0 &&
            coord.Y.CompareTo(bottomRight.Y) < 0;

        /// <summary>
        /// Checks if the given <see cref="Coordinates2D"/> is inside the rectangle
        /// formed by (0, 0) as the top left angle and a given <see cref="Coordinates2D"/>
        /// as the bottom right angle.
        /// </summary>
        /// <param name="coord">the <see cref="Coordinates2D"/> to test.</param>
        /// <param name="bottomRight">the bottom right angle.</param>
        /// <returns>true if coord is inside the given limits, false otherwise.</returns> 
        public static bool IsValid(Coordinates2D coord, Coordinates2D bottomRight) =>
            IsValid(coord, Of(0, 0), bottomRight);

        /// <summary>
        /// Checks if the <see cref="Coordinates2D"/> given as argument has values
        /// within the given limits.
        /// </summary>
        /// <param name="coord"> the <see cref="Coordinates2D"/> to test.</param>
        /// <param name="maxX">the maximum value the X coordinate can be.</param>
        /// <param name="maxY">the maximum value the Y coordinate can be.</param>
        /// <returns></returns>
        public static bool IsValid(Coordinates2D coord, int maxX, int maxY) =>
            IsValid(coord, Of(maxX, maxY));

        /// <summary>
        /// Returns the Von Neumann's neighbors of the <see cref="Coordinates2D"/>
        /// given as argument.
        /// </summary>
        /// <param name="coord">the <see cref="Coordinates2D"/> of which
        ///     to calculate the neighbors</param> 
        /// <returns>a <see cref="List{Coordinates2D}"/> composed of the neighbors of
        ///     the argument <see cref="Coordinates2D"/>.</returns> 
        public static List<Coordinates2D> Get2DNeighbors(Coordinates2D coord) =>
            new List<Coordinates2D> { Of(1, 0), Of(0, 1), Of(-1, 0), Of(0, -1) }
                .Select(n => n + coord)
                .ToList();

        /// <summary>
        /// Returns a <see cref="Coordinates2D"/> with random values between 0
        /// (inclusive) and <see cref="maxX"/> and <see cref="maxY"/> respectively. 
        /// </summary>
        /// <param name="maxX">the upper limit of the X coordinate must be >= 0.</param>
        /// <param name="maxY">the upper limit of the Y coordinate must be >= 0.</param>
        /// <returns>a new <see cref="Coordinates2D"/> with random values
        ///     within given limits.</returns>
        public static Coordinates2D Random(int maxX, int maxY) =>
            Of(new Random().Next(maxX), new Random().Next(maxY));

        /// <summary>
        /// Creates a <see cref="Coordinates3D"/>.
        /// </summary>
        /// <param name="x">the value to be used as the x coordinate.</param>
        /// <param name="y">the value to be used as the y coordinate.</param>
        /// <param name="z">the value to be used as the z coordinate.</param>
        /// <returns>a <see cref="Coordinates3D"/> with argument values.</returns>
        public static Coordinates3D Of(int x, int y, int z) => new Coordinates3D(x, y, z);

        /// <summary>
        /// Checks if <see cref="coord"/> is inside the rectangle formed by
        /// <see cref="topLeft"/> and <see cref="bottomRight"/>.
        /// </summary>
        /// <param name="coord">the <see cref="Coordinates3D"/> to test.</param>
        /// <param name="topLeft">the top left angle of the rectangle.</param>
        /// <param name="bottomRight">the bottom right angle of the rectangle.</param>
        /// <returns>true if <see cref="coord"/> is inside the limits, false otherwise.</returns>
        public static bool IsValid(Coordinates3D coord, Coordinates3D topLeft, Coordinates3D bottomRight) =>
            coord.X.CompareTo(topLeft.X) >= 0 && coord.Y.CompareTo(topLeft.Y) >= 0 &&
            coord.Z.CompareTo(topLeft.Z) >= 0 && coord.X.CompareTo(bottomRight.X) < 0 &&
            coord.Y.CompareTo(bottomRight.Y) < 0 && coord.Z.CompareTo(bottomRight.Z) < 0;

        /// <summary>
        /// Checks if <see cref="coord"/> is inside the rectangle formed by
        /// <see cref="bottomRight"/> and (0, 0, 0) as the top left angle.
        /// </summary>
        /// <param name="coord">the <see cref="Coordinates3D"/> to test.</param>
        /// <param name="bottomRight">the bottom right angle of the rectangle.</param>
        /// <returns>true if <see cref="coord"/> is inside the limits, false otherwise.</returns>
        public static bool IsValid(Coordinates3D coord, Coordinates3D bottomRight) =>
            IsValid(coord, Of(0, 0, 0), bottomRight);

        /// <summary>
        /// Checks the values of <see cref="coord"/> are less than <see cref="maxX"/>,
        /// <see cref="maxY"/> and <see cref="maxZ"/> respectively.
        /// </summary>
        /// <param name="coord">the <see cref="Coordinates3D"/> to test.</param>
        /// <param name="maxX">the upper limit of the X coordinate.</param>
        /// <param name="maxY">the upper limit of the Y coordinate.</param>
        /// <param name="maxZ">the upper limit of the Z coordinate.</param>
        /// <returns>true if all the limits are respected, false otherwise.</returns>
        public static bool IsValid(Coordinates3D coord, int maxX, int maxY, int maxZ) =>
            IsValid(coord, Of(maxX, maxY, maxZ));

        /// <summary>
        /// Returns the Von Neumann's neighbors of <see cref="coord"/>.
        /// </summary>
        /// <param name="coord">the <see cref="Coordinates2D"/> of which
        ///     to calculate the neighbors.</param>
        /// <returns>a <see cref="List{Coordinates3D}"/> containing the
        ///     neighbors of <see cref="coord"/>.</returns>
        public static List<Coordinates3D> Get3DNeighbors(Coordinates3D coord) =>
            new List<Coordinates3D>
                    {Of(1, 0, 0), Of(0, 1, 0), Of(0, 0, 1),
                        Of(-1, 0, 0), Of(0, -1, 0), Of(0, 0, -1)}
                .Select(n => n + coord)
                .ToList();

        /// <summary>
        /// Returns a <see cref="Coordinates3D"/> between 0 (inclusive) and
        /// the limits given as arguments.
        /// </summary>
        /// <param name="maxX">the upper limit of the X coordinate, must be >= 0.</param>
        /// <param name="maxY">the upper limit of the Y coordinate, must be >= 0.</param>
        /// <param name="maxZ">the upper limit of the Z coordinate, must be >= 0.</param>
        /// <returns>a new <see cref="Coordinates3D"/> with values within given limits.</returns>
        public static Coordinates3D Random(int maxX, int maxY, int maxZ) =>
            Of(new Random().Next(maxX), new Random().Next(maxY), new Random().Next(maxZ));
    }
}
