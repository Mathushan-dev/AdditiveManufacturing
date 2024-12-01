using AdditiveManufacturingMachine.Decorators;
using AdditiveManufacturingMachine.Interfaces;
using AdditiveManufacturingMachine.Models;

namespace AdditiveManufacturingMachine.Tests
{
    [TestFixture]
    internal class CustomExaminerRequiredTests
    {
        private DynamicMachine _dynamicMachine;

        [SetUp]
        public void Setup()
        {
            IMachine baseMachine = new MediumPowerMachine();
            _dynamicMachine = new DynamicMachine(baseMachine);
        }

        [Test(Author = "MM")]
        public void Should_update_cost_and_description_correctly_with_multiple_features()
        {
            ReducedBuildVolume reducedBuildVolume = new ReducedBuildVolume(_dynamicMachine);
            QuadLaser quadLaser = new QuadLaser(_dynamicMachine);
            PowderRecirculationSystem powderRecirculationSystem = new PowderRecirculationSystem(_dynamicMachine);

            _dynamicMachine.AddFeature(reducedBuildVolume);
            _dynamicMachine.AddFeature(quadLaser);
            _dynamicMachine.AddFeature(powderRecirculationSystem);

            Assert.Multiple(() =>
            {
                Assert.That(
                    _dynamicMachine.Description,
                    Is.EqualTo("Medium Power Machine with Reduced Build Volume with Quad Laser with Powder Recirculation System"));
                Assert.That(
                    _dynamicMachine.Cost,
                    Is.EqualTo(932_000),
                    "Total cost with all features should be £932,000");
            });
        }

        [Test(Author = "MM")]
        public void Should_remove_specific_feature_and_update_correctly()
        {
            ReducedBuildVolume reducedBuildVolume = new ReducedBuildVolume(_dynamicMachine);
            QuadLaser quadLaser = new QuadLaser(_dynamicMachine);
            PowderRecirculationSystem powderRecirculationSystem = new PowderRecirculationSystem(_dynamicMachine);

            _dynamicMachine.AddFeature(reducedBuildVolume);
            _dynamicMachine.AddFeature(quadLaser);
            _dynamicMachine.AddFeature(powderRecirculationSystem);

            _dynamicMachine.RemoveFeature<ReducedBuildVolume>();

            Assert.Multiple(() =>
            {
                Assert.That(
                    _dynamicMachine.Description,
                    Is.EqualTo("Medium Power Machine with Quad Laser with Powder Recirculation System"));
                Assert.That(
                    _dynamicMachine.Cost,
                    Is.EqualTo(857_000),
                    "Total cost after removing Reduced Build Volume should be £857,000");
            });
        }

        [Test(Author = "MM")]
        public void Should_handle_removal_of_nonexistent_feature_gracefully()
        {
            QuadLaser quadLaser = new QuadLaser(_dynamicMachine);
            _dynamicMachine.AddFeature(quadLaser);

            Assert.DoesNotThrow(() => _dynamicMachine.RemoveFeature<ReducedBuildVolume>());
        }

        [Test(Author = "MM")]
        public void Should_return_correct_string_representation()
        {
            QuadLaser quadLaser = new QuadLaser(_dynamicMachine);
            _dynamicMachine.AddFeature(quadLaser);

            string result = _dynamicMachine.ToString();

            Assert.That(
                result,
                Is.EqualTo(
                    $"Description: Medium Power Machine with Quad Laser{Environment.NewLine}Total Cost: £775,000"));
        }

        [Test(Author = "MM")]
        public void Should_return_base_description_and_cost_when_no_features_are_added()
        {
            string description = _dynamicMachine.Description;
            double cost = _dynamicMachine.Cost;

            Assert.Multiple(() =>
            {
                Assert.That(description, Is.EqualTo("Medium Power Machine"));
                Assert.That(cost, Is.EqualTo(550_000));
            });
        }
    }
}
