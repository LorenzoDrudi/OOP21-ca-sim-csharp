using System;
using System.Linq;
using casim.Drudi.Cell.CoDi;
using casim.Drudi.Cell.CoDi.Builder;
using casim.Sanzani.States;
using NUnit.Framework;

namespace casim.Drudi.Test
{
    /// <summary>
    /// Test class for <see cref="CoDiCellBuilder"/>.
    /// </summary>
    [TestFixture]
    public class CoDiCellBuilderTest
    {
        /// <summary>
        /// Test for <see cref="CoDiCellBuilder"/> to check if it throws exception
        /// when build without arguments.
        /// </summary>
        [Test]
        public void BuildWithoutArgumentsTest()
        {
            var builder = new CoDiCellBuilder();
            Assert.Throws<ArgumentException>(() => builder.Build());
        }

        [Test]
        public void BuildTest()
        {
            var builder = new CoDiCellBuilder();
            var neighborsPreviousInput =
                Enum.GetValues(typeof(CoDiDirection)).Cast<CoDiDirection>().ToDictionary(d => d, d => 0);
            var chromosome =
                Enum.GetValues(typeof(CoDiDirection)).Cast<CoDiDirection>().ToDictionary(d => d, d => true);
            var cell = builder.State(CoDiCellState.Blank)
                .ActivationCounter(0)
                .Chromosome(chromosome)
                .NeighborsPreviousInput(neighborsPreviousInput)
                .Build();
            Assert.False(cell.Gate.HasValue);
            Assert.Throws<ArgumentException>(() => builder.Build());
        }
    }
}