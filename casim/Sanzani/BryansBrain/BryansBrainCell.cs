using casim.Drudi.Cell;
using Sanzani.States;

namespace Sanzani.BryansBrain
{
    /// <summary>
    /// The Bryan's Brain cell.
    /// </summary>
    public class BryansBrainCell : AbstractCell<BryansBrainCellState>
    {
        /// <summary>
        /// Create e new Bryan's brain cell.
        /// </summary>
        /// <param name="state">The state of the cell.</param>
        public BryansBrainCell(BryansBrainCellState state) : base(state)
        {
        }
    }
}