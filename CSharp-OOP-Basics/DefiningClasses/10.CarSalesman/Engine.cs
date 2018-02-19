using System;
using System.Collections.Generic;
using System.Text;

public class Engine
{
    public string Model { get; set; }
    public string Power { get; set; }
    public string Displacement { get; set; }
    public string Efficiency { get; set; }

    public Engine(string engineLine)
    {
        var args = engineLine.Split();
        Model = args[0];
        Power = args[1];
        Displacement = args.Length > 2 && args[2] != "" ? args[2] : "n/a";
        Efficiency = args.Length > 3 && args[3] != "" ? args[3] : "n/a";
    }

    public override string ToString()
    {
        return $"{Model}:\r\n    Power: {Power}\r\n    Displacement: {Displacement}\r\n    Efficiency: {Efficiency}";
    }
}
