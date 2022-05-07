using System.Collections.Generic;
using casim.Sanzani.States;
using Optional;

namespace casim.Drudi.Cell.CoDi.Builder
{
    /// <summary>
    /// A builder for <see cref="CoDiCell"/>
    /// </summary>
    public interface ICoDiCellBuilder
    {
        /// <summary>
        /// Set the state of the <see cref="CoDiCell"/>.
        /// </summary>
        /// <param name="state">The state to set.</param>
        /// <returns>The current <see cref="ICoDiCellBuilder"/>.</returns>
        ICoDiCellBuilder State(CoDiCellState state);

        /// <summary>
        /// Set the gate of the <see cref="CoDiCell"/>.
        /// </summary>
        /// <param name="gate">The gate to set, it can be Empty.</param>
        /// <returns>The current <see cref="ICoDiCellBuilder"/>.</returns>
        ICoDiCellBuilder Gate(Option<CoDiDirection> gate);

        /// <summary>
        /// Set the chromosome of the <see cref="CoDiCell"/>.
        /// </summary>
        /// <param name="chromosome">The chromosome to set.</param>
        /// <returns>The current <see cref="ICoDiCellBuilder"/>.</returns>
        ICoDiCellBuilder Chromosome(Dictionary<CoDiDirection, bool> chromosome);

        /// <summary>
        /// Set the activation counter of the <see cref="CoDiCell"/>.
        /// </summary>
        /// <param name="activationCounter">The value to set.</param>
        /// <returns>The current <see cref="ICoDiCellBuilder"/>.</returns>
        ICoDiCellBuilder ActivationCounter(int activationCounter);

        /// <summary>
        /// Set the <see cref="CoDiCell"/>'s neighbors previous input.
        /// </summary>
        /// <param name="neighborsPreviousInput">The values to set.</param>
        /// <returns>The current <see cref="ICoDiCellBuilder"/>.</returns>
        ICoDiCellBuilder NeighborsPreviousInput(Dictionary<CoDiDirection, int> neighborsPreviousInput);

        /// <summary>
        /// Build the <see cref="CoDiCell"/>.
        /// </summary>
        /// <returns>The new <see cref="CoDiCell"/>.</returns>
        CoDiCell Build();
    }
}