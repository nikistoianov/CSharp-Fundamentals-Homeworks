using System;
using System.Collections.Generic;
using System.Text;

public class Harvester
{

    public string Id { get; set; }

    private double oreOutput;

    public double OreOutput
    {
        get { return oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("oreOutput cannot be negative!");
            }
            oreOutput = value;
        }
    }

    private double energyRequirement;

    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException("invalid energyRequirement!");
            }
            energyRequirement = value;
        }
    }

    public Harvester(string id, double oreOutput, double energyRequirement)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }
}
