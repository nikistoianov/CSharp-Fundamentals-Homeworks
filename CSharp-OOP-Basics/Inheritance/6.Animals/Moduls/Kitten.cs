using System;
using System.Collections.Generic;
using System.Text;

public class Kitten : Animal
{
    public Kitten(string animalLine) : base(animalLine)
    {
        Gender = "Female";
    }

    public override string ProduceSound()
    {
        return "Meow";
    }

    public override string ToString()
    {
        return "Kitten" + Environment.NewLine + base.ToString();
    }
}
