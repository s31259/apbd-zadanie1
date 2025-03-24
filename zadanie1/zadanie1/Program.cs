using System.Numerics;

namespace  zadanie1;

public class Program
{
    public static void Main(string[] args)
    {
        Container liquidContainer = new LiquidContainer(1200, 20, 1400, 50);
        Container hazardousLiquidContainer = new HazardousLiquidContainer(1100, 30, 1500, 60);
        Container gasContainer = new GasContainer(1225, 40, 1225, 30, 35);
        Container coolingContainer = new CoolingContainer(1000, 40, 1000, 20, new Product("Apple", 2), 3);
        
        Console.WriteLine(liquidContainer);
        liquidContainer.Load(49);
        Console.WriteLine(liquidContainer);
        liquidContainer.Deload();
        Console.WriteLine(liquidContainer);
        
        Console.WriteLine(hazardousLiquidContainer);
        hazardousLiquidContainer.Load(32);
        Console.WriteLine(hazardousLiquidContainer);
        hazardousLiquidContainer.Deload();
        Console.WriteLine(hazardousLiquidContainer);
        
        Console.WriteLine(gasContainer);
        Console.WriteLine(coolingContainer);
        
        liquidContainer.Load(10);
        hazardousLiquidContainer.Load(20);
        //gasContainer.Load(31);
        gasContainer.Load(30);
        Console.WriteLine(gasContainer);
        gasContainer.Deload();
        Console.WriteLine(gasContainer);
        coolingContainer.Load(15);
        
        Console.WriteLine(liquidContainer);
        Console.WriteLine(hazardousLiquidContainer);
        Console.WriteLine(coolingContainer);
        Console.WriteLine(gasContainer);

        var ship = new Ship("ship1", 10, 6, 130);
        Console.WriteLine(ship);
        
        ship.AddContainer(liquidContainer);
        Console.WriteLine(ship);
        
        List<Container> containersToAdd = [liquidContainer, hazardousLiquidContainer, gasContainer];
        ship.AddContainers(containersToAdd);
        Console.WriteLine(ship);
        //ship.AddContainer(coolingContainer);
        
        ship.DeleteContainer(hazardousLiquidContainer);
        Console.WriteLine(ship);
        
        ship.ReplaceContainer(hazardousLiquidContainer, "KON-L-1");
        Console.WriteLine(ship);
        
        var ship2 = new Ship("ship2", 20, 3, 200);
        
        Console.WriteLine(ship2);
        
        ship.ShiftContainer(ship2, hazardousLiquidContainer);
        
        Console.WriteLine(ship);
        Console.WriteLine(ship2);
        
        ship.ShiftContainer(ship2, gasContainer);
        Console.WriteLine(ship2);
        
        ship2.AddContainer(liquidContainer);
        //ship2.AddContainer(coolingContainer);
        
        Console.WriteLine(ship2);
    }
}