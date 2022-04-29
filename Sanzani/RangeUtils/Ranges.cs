using System;
using System.Collections;
using System.Collections.Generic;

namespace Sanzani.RangeUtils
{
    /// <summary>
    ///     Utility class to that easily allows to create IRange instances.
    /// </summary>
    public static class Ranges
    {
        /// <summary>
        ///     Creates a IRange that goes from startInclusive to endExclusive using a function to define the step.
        /// </summary>
        /// <param name="startInclusive">the inclusive start of the range.</param>
        /// <param name="endExclusive">the exclusive end of the range.</param>
        /// <param name="step">the function that defines the step between two consecutive elements.</param>
        /// <typeparam name="T">the comparable type of the elements in the IRange</typeparam>
        /// <returns>an IRange that goes from startInclusive to endExclusive with step "step".</returns>
        public static IRange<T> Of<T>(
            T startInclusive, T endExclusive, Func<T, T> step) where T : IComparable<T>
        {
            return new RangeEnumerable<T>(startInclusive, endExclusive, step);
        }

        /// <summary>
        ///     Creates a IRange of integers with custom step.
        ///     If step is not specified it is set to 1.
        /// </summary>
        /// <param name="startInclusive">the inclusive start of the range.</param>
        /// <param name="endExclusive">the exclusive end of the range.</param>
        /// <param name="step">the step between two consecutive elements.</param>
        /// <returns>an integer IRange that goes from startInclusive to endExclusive with step "step".</returns>
        public static IRange<int> Of(int startInclusive, int endExclusive, int step = 1)
        {
            return Of(startInclusive, endExclusive, x => x + step);
        }

        /// <summary>
        ///     Creates a IRange of double with custom step.
        /// </summary>
        /// <param name="startInclusive">the inclusive start of the range.</param>
        /// <param name="endExclusive">the exclusive end of the range.</param>
        /// <param name="step">the step between two consecutive elements.</param>
        /// <returns>a double IRange that goes from startInclusive to endExclusive with step "step".</returns>
        public static IRange<double> Of(double startInclusive, double endExclusive, double step)
        {
            return Of(startInclusive, endExclusive, x => x + step);
        }

        private class RangeEnumerable<T> : IRange<T> where T : IComparable<T>
        {
            private readonly T _endExclusive;
            private readonly T _startInclusive;
            private readonly Func<T, T> _step;

            public RangeEnumerable(T startInclusive, T endExclusive, Func<T, T> step)
            {
                _startInclusive = startInclusive;
                _endExclusive = endExclusive;
                _step = step;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return new RangeEnumerator<T>(_startInclusive, _endExclusive, _step);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        private sealed class RangeEnumerator<T> : IEnumerator<T> where T : IComparable<T>
        {
            private readonly T _endExclusive;
            private readonly T _startInclusive;
            private readonly Func<T, T> _step;

            public RangeEnumerator(T startInclusive, T endExclusive, Func<T, T> step)
            {
                Current = startInclusive;
                _startInclusive = startInclusive;
                _endExclusive = endExclusive;
                _step = step;
            }

            public void Reset()
            {
                Current = _startInclusive;
                //The original Range.java does not implement reset, if we want to 
                //keep the same exact functionalities we should throw an exception.
                //throw new NotImplementedException();
            }

            public T Current { get; private set; }

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                var next = _step(Current);
                if (next.CompareTo(_endExclusive) >= 0)
                    return false;
                Current = _step(Current);
                return true;
            }

            public void Dispose()
            {
            }
        }
    }
}