using AdditiveManufacturingMachine.Interfaces;

namespace AdditiveManufacturingMachine.Decorators
{
    public class Photodiodes(IMachine machine) : MachineDecorator(machine)
    {
        private readonly double _cost = 63_000;
        private readonly string _description = " with Photodiodes";
        public override double Cost => _cost;
        public override string Description => _description;
    }
}
