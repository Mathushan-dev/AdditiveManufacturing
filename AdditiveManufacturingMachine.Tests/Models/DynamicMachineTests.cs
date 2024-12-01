using AdditiveManufacturingMachine.Decorators;
using AdditiveManufacturingMachine.Interfaces;
using AdditiveManufacturingMachine.Models;
using Moq;

namespace AdditiveManufacturingMachine.UnitTests.Models
{
    [TestFixture]
    internal class DynamicMachineTests
    {
        private Mock<IMachine> _mockBaseMachine;
        private DynamicMachine _dynamicMachine;

        [SetUp]
        public void Setup()
        {
            _mockBaseMachine = new Mock<IMachine>();
            _mockBaseMachine.Setup(machine => machine.Cost).Returns(500_000);
            _mockBaseMachine.Setup(machine => machine.Description).Returns("Base Machine");

            _dynamicMachine = new DynamicMachine(_mockBaseMachine.Object);
        }

        private class TestFeature(IMachine machine) : MachineDecorator(machine)
        {
            private readonly double _cost = 65_000;
            private readonly string _description = " with Test Feature";
            public override double Cost => _cost;
            public override string Description => _description;
        }

        [Test(Author = "MM")]
        public void Should_return_base_cost_if_no_features_are_added()
        {
            double cost = _dynamicMachine.Cost;
            Assert.That(cost, Is.EqualTo(500_000));
        }

        [Test(Author = "MM")]
        public void Should_return_base_description_if_no_features_are_added()
        {
            string description = _dynamicMachine.Description;
            Assert.That(description, Is.EqualTo("Base Machine"));
        }

        [Test(Author = "MM")]
        public void Should_update_cost_correctly_if_feature_is_added()
        {
            TestFeature feature = new TestFeature(_mockBaseMachine.Object);

            _dynamicMachine.AddFeature(feature);

            double cost = _dynamicMachine.Cost;
            Assert.That(cost, Is.EqualTo(565_000));
        }

        [Test(Author = "MM")]
        public void Should_update_description_correctly_if_feature_is_added()
        {
            TestFeature feature = new TestFeature(_mockBaseMachine.Object);

            _dynamicMachine.AddFeature(feature);

            string description = _dynamicMachine.Description;
            Assert.That(description, Is.EqualTo("Base Machine with Test Feature"));
        }

        [Test(Author = "MM")]
        public void Should_return_base_cost_if_feature_is_removed()
        {
            TestFeature feature = new TestFeature(_mockBaseMachine.Object);

            _dynamicMachine.AddFeature(feature);
            _dynamicMachine.RemoveFeature<TestFeature>();

            double cost = _dynamicMachine.Cost;
            Assert.That(cost, Is.EqualTo(500_000));
        }

        [Test(Author = "MM")]
        public void Should_return_base_description_if_feature_is_removed()
        {
            TestFeature feature = new TestFeature(_mockBaseMachine.Object);

            _dynamicMachine.AddFeature(feature);
            _dynamicMachine.RemoveFeature<TestFeature>();

            string description = _dynamicMachine.Description;
            Assert.That(description, Is.EqualTo("Base Machine"));
        }

        [Test(Author = "MM")]
        public void Should_throw_ArgumentNullException_if_base_machine_is_null()
        {
            Assert.That(() => new DynamicMachine(null), Throws.ArgumentNullException);
        }

        [Test(Author = "MM")]
        public void Should_return_correct_string_representation_if_ToString_is_called()
        {
            string result = _dynamicMachine.ToString();
            Assert.That(result, Is.EqualTo($"Description: Base Machine{Environment.NewLine}Total Cost: £500,000"));
        }
    }
}
