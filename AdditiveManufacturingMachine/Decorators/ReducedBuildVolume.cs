using AdditiveManufacturingMachine.Interfaces;

namespace AdditiveManufacturingMachine.Decorators
{
    public class ReducedBuildVolume(IMachine machine) : MachineDecorator(machine)
    {
        private readonly double _cost = 75_000; 
        private readonly string _description = " with Reduced Build Volume";
        public override double Cost => _cost;
        public override string Description => _description;
    }
}
