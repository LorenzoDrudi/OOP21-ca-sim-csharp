namespace casim.Sanzani.States
{
    /// <summary>
    ///     The state of a Langtons Ant automaton cell.
    /// </summary>
    public enum LangtonsAntCellState
    {
        /// <summary>
        ///     The activated state, an ant on this state will turn left.
        /// </summary>
        On,

        /// <summary>
        ///     The deactivated state, an ant on this state will turn right.
        /// </summary>
        Off
    }
}