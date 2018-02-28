using System;
using System.Collections.Generic;
using System.Text;

public class Child : Person
{
    //private int age;
    private const int MAX_CHILD_AGE = 15;

    public override int Age
    {
        get { return base.Age; }
        set
        {
            if (value > MAX_CHILD_AGE)
            {
                throw new ArgumentException($"Child's age must be less than {MAX_CHILD_AGE}!");
            }
            base.Age = value;
        }
    }

    public Child(string name, int age) : base(name, age)
    {
        Name = name;
        Age = age;
    }
}