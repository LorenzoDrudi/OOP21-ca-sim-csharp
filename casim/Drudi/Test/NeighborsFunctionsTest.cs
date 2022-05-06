using System;
using System.Linq;
using casim.Chiasserini.Grid;
using casim.Drudi.AbstractionUtils;
using casim.Drudi.Cell.CoDi;
using casim.Drudi.Cell.CoDi.Builder;
using casim.Zama.Coordinates;
using NUnit.Framework;
using Sanzani.States;

namespace casim.Drudi.Test
{
    /// <summary>
    /// Test class for <see cref="NeighborsFunctions"/>.
    /// </summary>
    [TestFixture]
    public class NeighborsFunctionsTest
    {
        private const int Rows = 5;
        private const int Columns = 5;
        private const int Depth = 5;
        private const int X = 2;
        private const int OutX = 5;
        private const int Y = 3;
        private const int Z = 3;

        private readonly Func<CoDiCell> _cellSupplier = () =>
        {
            var builder = new CoDiCellBuilder();
            var neighborsPreviousInput =
                Enum.GetValues(typeof(CoDiDirection)).Cast<CoDiDirection>().ToDictionary(d => d, d => 0);
            var chromosome =
                Enum.GetValues(typeof(CoDiDirection)).Cast<CoDiDirection>().ToDictionary(d => d, d => true);
            return builder.State(CoDiCellState.Blank)
                .ActivationCounter(0)
                .Chromosome(chromosome)
                .NeighborsPreviousInput(neighborsPreviousInput)
                .Build();
        };

        /// <summary>
        /// Test for the Get2DNeighbors() in <see cref="NeighborsFunctions"/>.
         /// </summary>
         [Test]
        public void Neighbors2DFunctionTest()
        {
            var grid = new Grid2D<CoDiCell>(Rows, Columns, _cellSupplier);
            var coord = CoordinatesUtil.Of(X, Y);
            var pair = new Tuple<Coordinates2D, CoDiCell>(coord, _cellSupplier.Invoke());
            var neighborsPair = NeighborsFunctions.Neighbors2DFunction<CoDiCell, CoDiCellState>(pair, grid);
            var neighborsCoord = neighborsPair.Select(p => p.Item1).ToList();
            var list = CoordinatesUtil.Get2DNeighbors(coord);
            Assert.AreEqual(list, neighborsCoord);
            coord = CoordinatesUtil.Of(OutX, Y);
            pair = new Tuple<Coordinates2D, CoDiCell>(coord, _cellSupplier.Invoke());
            Assert.True(NeighborsFunctions.Neighbors2DFunction<CoDiCell, CoDiCellState>(pair, grid)
                .Select(p => p.Item1)
                .All(c => !c.Equals(coord)));
        }
        
        /// <summary>
        /// Test for the GetMooreNeighbors() in <see cref="NeighborsFunctions"/>.
        /// </summary>
        [Test]
        public void MooreNeighborsFunctionTest()
        {
            var grid = new Grid2D<CoDiCell>(Rows, Columns, _cellSupplier);
            Console.WriteLine(grid.Stream().Count());
            var coord = CoordinatesUtil.Of(X, Y);
            var pair = new Tuple<Coordinates2D, CoDiCell>(coord, _cellSupplier.Invoke());
            var neighborsPair = NeighborsFunctions.Neighbors2DFunction<CoDiCell, CoDiCellState>(pair, grid);
            var neighborsCoord = neighborsPair.Select(p => p.Item1).ToList();
            coord = CoordinatesUtil.Of(OutX, Y);
            pair = new Tuple<Coordinates2D, CoDiCell>(coord, _cellSupplier.Invoke());
            Assert.True(NeighborsFunctions.MooreNeighborsFunction<CoDiCell, CoDiCellState>(pair, grid)
                .Select(p => p.Item1)
                .All(c => !c.Equals(coord)));        }

        /// <summary>
        /// Test class for Get3DNeighbors in <see cref="NeighborsFunctions"/>.
        /// </summary>
        [Test]
        public void Neighbors3DFunctionTest()
        {
            var grid = new Grid3D<CoDiCell>(Rows, Columns, Depth, _cellSupplier);
            var coord = CoordinatesUtil.Of(X, Y, Z);
            var pair = new Tuple<Coordinates3D, CoDiCell>(coord, _cellSupplier.Invoke());
            var neighborsPair = NeighborsFunctions.Neighbors3DFunction<CoDiCell, CoDiCellState>(pair, grid);
            var neighborsCoord = neighborsPair.Select(p => p.Item1).ToList();
            var list = CoordinatesUtil.Get3DNeighbors(coord);
            Assert.AreEqual(neighborsCoord, list);
            coord = CoordinatesUtil.Of(OutX, Y, Z);
            pair = new Tuple<Coordinates3D, CoDiCell>(coord, _cellSupplier.Invoke());
            Assert.True(NeighborsFunctions.Neighbors3DFunction<CoDiCell, CoDiCellState>(pair, grid)
                .Select(p => p.Item1)
                .All(c => !c.Equals(coord)));        }
    }
}