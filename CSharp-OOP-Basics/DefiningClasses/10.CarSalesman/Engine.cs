using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class Engine
{
    public string Model { get; set; }
    public string Power { get; set; }
    public string Displacement { get; set; }
    public string Efficiency { get; set; }

    public Engine()
    {
        Displacement = "n/a";
        Efficiency = "n/a";
    }

    public Engine(string engineLine) : this()
    {
        var args = engineLine.Split();
        Model = args[0];
        Power = args[1];
        if (args.Length > 2 && args[2] != "")
        {
            if (Regex.Match(args[2], "^[0-9]+$").Success)
            {
                Displacement = args[2];
            }
            else
            {
                Efficiency = args[2];
            }
        }

        if (args.Length > 3 && args[3] != "")
        {
            if (Regex.Match(args[3], "^[0-9]+$").Success)
            {
                Displacement = args[3];
            }
            else
            {
                Efficiency = args[3];
            }
        }
        //Displacement = args.Length > 2 && args[2] != "" ? args[2] : "n/a";
        //Efficiency = args.Length > 3 && args[3] != "" ? args[3] : "n/a";
    }

    public override string ToString()
    {
        return $"{Model}:\r\n    Power: {Power}\r\n    Displacement: {Displacement}\r\n    Efficiency: {Efficiency}";
    }
}
