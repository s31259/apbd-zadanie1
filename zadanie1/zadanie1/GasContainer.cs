namespace zadanie1;

public class GasContainer : Container, IHazardNotifier
{   
    public float Pressure { get; set; }
    
    public GasContainer(float height, float weight, float depth, float maxLoadCapacity, float pressure) : base("G", height, weight, depth, maxLoadCapacity)
    {
        Pressure = pressure;
    }

    public void Notify(string msg)
    {
        Console.WriteLine("[" + SerialNumber + "]" + " - dangerous event -> " + msg);
    }
    
    //klasa Container ma juz implementacje zwracania bledu przy przekroczeniu dopuszczalnej ladownosci, chyba ze chodzi o uzycie metody Notify
    //ale w poleceniu jest napisane zeby zwrocic blad

    public override void Deload()
    {
        Mass = 0.05f * Mass;
    }

    public override string ToString()
    {
        return base.ToString() + "; pressure: " + Pressure + " atm";
    }
}