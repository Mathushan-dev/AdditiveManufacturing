namespace AdditiveManufacturingMachine.Interfaces
{
    /// <summary>
    /// Defines the contract for a machine in the additive manufacturing system.
    /// </summary>
    /// <remarks>
    /// All machine implementations must provide methods to retrieve the cost and description.
    /// </remarks>
    public interface IMachine
    {
        /// <summary>
        /// Gets the cost of the machine.
        /// </summary>
        /// <returns>The cost as a <see cref="double"/>.</returns>
        double Cost { get; }

        /// <summary>
        /// Gets a description of the machine.
        /// </summary>
        /// <returns>The description as a <see cref="string"/>.</returns>
        string Description { get; }
    }
}
