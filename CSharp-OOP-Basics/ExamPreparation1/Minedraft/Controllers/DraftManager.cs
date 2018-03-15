using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    //public enum SystemMode
    //{
    //    Full, Half, Energy
    //}

    private double totalEnergyStored;
    private double totalMinedOre;
    private string mode;
    private List<Harvester> harvesters;

    private HarvesterFactory harvesterFactory;

    //public List<Harvester> Harvesters { get; private set; }
    public List<Provider> Providers { get; private set; }
    //public SystemMode SysMode { get; private set; }

    public DraftManager()
    {
        this.harvesters = new List<Harvester>();
        this.Providers = new List<Provider>();
        this.totalEnergyStored = 0;
        this.totalMinedOre = 0;
        //this.SysMode = SystemMode.Full;
        this.mode = "Full";
    }

    //public string RegisterHarvester(List<string> arguments)
    //{
    //    try
    //    {
    //        Harvester harvester = harvesterFactory.CreateHarvester(arguments);
    //        this.harvesters.Add(harvester);

    //        return $"Successfully registered {arguments[0]} Harvester - {harvester.Id}";
    //    }
    //    catch (ArgumentException ex)
    //    {
    //        return ex.Message;
    //    }
    //}

    public string RegisterHarvester(List<string> arguments)
    {
        //throw new Exception();
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
                this.harvesters.Add(harvester);
            }
            else if (type == "Hammer")
            {
                var harvester = new HammerHarvester(id, oreOutput, energyRequirement);
                this.harvesters.Add(harvester);
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

    //public string Day()
    //{
    //    double orePerDayMined = 0;
    //    double energyPerDayRequired = 0;
    //    double energyPerDayProvided = this.Providers.Sum(p => p.EnergyOutput);
    //    this.totalEnergyStored += energyPerDayProvided;

    //    StringBuilder builder = new StringBuilder();

    //    if (this.mode == "Full")
    //    {
    //        energyPerDayRequired = harvesters.Sum(h => h.EnergyRequirement);
    //        orePerDayMined = harvesters.Sum(h => h.OreOutput);
    //    }
    //    else if (this.mode == "Half")
    //    {
    //        energyPerDayRequired = harvesters.Sum(h => h.EnergyRequirement) * 0.6;
    //        orePerDayMined = harvesters.Sum(h => h.OreOutput) * 0.5;
    //    }
    //    else if (this.mode == "Energy")
    //    {
    //        energyPerDayRequired = 0;
    //        orePerDayMined = 0;
    //    }

    //    if (totalEnergyStored >= energyPerDayRequired)
    //    {
    //        this.totalEnergyStored -= energyPerDayRequired;
    //        this.totalMinedOre += orePerDayMined;
    //    }
    //    else
    //    {
    //        orePerDayMined = 0;
    //    }

    //    builder.AppendLine("A day has passed.");
    //    builder.AppendLine($"Energy Provided: {energyPerDayProvided}");
    //    builder.AppendLine($"Plumbus Ore Mined: {orePerDayMined}");

    //    return builder.ToString().TrimEnd();
    //}

    public string Day()
    {
        var result = new StringBuilder();
        double totalEnergy = this.Providers.Sum(x => x.EnergyOutput);
        this.totalEnergyStored += totalEnergy;
        double neededEnergy = 0, oreProduction = 0;

        //if (this.SysMode != SystemMode.Energy)
        //{
        //    neededEnergy = this.harvesters.Sum(x => x.EnergyRequirement);
        //    oreProduction = this.harvesters.Sum(x => x.OreOutput);
        //}

        //if (this.SysMode == SystemMode.Half)
        //{
        //    neededEnergy *= 0.6;
        //    oreProduction *= 0.5;
        //}

        if (this.mode != "Energy")
        {
            neededEnergy = this.harvesters.Sum(x => x.EnergyRequirement);
            oreProduction = this.harvesters.Sum(x => x.OreOutput);
        }

        if (this.mode == "Half")
        {
            neededEnergy *= 0.6;
            oreProduction *= 0.5;
        }

        if (this.totalEnergyStored >= neededEnergy)
        {
            this.totalEnergyStored -= neededEnergy;
            this.totalMinedOre += oreProduction;
        }
        else
        {
            oreProduction = 0;
        }

        result.AppendLine("A day has passed.");
        result.AppendLine($"Energy Provided: {totalEnergy}");
        result.AppendLine($"Plumbus Ore Mined: {oreProduction}");

        return result.ToString().TrimEnd();
    }

    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];
        return $"Successfully changed working mode to {this.mode} Mode";
    }

    //public string Mode(List<string> arguments)
    //{
    //    SystemMode newMode;
    //    var setMode = Enum.TryParse(arguments[0], out newMode);
    //    if(setMode) this.SysMode = newMode;
    //    return "";
    //}

    public string Check(List<string> arguments)
    {
        var id = arguments[0];
        var harvester = harvesters.FirstOrDefault(x => x.Id == id);
        if (harvester != null)
        {
            return harvester.ToString();
        }
        var provider = this.Providers.FirstOrDefault(x => x.Id == id);
        if (provider != null)
        {
            return provider.ToString();
        }
        return $"No element found with id - {id}";
    }

    //public string Check(List<string> arguments)
    //{
    //    string id = arguments[0];

    //    if (this.Providers.Any(p => p.Id == id))
    //    {
    //        return this.Providers.FirstOrDefault(p => p.Id == id).ToString();
    //    }
    //    else if (this.harvesters.Any(h => h.Id == id))
    //    {
    //        return harvesters.FirstOrDefault(h => h.Id == id).ToString();
    //    }
    //    else
    //    {
    //        return $"No element found with id - {id}";
    //    }
    //}

    public string ShutDown()
    {
        return $"System Shutdown{Environment.NewLine}Total Energy Stored: {this.totalEnergyStored}{Environment.NewLine}Total Mined Plumbus Ore: {this.totalMinedOre}";
    }

}
