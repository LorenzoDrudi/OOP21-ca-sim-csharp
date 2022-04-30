using System;
using System.Linq;
using Drudi.Cell.CoDiCell;
using Drudi.Cell.CoDiCell.Builder;
using NUnit.Framework;
using Sanzani.States;

namespace Drudi.Test
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