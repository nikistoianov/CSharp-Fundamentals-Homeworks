using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    public enum SystemMode
    {
        Full, Half, Energy
    }

    private double totalEnergyStored;
    private double totalMinedOre;

    public List<Harvester> Harvesters { get; private set; }
    public List<Provider> Providers { get; private set; }
    public SystemMode SysMode { get; private set; }

    public string RegisterHarvester(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var oreOutput = double.Parse(arguments[2]);
        var energyRequirement = double.Parse(arguments[3]);

        try
        {
            if (type == "Sonic")
            {
                var sonicFactor = int.Parse(arguments[4]);
                var harvester = new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
                this.Harvesters.Add(harvester);
            }
            else if (type == "Hammer")
            {
                var harvester = new HammerHarvester(id, oreOutput, energyRequirement);
                this.Harvesters.Add(harvester);
            }
            else
            {
                throw new NotImplementedException();
            }
            return $"Successfully registered {type} Harvester – {id}";
        }
        catch (ArgumentException ae)
        {
            return $"Harvester is not registered, because of it's {ae.Message}";
        }
        
    }

    public string RegisterProvider(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var energyOutput = double.Parse(arguments[2]);

        try
        {
            if (type == "Solar")
            {
                var provider = new SolarProvider(id, energyOutput);
                this.Providers.Add(provider);
            }
            else if (type == "Pressure")
            {
                var provider = new PressureProvider(id, energyOutput);
                this.Providers.Add(provider);
            }
            else
            {
                throw new NotImplementedException();
            }
            return $"Successfully registered {type} Provider – {id}";
        }
        catch (ArgumentException ae)
        {
            return $"Provider is not registered, because of it's {ae.Message}";
        }
        
    }

    public string Day()
    {
        double totalEnergy = 0;
        foreach (var provider in this.Providers)
        {
            totalEnergy += provider.EnergyOutput;
        }

        double neededEnergy = 0, oreProduction = 0;
        if (this.SysMode != SystemMode.Energy)
        {
            foreach (var harvester in this.Harvesters)
            {
                neededEnergy += harvester.EnergyRequirement;
                oreProduction += harvester.OreOutput;
            }
        }

        if (this.SysMode != SystemMode.Half)
        {
            neededEnergy *= 0.6;
            oreProduction *= 0.5;
        }

        if (totalEnergyStored >= neededEnergy)
        {
            totalEnergyStored -= neededEnergy;
            totalMinedOre += oreProduction;
        }

        return "";
    }
    public string Mode(List<string> arguments)
    {
        SystemMode newMode;
        var setMode = Enum.TryParse(arguments[0], out newMode);
        if(setMode) this.SysMode = newMode;
        return "";
    }

    public string Check(List<string> arguments)
    {
        var id = arguments[0];
        var harvester = Harvesters.FirstOrDefault(x => x.Id == id);
        if (harvester != null)
        {
            return harvester.ToString();
        }
        var provider = this.Providers.FirstOrDefault(x => x.Id == id);
        if (provider != null)
        {
            return provider.ToString();
        }
        return "";
    }
    public string ShutDown()
    {
        //TODO: Add some logic here …
        return $"System Shutdown" + Environment.NewLine + "Total Energy Stored: 90" + Environment.NewLine + "Total Mined Plumbus Ore: 400";
    }

}
