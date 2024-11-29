using AdditiveManufacturingMachine.Interfaces;

namespace AdditiveManufacturingMachine.Decorators
{
    /// <summary>
    /// Serves as the base class for all machine decorators that extend the functionality of a machine.
    /// </summary>
    /// <remarks>
    /// This class implements the <see cref="IMachine"/> interface and delegates core functionality to the wrapped machine instance.
    /// Derived classes should override <see cref="GetCost"/> and <see cref="GetDescription"/> to add feature-specific behavior.
    /// Initialises a new instance of the <see cref="MachineDecorator"/> class.
    /// </remarks>
    /// <param name="machine">The machine instance to decorate.</param>
    /// <exception cref="ArgumentNullException">Thrown if the <paramref name="machine"/> is null.</exception>
    public abstract class MachineDecorator(IMachine machine) : IMachine
    {
        /// <summary>
        /// The wrapped machine instance to which the decorator adds functionality.
        /// </summary>
        protected readonly IMachine _machine = machine ?? throw new ArgumentNullException(nameof(machine));
        public abstract double Cost { get; }
        public abstract string Description { get; }
    }
}
