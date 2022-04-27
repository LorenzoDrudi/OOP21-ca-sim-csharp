using System.Drawing;
using NUnit.Framework;
using Sanzani.StateColorMapper;
using Sanzani.States;

namespace SanzaniTest;

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
        Assert.AreEqual(mapper.ToColor(BryansBrainCellState.ALIVE), Color.White);
        Assert.AreEqual(mapper.ToColor(BryansBrainCellState.DYING), Color.LightBlue);
        Assert.AreEqual(mapper.ToColor(BryansBrainCellState.DEAD), Color.Black);
    }

    [Test]
    public void TestLangtonsAntColorMapper()
    {
        var mapper = _factory.GetLangtonsAntStateColorMapper();
        Assert.AreEqual(mapper.ToColor(LangtonsAntCellState.ON), Color.White);
        Assert.AreEqual(mapper.ToColor(LangtonsAntCellState.OFF), Color.Black);
    }
    
    [Test]
    public void TestGameOfLifeColorMapper()
    {
        var mapper = _factory.GetGameOfLifeStateColorMapper();
        Assert.AreEqual(mapper.ToColor(GameOfLifeState.ALIVE), Color.White);
        Assert.AreEqual(mapper.ToColor(GameOfLifeState.DEAD), Color.Black);
    }
    
    [Test]
    public void TestRule110ColorMapper()
    {
        var mapper = _factory.GetRule110StateColorMapper();
        Assert.AreEqual(mapper.ToColor(Rule110CellState.ALIVE), Color.White);
        Assert.AreEqual(mapper.ToColor(Rule110CellState.DEAD), Color.Black);
    }
    
    
    [Test]
    public void TestWatorColorMapper()
    {
        var mapper = _factory.GetWatorStateColorMapper();
        Assert.AreEqual(mapper.ToColor(WatorCellState.DEAD), Color.Black);
        Assert.AreEqual(mapper.ToColor(WatorCellState.PREDATOR), Color.Red);
        Assert.AreEqual(mapper.ToColor(WatorCellState.PREY), Color.Green);
    }

    public void TestCoDiColorMapper()
    {
        var mapper = _factory.GetCoDiStateColorMapper();
        Assert.AreEqual(mapper.ToColor(CoDiCellState.BLANK), Color.Black);
        Assert.AreEqual(mapper.ToColor(CoDiCellState.AXON), Color.Fuchsia);
        Assert.AreEqual(mapper.ToColor(CoDiCellState.NEURON), Color.MediumPurple);
        Assert.AreEqual(mapper.ToColor(CoDiCellState.DENDRITE), Color.Aqua);
        Assert.AreEqual(mapper.ToColor(CoDiCellState.ACTIVATE_AXON), Color.Coral);
        Assert.AreEqual(mapper.ToColor(CoDiCellState.ACTIVATE_DENDRITE), Color.GreenYellow);
    }
}