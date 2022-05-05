using System.Diagnostics;

namespace Sanzani
{
    /// <summary>
    ///     Abstract class that describes a Builder.
    ///     Not thread safe.
    /// </summary>
    public class BaseBuilder
    {
        private readonly ISet<string> _calledMethods = new HashSet<string>();

        /// <summary>
        ///     Register the method that was called last, throws if it was already called.
        /// </summary>
        /// <exception cref="NullReferenceException">Throw if there's not a method before this on the stack (should not happen).</exception>
        /// <exception cref="InvalidOperationException">
        ///     Exception thrown when the method that called registerCall was already
        ///     called.
        /// </exception>
        public void RegisterCall()
        {
            var stackFrame = new StackTrace().GetFrames();
            var method = stackFrame[1]?.GetMethod() ?? throw new NullReferenceException();
            if (_calledMethods.Contains(method.Name))
                throw new InvalidOperationException(method.Name + " has been called twice.");

            _calledMethods.Add(method.Name);
        }

        /// <summary>
        ///     Check a value with a Predicate and throws an exception if the test fails.
        /// </summary>
        /// <param name="value">The value that will be set.</param>
        /// <param name="predicate">Predicate used to check the value.</param>
        /// <param name="errMsg">Message displayed in case of failed test.</param>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <returns>The validated value.</returns>
        /// <exception cref="ArgumentException"></exception>
        public T CheckValue<T>(T value, Predicate<T> predicate, string errMsg)
        {
            if (!predicate(value))
                throw new ArgumentException(errMsg);

            return value;
        }

        /// <summary>
        ///     Check if the value is not null, if it is throws an exception.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="errMsg">Message displayed in the exception.</param>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <returns>The validated value.</returns>
        public T CheckNonNullValue<T>(T value, string errMsg)
        {
            return CheckValue(value, x => x != null, errMsg);
        }
    }   
}