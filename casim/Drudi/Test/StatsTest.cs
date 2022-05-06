using System.Collections.Generic;
using casim.Drudi.Stats;
using NUnit.Framework;
using Sanzani.States;

namespace casim.Drudi.Test
{
    /// <summary>
    /// Test class for <see cref="Stats"/>
    /// </summary>
    [TestFixture]
    public class StatsTest
    {
        private const int Iteration = 10;
        private static readonly Dictionary<CoDiCellState, int> CellStats = new Dictionary<CoDiCellState, int> { {CoDiCellState.Axon, 2} };
        private static readonly IStats<CoDiCellState> Stats = new Stats<CoDiCellState>(Iteration, CellStats);

        /// <summary>
        /// Test the right behaviour of Iteration getter.
        /// </summary>
        [Test]
        public void IterationTest()
        {
            Assert.AreEqual(Iteration, Stats.Iteration);
        }

        /// <summary>
        /// Test the right behaviour of CellStats getter.
        /// </summary>
        [Test]
        public void CellStatsTest()
        {
            Assert.AreEqual(CellStats, Stats.CellStats);
            Assert.AreEqual(CellStats[CoDiCellState.Axon], Stats.CellStats[CoDiCellState.Axon]);
        }
    }
}