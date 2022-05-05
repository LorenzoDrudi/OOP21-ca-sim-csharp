namespace Zama.Config
{
    public class WrappingConfig : BaseConfig
    {
        /// <summary>
        /// Returns true if the grid is a Wrapping Grid.
        /// </summary>
        public bool IsWrapping { get; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="WrappingConfig"/> class.
        /// </summary>
        /// <param name="rows">the number of rows in the grid</param>
        /// <param name="columns">the number of columns in the grid</param>
        /// <param name="automatic">true if the automaton runs on automatic simulation</param>
        /// <param name="wrapping">true if the grid is a Wrapping Grid</param>
        public WrappingConfig(int rows, int columns, bool automatic, bool wrapping) : base(rows, columns, automatic)
        {
            IsWrapping = wrapping;
        }
    }
}