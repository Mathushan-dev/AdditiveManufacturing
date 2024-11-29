using AdditiveManufacturingMachine.Decorators;
using AdditiveManufacturingMachine.Interfaces;
using AdditiveManufacturingMachine.Models;

class Program
{
    static void Main(string[] args)
    {
        IMachine baseMachine = new MediumPowerMachine();

        DynamicMachine dynamicMachine = new DynamicMachine(baseMachine);

        dynamicMachine.AddFeature(new ReducedBuildVolume(baseMachine));
        dynamicMachine.AddFeature(new QuadLaser(baseMachine));
        dynamicMachine.AddFeature(new PowderRecirculationSystem(baseMachine));

        Console.WriteLine(dynamicMachine);

        dynamicMachine.RemoveFeature<ReducedBuildVolume>();

        Console.WriteLine(dynamicMachine);
    }
}
