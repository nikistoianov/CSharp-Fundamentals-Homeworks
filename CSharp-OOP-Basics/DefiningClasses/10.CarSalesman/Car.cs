using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class Car
{
    public string Model { get; set; }
    public Engine CarEngine { get; set; }
    public string Weight { get; set; }
    public string Color { get; set; }

    public Car()
    {
        Weight = "n/a";
        Color = "n/a";
    }

    public Car(string carLine, Dictionary<string, Engine> engines) : this()
    {
        var args = carLine.Split();
        Model = args[0];
        CarEngine = engines[args[1]];
        if (args.Length > 2)
        {
            if (Regex.Match(args[2], "^[0-9]+$").Success)
            {

            }
        }
        Weight = args.Length > 2 && args[2] != "" ? args[2] : "n/a";
        Color = args.Length > 3 && args[3] != "" ? args[3] : "n/a";
        
    }



    public override string ToString()
    {
        return $"{Model}:\r\n  {CarEngine}\r\n  Weight: {Weight}\r\n  Color: {Color}";
    }
}
