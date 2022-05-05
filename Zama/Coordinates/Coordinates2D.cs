using System;

namespace Zama.Coordinates
{
    public class Coordinates2D : ICoordinates<int>
    {

        private readonly (int, int) _values;
        
        /// <summary>
        /// The X coordinate value.
        /// </summary>
        public int X => _values.Item1;

        /// <summary>
        /// The Y coordinate value.
        /// </summary>
        public int Y => _values.Item2;

        /// <summary>
        ///  Initializes a new instance of the <see cref="Coordinates2D"/> class.
        /// </summary>
        /// <param name="x">the x value of the coordinate</param>
        /// <param name="y">the y value of the coordinate</param>
        internal Coordinates2D(int x, int y)
        {
            _values = (x, y);
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}(X={this.X}, Y={this.Y})";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public bool Equals(Coordinates2D other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Coordinates2D) obj);
        }

        public static Coordinates2D operator +(Coordinates2D a, Coordinates2D b) =>
            new Coordinates2D(a.X + b.X, a.Y + b.Y);

        public static Coordinates2D operator -(Coordinates2D a, Coordinates2D b) => a + new Coordinates2D(-b.X, -b.Y);
    }
}