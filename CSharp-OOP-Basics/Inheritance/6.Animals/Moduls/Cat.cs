using System;
using System.Collections.Generic;
using System.Text;

public class Cat : Animal
{
    public Cat(string animalLine) : base(animalLine)
    {
    }

    public override string ProduceSound()
    {
        return "Meow meow";
    }

    public override string ToString()
    {
        return "Cat" + Environment.NewLine + base.ToString();
    }
}