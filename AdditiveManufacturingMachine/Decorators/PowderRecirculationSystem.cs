using AdditiveManufacturingMachine.Interfaces;

namespace AdditiveManufacturingMachine.Decorators
{
    public class PowderRecirculationSystem(IMachine machine) : MachineDecorator(machine)
    {
        private readonly double _cost = 82_000;
        private readonly string _description = " with Powder Recirculation System";
        public override double Cost => _cost;
        public override string Description => _description;
    }
}
