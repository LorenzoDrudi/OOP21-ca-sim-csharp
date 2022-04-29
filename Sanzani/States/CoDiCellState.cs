namespace Sanzani.States 
{
    /// <summary>
    ///     The states that the CoDi automaton can have.
    /// </summary>
    public enum CoDiCellState
    {
        /// <summary>
        ///     An Empty cell.
        /// </summary>
        Blank,

        /// <summary>
        ///     The neuron body cells, they collect signals from the surrounding dentritic cell.
        /// </summary>
        Neuron,

        /// <summary>
        ///     Axonal cells, they distribute data originating from the neuron body.
        /// </summary>
        Axon,

        /// <summary>
        ///     An activated axon.
        /// </summary>
        ActivateAxon,

        /// <summary>
        ///     Dendritic cells, they collect data and eventually pass it to the neuron body.
        /// </summary>
        Dendrite,

        /// <summary>
        ///     An activated dendrite.
        /// </summary>
        ActivateDendrite
    }
}