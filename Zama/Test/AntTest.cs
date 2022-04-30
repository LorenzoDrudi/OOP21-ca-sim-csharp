using NUnit.Framework;
using Zama.Coordinates;
using Zama.LangtonsAnt;

namespace Zama.Test
{
    [TestFixture]
    public class AntTest
    {
        [Test]
        public void TestMove()
        {
            var position = CoordinatesUtil.Of(0, 0);
            var positionAfterMovement = CoordinatesUtil.Of(0, 1);
            var ant = new Ant(position, Direction.North);
            ant.Move();
            Assert.AreEqual(positionAfterMovement, ant.Position);
        }

        [Test]
        public void TestTurn()
        {
            var position = CoordinatesUtil.Of(0, 0);
            var direction = Direction.North;
            var ant = new Ant(position, direction);
            ant.Turn(LangtonsAntCellState.Off);
            Assert.AreEqual(Direction.East, ant.Facing);
            ant.Facing = direction;
            ant.Turn(LangtonsAntCellState.On);
            Assert.AreEqual(Direction.West, ant.Facing);
        }
    }
}