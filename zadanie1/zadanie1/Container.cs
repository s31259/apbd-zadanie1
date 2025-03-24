namespace zadanie1;

public class Container
{
    public float Mass { get; set; }
    public float Height { get; set; }
    public float Weight { get; set; }
    public float Depth { get; set; }
    public string SerialNumber { get; set; }
    protected static int SerialNumberCounter = 1;
    public float MaxLoadCapacity { get; set; }

    public Container(string tag, float height, float weight, float depth, float maxLoadCapacity)
    {
        Mass = 0;
        Height = height;
        Weight = weight;
        Depth = depth;
        SerialNumber = "KON-" + tag + "-" + SerialNumberCounter++;
        MaxLoadCapacity = maxLoadCapacity;
    }
    
    public virtual void Deload()
    {
        Mass = 0;
    }

    public virtual void Load(float mass)
    {
        LoadCheck(mass);
        Mass = mass;
    }

    protected void LoadCheck(float mass)
    {
        if (Mass != 0)
        {
            throw new LoadException("Container should be empty to get load");
        }
        if (mass > MaxLoadCapacity)
        {
            throw new OverfillException("Too heavy load");
        }
    }

    public override string ToString()
    {
        return "[" + SerialNumber + "]" + " - current load: " + Mass + " kg; height: " + Height + " cm; weight: " + 
               Weight + " kg; depth: " + Depth + " cm; load capacity limit: " + MaxLoadCapacity + " kg";
    }
}