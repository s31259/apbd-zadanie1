namespace zadanie1;

public class CoolingContainer : Container
{
    public Product Product { get; set; }
    public float Temperature { get; set; }
    
    public CoolingContainer(float height, float weight, float depth, float maxLoadCapacity, Product product, float temperature) : base("C", height, weight, depth, maxLoadCapacity)
    {
        if (product.Temperature > temperature)
        {
            throw new LowTemparatureException("Container temperature is too low for the product");
        }
        Product = product;
        Temperature = temperature;
    }
    
    public override string ToString()
    {
        return base.ToString() + "; product: " + Product.Name + "; temperature: " + Temperature;
    }
}