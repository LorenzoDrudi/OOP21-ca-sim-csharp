using Zama;

namespace Chiasserini.Rule110
{
    /// <summary>
    /// Cell of Rule110.
    /// </summary>
    public class Rule110Cell : AbstractCell<Rule110CellState>
    {
        /// <summary>
        /// Package-private.
        /// </summary>
        /// <param name="state">the current state of the Rule110Cell.</param>
        public Rule110Cell(Rule110CellState state) : base(state) {}
    }
}