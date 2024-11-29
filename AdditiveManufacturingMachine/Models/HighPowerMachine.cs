using AdditiveManufacturingMachine.Interfaces;

namespace AdditiveManufacturingMachine.Models
{
    public class HighPowerMachine : IMachine
    {
        private readonly double _cost = 750_000;
        private readonly string _description = "High Power Machine";
        public double Cost => _cost;
        public string Description => _description;
    }
}
