using System.Collections.Generic;
using casim.Sanzani;
using casim.Sanzani.States;
using Optional;

namespace casim.Drudi.Cell.CoDi.Builder
{
    /// <summary>
    /// Implementation of <see cref="ICoDiCellBuilder"/>.
    /// </summary>
    public class CoDiCellBuilder: ICoDiCellBuilder
    {
        private const string NullState = "The state cannot be null";
        private const string NullChromosome = "The chromosome cannot be null";
        private const string ActivationCounterValue = "The activation counter value must be greater or equal to zero";
        private const string NullNeighborsPreviousInout = "The neighbors previous input cannot be null";
        private const string AlreadyBuilt = "Cannot build two times";
        
        private bool _built;
        private CoDiCellState _state;
        private Option<CoDiDirection> _gate;
        private int _activationCounter;
        private Dictionary<CoDiDirection, bool> _chromosome;
        private Dictionary<CoDiDirection, int> _neighborsPreviousInput;
        
        private readonly BaseBuilder _baseBuilder = new BaseBuilder();

        public CoDiCellBuilder()
        {
            this._built = false;
            this._gate = Option.None<CoDiDirection>();
        }

        private void AlreadyBuiltCheck()
        {
            this._baseBuilder.CheckValue(_built, b => !b, AlreadyBuilt);
        }
        
        public ICoDiCellBuilder State(CoDiCellState state)
        {
            this.AlreadyBuiltCheck();
            this._state = state;
            return this;
        }

        public ICoDiCellBuilder Gate(Option<CoDiDirection> gate)
        {
            this.AlreadyBuiltCheck();
            this._gate = gate;
            return this;
        }

        public ICoDiCellBuilder Chromosome(Dictionary<CoDiDirection, bool> chromosome)
        {
            this.AlreadyBuiltCheck();
            this._chromosome = chromosome;
            return this;
        }

        public ICoDiCellBuilder ActivationCounter(int activationCounter)
        {
            this.AlreadyBuiltCheck();
            this._activationCounter = this._baseBuilder.CheckValue(this._activationCounter, v => v >= 0, ActivationCounterValue);
            return this;
        }

        public ICoDiCellBuilder NeighborsPreviousInput(Dictionary<CoDiDirection, int> neighborsPreviousInput)
        {
            this.AlreadyBuiltCheck();
            this._neighborsPreviousInput = neighborsPreviousInput;
            return this;
        }

        public CoDiCell Build()
        {
            this.AlreadyBuiltCheck();
            this._built = true;
            return new CoDiCell(
                this._baseBuilder.CheckNonNullValue(this._state, NullState),
                this._baseBuilder.CheckNonNullValue(this._chromosome, NullChromosome),
                this._baseBuilder.CheckNonNullValue(this._neighborsPreviousInput, NullNeighborsPreviousInout),
                this._gate,
                this._activationCounter);
        }
    }
}