using System;

namespace Zama.Coordinates
{
    public class Coordinates2D<T> : ICoordinates<T> where T : IComparable<T>
    {
        public T X { get; }
        public T Y { get; }

        /// <summary>
        ///  Initializes a new instance of the <see cref="Coordinates2D{T}"/> class.
        /// </summary>
        /// <param name="x">the x value of the coordinate</param>
        /// <param name="y">the y value of the coordinate</param>
        public  Coordinates2D(T x, T y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}(X={this.X}, Y={this.Y})";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public bool Equals(Coordinates2D<T> other)
        {
            return X.CompareTo(other.X) == 0 && Y.CompareTo(other.Y) == 0;
        }
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Coordinates2D<T>) obj);
        }
    }
}