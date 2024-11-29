using AdditiveManufacturingMachine.Decorators;
using AdditiveManufacturingMachine.Interfaces;
using AdditiveManufacturingMachine.Managers;
using Moq;

namespace AdditiveManufacturingMachine.UnitTests.Managers
{
    [TestFixture]
    internal class MachineManagerTests
    {
        private MachineManager _machineManager;
        private TestFeatureDecorator _testFeature;

        [SetUp]
        public void Setup()
        {
            _machineManager = new MachineManager();
            _testFeature = new TestFeatureDecorator(Mock.Of<IMachine>());
        }

        [Test]
        public void Should_Add_Feature()
        {
            _machineManager.AddFeature(_testFeature);
            Assert.That(_machineManager.GetFeatures(), Contains.Item(_testFeature));
        }

        [Test]
        public void Should_Update_Feature_When_Added_Again()
        {
            _machineManager.AddFeature(_testFeature);
            TestFeatureDecorator newTestFeature = new TestFeatureDecorator(Mock.Of<IMachine>());
            _machineManager.AddFeature(newTestFeature);
            Assert.Multiple(() =>
            {
                Assert.That(_machineManager.GetFeatures(), Contains.Item(newTestFeature));
                Assert.That(_machineManager.GetFeatures(), Does.Not.Contain(_testFeature));
            });
        }

        [Test]
        public void Should_Remove_Feature_By_Type()
        {
            _machineManager.AddFeature(_testFeature);
            bool removed = _machineManager.RemoveFeature<TestFeatureDecorator>();
            Assert.Multiple(() =>
            {
                Assert.That(removed, Is.True);
                Assert.That(_machineManager.GetFeatures(), Does.Not.Contain(_testFeature));
            });
        }

        [Test]
        public void Should_Return_False_When_Removing_Nonexistent_Feature()
        {
            bool removed = _machineManager.RemoveFeature<TestFeatureDecorator>();
            Assert.That(removed, Is.False);
        }

        [Test]
        public void Should_Return_Empty_Collection_When_No_Features_Are_Added()
        {
            Assert.That(_machineManager.GetFeatures(), Is.Empty);
        }

        private class TestFeatureDecorator(IMachine machine) : MachineDecorator(machine)
        {
            private readonly double _cost = 10_000;
            private readonly string _description = " with Test Feature";
            public override double Cost => _cost;
            public override string Description => _description;
        }
    }
}
