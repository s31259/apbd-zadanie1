using System.Security;

namespace zadanie1;

public class Ship
{
    public string Name {get; set;}
    public List<Container> Containers { get; set; }
    public float MaxSpeed { get; set; }
    public int MaxContainersAmount { get; set; }
    public float MaxWeight { get; set; }

    public Ship(string name, float maxSpeed, int maxContainersAmount, float maxWeight)
    {
        Name = name;
        Containers = new List<Container>();
        MaxSpeed = maxSpeed;
        MaxContainersAmount = maxContainersAmount;
        MaxWeight = maxWeight;
    }

    public void AddContainer(Container container)
    {
        QuantityCheck();
        WeightCheck(container);
        if (!Containers.Contains(container))
        {
            Containers.Add(container);
        }
    }

    public void AddContainers(List<Container> containers)
    {
        QuantityCheck(containers);
        WeightCheck(containers);
        
        foreach (var container in containers) 
        {
            if (!Containers.Contains(container))
            {
                Containers.Add(container);
            }
        }
    }

    public void DeleteContainer(Container container)
    {
        Containers.Remove(container);
    }

    public void ReplaceContainer(Container container, String serialNumber)
    {
        foreach (var con in Containers)
        {
            if (con.SerialNumber == serialNumber)
            {
                DeleteContainer(con);
                AddContainer(container);
                return;
            }
        }
        Console.WriteLine("There is no container " + serialNumber +" on ship:\n-> " + this + " <-");
    }

    public void ShiftContainer(Ship ship, Container container)
    {
        if (Containers.Contains(container))
        {
            DeleteContainer(container);
            ship.AddContainer(container);
            return;
        }
        Console.WriteLine("There is no container " + container.SerialNumber +" on ship:\n-> " + this + " <-");
    }

    public override string ToString()
    {
        var serialNumbers = "";

        for (int i = 0; i < Containers.Count; i++)
        {
            if (i < Containers.Count - 1)
            {
                serialNumbers += Containers[i].SerialNumber + ", ";
            }
            else
            {
                serialNumbers += Containers[i].SerialNumber;
            }
        }

        return "[" + Name + "] - current containers: " + Containers.Count + " -> { " + serialNumbers + " }" + "; current containers weight: " + ContainersWeight() + " kg; speed limit: " + 
               MaxSpeed + " kt; containers limit: " + MaxContainersAmount + "; weight limit: " + MaxWeight + " kg";
    }

    private float ContainersWeight()
    {
        float totalContainersWeight = 0;
        
        foreach (var container in Containers)
        {
            totalContainersWeight += container.Mass + container.Weight;
        }
        
        return totalContainersWeight;
    }

    private void QuantityCheck()
    {
        if (Containers.Count + 1 > MaxContainersAmount)
        {
            throw new QuantityException("Additional container can't be added, amount of containers on ship would be too high");
        }
    }
    
    private void QuantityCheck(List<Container> newContainers)
    {
        if (Containers.Count + newContainers.Count > MaxContainersAmount)
        {
            throw new QuantityException("Additional containers can't be added, amount of containers on ship would be too high");
        }
    }
    
    private void WeightCheck(Container newContainer)
    {
        float summedWeight = ContainersWeight();

        if (!Containers.Contains(newContainer))
        {
            summedWeight += newContainer.Mass + newContainer.Weight;
        }

        if (summedWeight > MaxWeight)
        {
            throw new OverfillException("Additional container can't be added, summed weight (" + summedWeight + " kg) of containers on ship would be too high");
        }
    }
    
    private void WeightCheck(List<Container> newContainers)
    {
        float summedWeight = ContainersWeight();
        
        foreach (var container in newContainers)
        {
            if (!Containers.Contains(container))
            {
                summedWeight += container.Mass + container.Weight;
            }
        }

        if (summedWeight > MaxWeight)
        {
            throw new OverfillException("Additional containers can't be added, summed weight (" + summedWeight + " kg) of containers on ship would be too high");
        }
    }
}