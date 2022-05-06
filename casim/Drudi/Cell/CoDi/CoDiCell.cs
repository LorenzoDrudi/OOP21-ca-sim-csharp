using System.Collections.Generic;
using Optional;
using Optional.Unsafe;
using Sanzani.States;

namespace casim.Drudi.Cell.CoDi
{
    public class CoDiCell : AbstractCell<CoDiCellState>
    {
        /// <summary>
        /// The gate of the cell.
        /// </summary>
        public Option<CoDiDirection> Gate { get; }
        
        /// <summary>
        /// The activation counter of the cell.
        /// </summary>
        public int ActivationCounter { get; set; }
        
        /// <summary>
        /// A <c>Dictionary</c> describing the chromosome of the cell..
        /// </summary>
        public Dictionary<CoDiDirection, bool> Chromosome { get; }
        
        /// <summary>
        /// A <c>Dictionary</c> containing the previous input of the neighbors.
        /// </summary>
        public Dictionary<CoDiDirection, int> NeighborsPreviousInput { get; }

        /// <summary>
        /// Construct a new <see cref="CoDiCell"/>.
        /// </summary>
        /// <param name="state">The state of the cell;</param>
        /// <param name="chromosome">The chromosome of the cell;</param>
        /// <param name="neighborsPreviousInput">The previous input of the neighbors of the cell;</param>
        /// <param name="gate">The gate of the cell.</param>
        /// <param name="activationCounter">The value of  the activation counter.</param>
        public CoDiCell(CoDiCellState state, Dictionary<CoDiDirection, bool> chromosome,
            Dictionary<CoDiDirection, int> neighborsPreviousInput, Option<CoDiDirection> gate, int activationCounter = 0) : base(state)
        {
            this.ActivationCounter = activationCounter;
            this.Chromosome = chromosome;
            this.NeighborsPreviousInput = neighborsPreviousInput;
            this.Gate = gate;
        }

        /// <summary>
        /// Return the opposite <see cref="CoDiDirection"/> to the gate of the cell.
        /// </summary>
        /// <returns>The opposite direction to the gate.</returns>
        public Option<CoDiDirection> GetOppositeToGate() => Gate.HasValue
            ? Option.Some(CoDiDirectionUtils.GetOppositeDirection(Gate.ValueOrFailure()))
            : Option.None<CoDiDirection>();

        /// <summary>
        /// Return the value contained in the <c>direction</c> take as input,
        /// Return an empty <see cref="Optional"/> if direction is not present.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns>An optional containing the value if the direction is present, else an empty optional.</returns>
        public Option<int> GetSpecificNeighborsPreviousInput(CoDiDirection direction)
        {
            return this.NeighborsPreviousInput.ContainsKey(direction)
                ? Option.Some(this.NeighborsPreviousInput[direction])
                : Option.None<int>();
        }
        
        /// <summary>
        /// Set the value in <c>direction</c> take as input,
        /// if direction is not present it does nothing.
        /// </summary>
        /// <param name="direction">The direction where to set the value.</param>
        /// <param name="value">The value to set.</param>
        public void SetSpecificNeighborsPreviousInput(CoDiDirection direction, int value)
        {
            if (this.NeighborsPreviousInput.ContainsKey(direction))
            {
                this.NeighborsPreviousInput[direction] = value;
            }
        }
    }
}