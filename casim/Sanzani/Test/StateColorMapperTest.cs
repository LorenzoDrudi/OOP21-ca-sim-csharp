using System.Drawing;
using NUnit.Framework;
using Sanzani.StateColorMapper;
using Sanzani.States;

namespace Sanzani.Test
{
    [TestFixture]
    public class StateColorMapperTest
    {
        private readonly IStateColorMapperFactory _factory;

        public StateColorMapperTest()
        {
            _factory = new StateColorMapperFactory();
        }

        [Test]
        public void TestBryansBrainColorMapper()
        {
            var mapper = _factory.GetBryansBrainStateColorMapper();
            Assert.AreEqual(Color.White, mapper.ToColor(BryansBrainCellState.Alive));
            Assert.AreEqual(Color.LightBlue, mapper.ToColor(BryansBrainCellState.Dying));
            Assert.AreEqual(Color.Black, mapper.ToColor(BryansBrainCellState.Dead));
        }

        [Test]
        public void TestLangtonsAntColorMapper()
        {
            var mapper = _factory.GetLangtonsAntStateColorMapper();
            Assert.AreEqual(Color.White, mapper.ToColor(LangtonsAntCellState.On));
            Assert.AreEqual(Color.Black, mapper.ToColor(LangtonsAntCellState.Off));
        }

        [Test]
        public void TestGameOfLifeColorMapper()
        {
            var mapper = _factory.GetGameOfLifeStateColorMapper();
            Assert.AreEqual(Color.White, mapper.ToColor(GameOfLifeState.Alive));
            Assert.AreEqual(Color.Black, mapper.ToColor(GameOfLifeState.Dead));
        }

        [Test]
        public void TestRule110ColorMapper()
        {
            var mapper = _factory.GetRule110StateColorMapper();
            Assert.AreEqual(Color.White, mapper.ToColor(Rule110CellState.Alive));
            Assert.AreEqual(Color.Black, mapper.ToColor(Rule110CellState.Dead));
        }


        [Test]
        public void TestWatorColorMapper()
        {
            var mapper = _factory.GetWatorStateColorMapper();
            Assert.AreEqual(Color.Black, mapper.ToColor(WatorCellState.Dead));
            Assert.AreEqual(Color.Red, mapper.ToColor(WatorCellState.Predator));
            Assert.AreEqual(Color.Green, mapper.ToColor(WatorCellState.Prey));
        }

        public void TestCoDiColorMapper()
        {
            var mapper = _factory.GetCoDiStateColorMapper();
            Assert.AreEqual(Color.Black, mapper.ToColor(CoDiCellState.Blank));
            Assert.AreEqual(Color.Fuchsia, mapper.ToColor(CoDiCellState.Axon));
            Assert.AreEqual(Color.MediumPurple, mapper.ToColor(CoDiCellState.Neuron));
            Assert.AreEqual(Color.Aqua, mapper.ToColor(CoDiCellState.Dendrite));
            Assert.AreEqual(Color.Coral, mapper.ToColor(CoDiCellState.ActivateAxon));
            Assert.AreEqual(Color.GreenYellow, mapper.ToColor(CoDiCellState.ActivateDendrite));
        }
    }    
}