using AdditiveManufacturingMachine.Decorators;
using AdditiveManufacturingMachine.Interfaces;
using Moq;

namespace AdditiveManufacturingMachine.UnitTests.Decorators
{
    [TestFixture]
    internal class ReducedBuildVolumeTests
    {
        private Mock<IMachine> _mockMachine;

        [SetUp]
        public void Setup()
        {
            _mockMachine = new Mock<IMachine>();
            _mockMachine.Setup(machine => machine.Cost).Returns(500_000);
            _mockMachine.Setup(machine => machine.Description).Returns("Base Machine");
        }

        [Test(Author = "MM")]
        public void Should_return_feature_cost_if_GetCost_is_called()
        {
            ReducedBuildVolume reducedBuildVolume = new ReducedBuildVolume(_mockMachine.Object);
            double cost = reducedBuildVolume.Cost;
            Assert.That(cost, Is.EqualTo(75_000));
        }

        [Test(Author = "MM")]
        public void Should_return_feature_description_if_GetDescription_is_called()
        {
            ReducedBuildVolume reducedBuildVolume = new ReducedBuildVolume(_mockMachine.Object);
            string description = reducedBuildVolume.Description;
            Assert.That(description, Is.EqualTo(" with Reduced Build Volume"));
        }

        [Test(Author = "MM")]
        public void Should_throw_ArgumentNullException_if_machine_is_null()
        {
            Assert.That(() => new ReducedBuildVolume(null), Throws.ArgumentNullException);
        }
    }
}
