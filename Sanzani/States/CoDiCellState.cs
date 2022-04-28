namespace Sanzani.States;

/// <summary>
/// The states that the CoDi automaton can have.
/// </summary>
public enum CoDiCellState
{
    /// <summary>
    /// An Empty cell.
    /// </summary>
    BLANK,
    /// <summary>
    /// The neuron body cells, they collect signals from the surrounding dentritic cell.
    /// </summary>
    NEURON,
    /// <summary>
    /// Axonal cells, they distribute data originating from the neuron body.
    /// </summary>
    AXON,
    /// <summary>
    /// An activated axon.
    /// </summary>
    ACTIVATE_AXON,
    /// <summary>
    /// Dendritic cells, they collect data and eventually pass it to the neuron body.
    /// </summary>
    DENDRITE,
    /// <summary>
    /// An activated dendrite.
    /// </summary>
    ACTIVATE_DENDRITE
}