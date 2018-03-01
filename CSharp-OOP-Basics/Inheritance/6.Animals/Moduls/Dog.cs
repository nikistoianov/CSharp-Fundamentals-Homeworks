using System;
using System.Collections.Generic;
using System.Text;

public class Dog : Animal
{
    public Dog(string animalLine) : base(animalLine)
    {
    }

    public override string ProduceSound()
    {
        return "Woof!";
    }

    public override string ToString()
    {
        return "Dog" + Environment.NewLine + base.ToString();
    }
}
