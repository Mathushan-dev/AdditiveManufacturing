using AdditiveManufacturingMachine.Models;

namespace AdditiveManufacturingMachine.UnitTests.Models
{
    [TestFixture]
    internal class MediumPowerMachineTests
    {
        private MediumPowerMachine _mediumPowerMachine;

        [SetUp]
        public void Setup()
        {
            _mediumPowerMachine = new MediumPowerMachine();
        }

        [Test]
        public void Should_Return_Correct_Cost()
        {
            double cost = _mediumPowerMachine.Cost;
            Assert.That(cost, Is.EqualTo(550_000));
        }

        [Test]
        public void Should_Return_Correct_Description()
        {
            string description = _mediumPowerMachine.Description;
            Assert.That(description, Is.EqualTo("Medium Power Machine"));
        }
    }
}
