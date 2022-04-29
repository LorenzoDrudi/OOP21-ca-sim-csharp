using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Sanzani.States;

namespace Sanzani.StateColorMapper
{
    public class StateColorMapperFactory : IStateColorMapperFactory
    {
        public IStateColorMapper<CoDiCellState> GetCoDiStateColorMapper()
        {
            var colors = new List<Color>
                { Color.Black, Color.MediumPurple, Color.Fuchsia, Color.Coral, Color.Aqua, Color.GreenYellow };
            var states = GetEnumList<CoDiCellState>();
            return GetColorMappersFromLists(states, colors);
        }

        public IStateColorMapper<BryansBrainCellState> GetBryansBrainStateColorMapper()
        {
            var colors = new List<Color> { Color.White, Color.LightBlue, Color.Black };
            var states = GetEnumList<BryansBrainCellState>();
            return GetColorMappersFromLists(states, colors);
        }

        public IStateColorMapper<Rule110CellState> GetRule110StateColorMapper()
        {
            var colors = new List<Color> { Color.White, Color.Black };
            var states = GetEnumList<Rule110CellState>();
            return GetColorMappersFromLists(states, colors);
        }

        public IStateColorMapper<WatorCellState> GetWatorStateColorMapper()
        {
            var colors = new List<Color> { Color.Red, Color.Green, Color.Black };
            var states = GetEnumList<WatorCellState>();
            return GetColorMappersFromLists(states, colors);
        }

        public IStateColorMapper<LangtonsAntCellState> GetLangtonsAntStateColorMapper()
        {
            var colors = new List<Color> { Color.White, Color.Black };
            var states = GetEnumList<LangtonsAntCellState>();
            return GetColorMappersFromLists(states, colors);
        }

        public IStateColorMapper<GameOfLifeState> GetGameOfLifeStateColorMapper()
        {
            var colors = new List<Color> { Color.White, Color.Black };
            var states = GetEnumList<GameOfLifeState>();
            return GetColorMappersFromLists(states, colors);
        }

        private IStateColorMapper<T> GetColorMappersFromLists<T>(IList<T> states, IList<Color> colors) where T : notnull
        {
            var stateToColorMap = states.Zip(colors, (key, value) => new { key, value })
                .ToDictionary(p => p.key, p => p.value);
            return new StateColorMapper<T>(stateToColorMap);
        }

        private IList<T> GetEnumList<T>() where T : Enum
        {
            return new List<T>((T[])Enum.GetValues(typeof(T)));
        }

        private class StateColorMapper<T> : IStateColorMapper<T> where T : notnull
        {
            private readonly Dictionary<T, Color> _stateToColorMap;

            public StateColorMapper(Dictionary<T, Color> stateToColorMap)
            {
                _stateToColorMap = stateToColorMap;
            }

            public Color ToColor(T state)
            {
                return _stateToColorMap[state];
            }
        }
    }    
}