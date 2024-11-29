using AdditiveManufacturingMachine.Decorators;
using AdditiveManufacturingMachine.Interfaces;
using Moq;

namespace AdditiveManufacturingMachine.UnitTests.Decorators
{
    [TestFixture]
    internal class FeatureDecoratorTests
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
        public void Should_throw_ArgumentNullException_if_machine_is_null()
        {
            Assert.That(() => new TestFeatureDecorator(null), Throws.ArgumentNullException);
        }

        [Test(Author = "MM")]
        public void Should_return_feature_cost_if_GetCost_is_called()
        {
            TestFeatureDecorator testFeature = new TestFeatureDecorator(_mockMachine.Object);
            double cost = testFeature.Cost;
            Assert.That(cost, Is.EqualTo(55_000));
        }

        [Test(Author = "MM")]
        public void Should_return_feature_description_if_GetDescription_is_called()
        {
            TestFeatureDecorator testFeature = new TestFeatureDecorator(_mockMachine.Object);
            string description = testFeature.Description;
            Assert.That(description, Is.EqualTo(" with Test Feature"));
        }

        private class TestFeatureDecorator(IMachine machine) : MachineDecorator(machine)
        {
            private readonly double _cost = 55_000;
            private readonly string _description = " with Test Feature";
            public override double Cost => _cost;
            public override string Description => _description;
        }
    }
}
