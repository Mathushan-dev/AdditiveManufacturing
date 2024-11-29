using AdditiveManufacturingMachine.Interfaces;

namespace AdditiveManufacturingMachine.Models
{
    public class MediumPowerMachine : IMachine
    {
        private readonly double _cost = 550_000;
        private readonly string _description = "Medium Power Machine";
        public double Cost => _cost;
        public string Description => _description;
    }
}
