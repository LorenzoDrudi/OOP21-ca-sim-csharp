using System;
using System.Collections.Generic;

namespace casim.Sanzani.RangeUtils
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
        public static IEnumerable<T> Of<T>(
            T startInclusive, T endExclusive, Func<T, T> step) where T : IComparable<T>
        {
            for (var current = startInclusive; current.CompareTo(endExclusive) < 0; current = step(current))
            {
                yield return current;
            }
        }

        /// <summary>
        ///     Creates a IRange of integers with custom step.
        ///     If step is not specified it is set to 1.
        /// </summary>
        /// <param name="startInclusive">the inclusive start of the range.</param>
        /// <param name="endExclusive">the exclusive end of the range.</param>
        /// <param name="step">the step between two consecutive elements.</param>
        /// <returns>an integer IRange that goes from startInclusive to endExclusive with step "step".</returns>
        public static IEnumerable<int> Of(int startInclusive, int endExclusive, int step = 1)
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
        public static IEnumerable<double> Of(double startInclusive, double endExclusive, double step)
        {
            return Of(startInclusive, endExclusive, x => x + step);
        }
    }
}