namespace zadanie1;

public class HazardousLiquidContainer : LiquidContainer
{
    public HazardousLiquidContainer(float height, float weight, float depth, float maxLoadCapacity) : base(height, weight, depth, maxLoadCapacity)
    {
    }
    
    public override void Load(float mass)
    {
        LoadCheck(mass);
        
        if (mass > MaxLoadCapacity * 0.5)
        {
            Notify("Hazardous liquid container loaded up to more than 50% of the maximum load capacity");
        }
        
        Mass = mass;
    }
}