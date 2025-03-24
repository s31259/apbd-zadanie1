namespace zadanie1;

public class Product
{
    public string Name { get; private set; }
    public float Temperature { get; private set; }

    public Product(string name, float temperature)
    {
        Name = name;
        Temperature = temperature;
    }
}