using System;
using System.Text;
using AdditiveManufacturingMachine.Decorators;
using AdditiveManufacturingMachine.Interfaces;
using AdditiveManufacturingMachine.Managers;

namespace AdditiveManufacturingMachine.Models
{
    /// <summary>
    /// Represents a machine with dynamically applied features.
    /// </summary>
    public class DynamicMachine : IMachine
    {
        private readonly IMachine _baseMachine;
        private readonly MachineManager _machineManager;
        private readonly double _baseCost;
        private readonly string _baseDescription;

        private double _cachedCost;
        private string _cachedDescription;
        private bool _isCacheUpdated;

        /// <summary>
        /// Initialises a new instance of the <see cref="DynamicMachine"/> class.
        /// </summary>
        /// <param name="baseMachine">The base machine to which features will be added.</param>
        public DynamicMachine(IMachine baseMachine)
        {
            _baseMachine = baseMachine ?? throw new ArgumentNullException(nameof(baseMachine));
            _machineManager = new MachineManager();
            _baseCost = _baseMachine.Cost;
            _baseDescription = _baseMachine.Description;
            _isCacheUpdated = false;
        }

        /// <summary>
        /// Adds a new feature to the machine.
        /// If the feature already exists, it will be replaced.
        /// </summary>
        /// <param name="feature">The feature to add.</param>
        public void AddFeature(MachineDecorator feature)
        {
            _machineManager.AddFeature(feature);
            _isCacheUpdated = false;
        }

        /// <summary>
        /// Removes a feature from the machine.
        /// If the feature is not present, nothing happens.
        /// </summary>
        /// <typeparam name="T">The type of the feature to remove.</typeparam>
        public void RemoveFeature<T>() where T : MachineDecorator
        {
            if (_machineManager.RemoveFeature<T>())
                _isCacheUpdated = false;
        }

        /// <summary>
        /// Updates the cached cost and description if the cache is outdated.
        /// </summary>
        private void UpdateCache()
        {
            if (_isCacheUpdated)
                return;

            _cachedCost = _machineManager.GetFeatures().Aggregate(
                _baseCost,
                (totalCost, feature) => totalCost + feature.Cost
            );

            StringBuilder descriptionBuilder = new(_baseDescription);
            foreach (MachineDecorator feature in _machineManager.GetFeatures())
                descriptionBuilder.Append(feature.Description);
            _cachedDescription = descriptionBuilder.ToString();

            _isCacheUpdated = true;
        }

        /// <summary>
        /// Gets the total cost of the machine with all applied features.
        /// </summary>
        /// <returns>The total cost.</returns>
        public double Cost
        {
            get
            {
                UpdateCache();
                return _cachedCost;
            }
        }

        /// <summary>
        /// Gets the description of the machine with all applied features.
        /// </summary>
        /// <returns>The full description.</returns>
        public string Description
        {
            get
            {
                UpdateCache();
                return _cachedDescription;
            }
        }

        /// <summary>
        /// Provides a string representation of the machine, including total cost and description.
        /// </summary>
        /// <returns>A string with the formatted cost and description.</returns>
        public override string ToString()
        {
            UpdateCache();
            return $"Description: {Description}{Environment.NewLine}Total Cost: £{_cachedCost:N0}";
        }
    }
}
