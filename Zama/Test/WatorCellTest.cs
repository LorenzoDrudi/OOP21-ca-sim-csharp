using System;
using NUnit.Framework;
using Zama.Wator;

namespace Zama.Test
{
    [TestFixture]
    public class WatorCellTest
    {
        private const int MaxHealth = 10;
        private const int MinHealth = 0;
        private const int PreyHeal = 1;
        private const int PredHeal = 5;

        private WatorCell GetPrey() => new WatorCell(WatorCellState.Prey, PreyHeal);
        private WatorCell GetPred() => new WatorCell(WatorCellState.Predator, PreyHeal);
        private WatorCell GetDead() => new WatorCell(WatorCellState.Dead, MinHealth);

        [Test]
        public void TestHeal()
        {
            var prey = GetPrey();
            prey.Heal();
            Assert.AreEqual(PreyHeal + PreyHeal, prey.Health);
            var pred = GetPred();
            pred.Heal();
            Assert.AreEqual(PreyHeal + PredHeal, pred.Health);
            var dead = GetDead();
            Assert.AreEqual(MinHealth, dead.Health);
        }

        [Test]
        public void TestSetHealth()
        {
            var prey = GetPrey();
            prey.Health = PredHeal;
            Assert.AreEqual(PredHeal, prey.Health);
            Assert.Catch<ArgumentException>(() => prey.Health = MaxHealth + PreyHeal);
        }

        [Test]
        public void TestStarve()
        {
            var pred = GetPred();
            var initHealth = pred.Health;
            pred.Starve();
            Assert.AreEqual(initHealth - PreyHeal, pred.Health);
            pred.Health = MinHealth;
            pred.Starve();
            Assert.AreEqual(MinHealth, pred.Health);
            var prey = GetPrey();
            Assert.Catch<InvalidOperationException>(() => prey.Starve());
        }

        [Test]
        public void TestPredReproduce()
        {
            var pred = GetPred();
            var deadPredSpawn = pred.Reproduce();
            Assert.True(deadPredSpawn.IsDead);
            Assert.AreEqual(WatorCellState.Dead, deadPredSpawn.State);
            pred.Health = MaxHealth;
            var predSpawn = pred.Reproduce();
            Assert.AreEqual(MaxHealth / 2, predSpawn.Health);
            Assert.AreEqual(WatorCellState.Predator, predSpawn.State);
            Assert.AreEqual(MaxHealth / 2, pred.Health);
        }

        [Test]
        public void TestPreyReproduce()
        {
            var prey = GetPrey();
            var deadPreySpawn = prey.Reproduce();
            Assert.True(deadPreySpawn.IsDead);
            Assert.AreEqual(WatorCellState.Dead, deadPreySpawn.State);
            prey.Health = MaxHealth;
            var preySpawn = prey.Reproduce();
            Assert.AreEqual(PreyHeal, prey.Health);
            Assert.AreEqual(PreyHeal, preySpawn.Health);
            Assert.AreEqual(WatorCellState.Prey, preySpawn.State);
        }

        [Test]
        public void TestDeadReproduce()
        {
            var dead = GetDead();
            var deadSpawn = dead.Reproduce();
            Assert.AreEqual(WatorCellState.Dead, deadSpawn.State);
            dead.Health = MaxHealth;
            Assert.Catch<InvalidOperationException>(() => dead.Reproduce());
        }

        [Test]
        public void TestClone()
        {
            var dead = GetDead();
            var prey = GetPrey();
            dead.Clone(prey);
            Assert.AreEqual(prey.State, dead.State);
            Assert.AreEqual(prey.Health, dead.Health);
            Assert.AreEqual(prey.HasMoved, dead.HasMoved);
        }
    }
}