using AdditiveManufacturingMachine.Interfaces;

namespace AdditiveManufacturingMachine.Decorators
{
    public class QuadLaser(IMachine machine) : MachineDecorator(machine)
    {
        private readonly double _cost = 225_000;       
        private readonly string _description = " with Quad Laser";
        public override double Cost => _cost;
        public override string Description => _description;
    }
}
