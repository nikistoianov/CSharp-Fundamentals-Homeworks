using System;
using System.Collections.Generic;
using System.Text;

public class Frog : Animal
{
    public Frog(string animalLine) : base(animalLine)
    {
    }

    public override string ProduceSound()
    {
        return "Ribbit";
    }

    public override string ToString()
    {
        return "Frog" + Environment.NewLine + base.ToString();
    }
}
