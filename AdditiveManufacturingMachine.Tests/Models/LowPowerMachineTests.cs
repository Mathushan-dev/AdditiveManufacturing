using AdditiveManufacturingMachine.Models;

namespace AdditiveManufacturingMachine.UnitTests.Models
{
    [TestFixture]
    internal class LowPowerMachineTests
    {
        private LowPowerMachine _lowPowerMachine;

        [SetUp]
        public void Setup()
        {
            _lowPowerMachine = new LowPowerMachine();
        }

        [Test]
        public void Should_Return_Correct_Cost()
        {
            double cost = _lowPowerMachine.Cost;
            Assert.That(cost, Is.EqualTo(450_000));
        }

        [Test]
        public void Should_Return_Correct_Description()
        {
            string description = _lowPowerMachine.Description;
            Assert.That(description, Is.EqualTo("Low Power Machine"));
        }
    }
}
