using AdditiveManufacturingMachine.Interfaces;

namespace AdditiveManufacturingMachine.Models
{
    public class LowPowerMachine : IMachine
    {
        private readonly double _cost = 450_000;
        private readonly string _description = "Low Power Machine";
        public double Cost => _cost;
        public string Description => _description;
    }
}
