using Sanzani.States;

namespace Sanzani.StateColorMapper
{
    /// <summary>
    ///     Factory for IStateColorMapper configuration.
    /// </summary>
    public interface IStateColorMapperFactory
    {
        /// <summary>
        ///     Return the IStateColorMapper for CoDi automaton.
        /// </summary>
        /// <returns>the StateColorMapper for CoDi automaton.</returns>
        IStateColorMapper<CoDiCellState> GetCoDiStateColorMapper();

        /// <summary>
        ///     Return the IStateColorMapper for Bryans Brain automaton.
        /// </summary>
        /// <returns>the IStateColorMapper for Bryans Brain automaton.</returns>
        IStateColorMapper<BryansBrainCellState> GetBryansBrainStateColorMapper();

        /// <summary>
        ///     Return the IStateColorMapper for Rule110 automaton.
        /// </summary>
        /// <returns>the IStateColorMapper for Rule110 automaton.</returns>
        IStateColorMapper<Rule110CellState> GetRule110StateColorMapper();

        /// <summary>
        ///     Return the IStateColorMapper for Wator automaton.
        /// </summary>
        /// <returns>the IStateColorMapper for Wator automaton.</returns>
        IStateColorMapper<WatorCellState> GetWatorStateColorMapper();

        /// <summary>
        ///     Returns the IStateColorMapper for Langton's Ant automaton.
        /// </summary>
        /// <returns>the IStateColorMapper for Langton's Ant automaton.</returns>
        IStateColorMapper<LangtonsAntCellState> GetLangtonsAntStateColorMapper();

        /// <summary>
        ///     Returns the IStateColorMapper for Game of life automaton.
        /// </summary>
        /// <returns>the IStateColorMapper for Game of life automaton.</returns>
        IStateColorMapper<GameOfLifeState> GetGameOfLifeStateColorMapper();
    }    
}