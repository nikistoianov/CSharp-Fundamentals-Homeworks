using System;
using System.Collections.Generic;
using System.Text;

public class Product
{
    private string name;
    private double cost;

    public string Name
    {
        get { return name; }
        private set
        {
            if (value == null || value.Trim() == "")
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }

    public double Cost
    {
        get { return cost; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Cost cannot be a negative");
            }
            cost = value;
        }
    }

    public Product(string name, double cost)
    {
        Name = name;
        Cost = cost;
    }

    public Product(string[] args) : this(args[0], double.Parse(args[1])) { }

    public Product(string productInput) : this(productInput.Split('=')) { }

    public override string ToString()
    {
        return Name;
    }
}
