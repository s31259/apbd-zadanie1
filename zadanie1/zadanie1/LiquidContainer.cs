namespace zadanie1;

public class LiquidContainer : Container, IHazardNotifier
{
    public LiquidContainer(float height, float weight, float depth, float maxLoadCapacity) : base("L", height, weight, depth, maxLoadCapacity)
    {
    }
    public void Notify(string msg)
    {
        Console.WriteLine("[" + SerialNumber + "]" + " - dangerous event -> " + msg);
    }
    
    public override void Load(float mass)
    {
        LoadCheck(mass);
        
        if (mass > MaxLoadCapacity * 0.9)
        {
            Notify("Liquid container loaded up to more than 90% of the maximum load capacity");
        }
        
        Mass = mass;
    }
}