using System;
using System.Collections.Generic;
using System.Text;

public class Tomcat : Animal
{
    public Tomcat(string animalLine) : base(animalLine)
    {
        Gender = "Male";
    }

    public override string ProduceSound()
    {
        return "MEOW";
    }

    public override string ToString()
    {
        return "Tomcat" + Environment.NewLine + base.ToString();
    }
}
