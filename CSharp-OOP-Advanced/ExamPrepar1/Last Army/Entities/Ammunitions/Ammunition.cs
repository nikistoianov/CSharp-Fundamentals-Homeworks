using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Ammunition : IAmmunition
{
    public string Name { get; private set; }
    public double Weight { get; private set; }
    public double WearLevel { get; }
    public void DecreaseWearLevel(double wearAmount)
    {
        throw new NotImplementedException();
    }

    public Ammunition(string name, double weight)
    {
        this.Weight = weight;
        this.Name = name;
    }
}