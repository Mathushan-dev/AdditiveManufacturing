using AdditiveManufacturingMachine.Decorators;

namespace AdditiveManufacturingMachine.Managers
{
    /// <summary>
    /// Manages the features applied to a machine.
    /// </summary>
    public class DynamicMachineManager
    {
        private readonly Dictionary<Type, MachineDecorator> _features;

        /// <summary>
        /// Initialises a new instance of the <see cref="DynamicMachineManager"/> class.
        /// </summary>
        public DynamicMachineManager()
        {
            _features = [];
        }

        /// <summary>
        /// Adds or updates a feature in the manager.
        /// </summary>
        /// <param name="feature">The feature to add or update.</param>
        public void AddFeature(MachineDecorator feature)
        {
            ArgumentNullException.ThrowIfNull(feature);

            _features[feature.GetType()] = feature;
        }

        /// <summary>
        /// Removes a feature from the manager.
        /// </summary>
        /// <typeparam name="T">The type of the feature to remove.</typeparam>
        /// <returns>True if the feature was removed; otherwise, false.</returns>
        public bool RemoveFeature<T>() where T : MachineDecorator
        {
            return _features.Remove(typeof(T));
        }

        /// <summary>
        /// Gets all the features managed by this instance.
        /// </summary>
        /// <returns>An enumerable of all features.</returns>
        public IEnumerable<MachineDecorator> GetFeatures()
        {
            return _features.Values;
        }
    }
}
