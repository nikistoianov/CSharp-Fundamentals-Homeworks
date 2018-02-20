using System;
using System.Collections.Generic;
using System.Text;

public class Cat
{
    public string Name { get; set; }
    public string Breed { get; set; }

    int earSize;
    double furLength;
    int decibelsOfMeows;

    public Cat(string catLine)
    {
        var args = catLine.Split();
        Breed = args[0];
        Name = args[1];
        switch (Breed)
        {
            case "StreetExtraordinaire":
                decibelsOfMeows = int.Parse(args[2]);
                break;
            case "Siamese":
                earSize = int.Parse(args[2]);
                break;
            case "Cymric":
                furLength = double.Parse(args[2]);
                break;
            default:
                break;
        }
    }

    public override string ToString()
    {
        switch (Breed)
        {
            case "StreetExtraordinaire":
                return $"{Breed} {Name} {decibelsOfMeows}";
            case "Siamese":
                return $"{Breed} {Name} {earSize}";
            case "Cymric":
                return $"{Breed} {Name} {furLength:F2}";
            default:
                throw new NotImplementedException();
        }
    }
}
