using casim.Chiasserini.Grid;
using NUnit.Framework;
using Sanzani.RangeUtils;

namespace casim.Chiasserini.Test
{
    /// <summary>
    /// Test for RowGrid.
    /// </summary>
    public class RowGridTest
    {
        private const int Rows = 3;
        private const int Columns = 2;
        private const int NewValue = 2;
        private const int DefaultValue = 1;
        private const int FirstRowValue = 0;
        
        private Grid2D<int> TestGetGrid()
        {
            return new Grid2D<int>(Rows, Columns, () => DefaultValue);
        }
        
        private RowGrid<int> TestGridWithValues()
        {
            var grid = new RowGrid<int>(this.TestGetGrid());
            for(var x=0; x<Rows;x++)
            {
                for (int y = 0; y < Columns; y++)
                {
                    grid.Set(x, y, x+y);
                }
            }
            return grid;
        }

        [Test]
        public void TestGetRow()
        {
            var grid = this.TestGridWithValues();
            Assert.AreEqual(Ranges.Of(0, Columns). AsQueryable()
                .Select(x => FirstRowValue)
                .ToList(),
                grid.GetRow(0));
        }

        [Test]
        public void TestSetRow()
        {
            var newRow = Ranges.Of(0, Columns).AsQueryable()
                .Select(x => NewValue)
                .ToList();
            var grid = this.TestGridWithValues();
            grid.SetRow(0, newRow);
            Assert.AreEqual(newRow, grid.GetRow(0));
        }
    }
}