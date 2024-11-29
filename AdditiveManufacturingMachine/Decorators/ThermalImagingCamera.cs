using AdditiveManufacturingMachine.Interfaces;

namespace AdditiveManufacturingMachine.Decorators
{
    public class ThermalImagingCamera(IMachine machine) : MachineDecorator(machine)
    {
        private readonly double _cost = 54_000;
        private readonly string _description = " with Thermal Imaging Camera";
        public override double Cost => _cost;
        public override string Description => _description;
    }
}
