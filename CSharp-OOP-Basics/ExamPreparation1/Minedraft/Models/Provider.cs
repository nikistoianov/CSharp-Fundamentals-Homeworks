using System;
using System.Collections.Generic;
using System.Text;

public class Provider
{
    public string Id { get; set; }

    private double energyOutput;

    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            if (value < 0 || value >= 10000)
            {
                throw new ArgumentException("invalid energyOutput!");
            }
            energyOutput = value;
        }
    }

    public Provider(string id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
    }
}