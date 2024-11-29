using AdditiveManufacturingMachine.Models;

namespace AdditiveManufacturingMachine.UnitTests.Models
{
    [TestFixture]
    internal class HighPowerMachineTests
    {
        private HighPowerMachine _highPowerMachine;

        [SetUp]
        public void Setup()
        {
            _highPowerMachine = new HighPowerMachine();
        }

        [Test]
        public void Should_Return_Correct_Cost()
        {
            double cost = _highPowerMachine.Cost;
            Assert.That(cost, Is.EqualTo(750_000));
        }

        [Test]
        public void Should_Return_Correct_Description()
        {
            string description = _highPowerMachine.Description;
            Assert.That(description, Is.EqualTo("High Power Machine"));
        }
    }
}
