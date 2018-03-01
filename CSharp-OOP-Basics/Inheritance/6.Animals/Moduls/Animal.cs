using System;
using System.Collections.Generic;
using System.Text;

public abstract class Animal : ISoundProducable
{
    private string name;

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid input!");
            }
            name = value;
        }
    }

    private int age;

    public int Age
    {
        get { return age; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Invalid input!");
            }
            age = value;
        }
    }

    private string gender;

    public string Gender
    {
        get { return gender; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid input!");
            }
            gender = value;
        }
    }

    public Animal(string animalLine) : this(animalLine.Split()) { }

    public Animal(string[] args)
    {
        if (args.Length < 3)
        {
            throw new ArgumentException("Invalid input!");
        }
        Name = args[0];
        Age = int.Parse(args[1]);
        Gender = args[2];
    }
    
    public virtual string ProduceSound()
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return $"{Name} {Age} {Gender}";
    }
}
