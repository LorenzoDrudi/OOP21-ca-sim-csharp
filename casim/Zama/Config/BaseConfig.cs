using NUnit.Framework;

namespace Zama.Config
{
    public class BaseConfig
    {
        /// <summary>
        /// The number of rows in the grid.
        /// </summary>
        public int Rows { get; }
        /// <summary>
        /// The number of columns int the grid.
        /// </summary>
        public int Columns { get; }
        /// <summary>
        /// Returns true if the automaton is automatic,
        /// false otherwise.
        /// </summary>
        public bool IsAutomatic { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseConfig"/> class.
        /// </summary>
        /// <param name="rows">the number of rows in the grid</param>
        /// <param name="columns">the number of columns in the grid</param>
        /// <param name="automatic">true if the automaton runs on automatic simulation</param>
        public BaseConfig(int rows, int columns, bool automatic)
        {
            Rows = rows;
            Columns = columns;
            IsAutomatic = automatic;
        }
    }
}