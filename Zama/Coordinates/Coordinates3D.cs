using System;

namespace Zama.Coordinates
{
    public class Coordinates3D : ICoordinates<int>
    {
        /// <summary>
        /// The X coordinate.
        /// </summary>
        public int X { get; }
        /// <summary>
        /// The Y coordinate.
        /// </summary>
        public int Y { get; }
        /// <summary>
        /// The Z coordinate.
        /// </summary>
        public int Z { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinates3D"/> class.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        internal Coordinates3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        
        public override string ToString() =>
            $"{this.GetType().Name}(X={this.X}, Y={this.Y}, Z={this.Z})";

        public override int GetHashCode() => HashCode.Combine(X, Y, Z);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Coordinates3D) obj);
        }

        public bool Equals(Coordinates3D other) =>
            X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);

        public static Coordinates3D operator +(Coordinates3D a, Coordinates3D b) =>
            new Coordinates3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

        public static Coordinates3D operator -(Coordinates3D a, Coordinates3D b) =>
            a + new Coordinates3D(-b.X, -b.Y, -b.Z);
    }
}