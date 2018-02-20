using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    public string Name { get; set; }
    public Company company;
    public List<Pokemon> pokemons;
    public List<Relative> parents;
    public List<Relative> children;
    public Car car;

    public Person(string name)
    {
        Name = name;
        pokemons = new List<Pokemon>();
        parents = new List<Relative>();
        children = new List<Relative>();
    }

    public void ApplyInfo(string infoName, string[] infoArgs)
    {
        switch (infoName)
        {
            case "company":
                company = new Company(infoArgs);
                break;
            case "pokemon":
                pokemons.Add(new Pokemon(infoArgs));
                break;
            case "parents":
                parents.Add(new Relative(infoArgs));
                break;
            case "children":
                children.Add(new Relative(infoArgs));
                break;
            case "car":
                car = new Car(infoArgs);
                break;
        }
    }

    public override string ToString()
    {
        return $"{Name}\r\nCompany:{company}\r\nCar:{car}\r\nPokemon:{GetPokemons()}\r\nParents:{GetRelatives(parents)}\r\nChildren:{GetRelatives(children)}";
    }

    private string GetPokemons()
    {
        if (pokemons.Count == 0)
        {
            return "";
        }
        return string.Join("", pokemons);
    }

    private string GetRelatives(List<Relative> relatives)
    {
        if (relatives.Count == 0)
        {
            return "";
        }
        return string.Join("", relatives);
    }

    public class Company
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }

        public Company(string[] args)
        {
            Name = args[0];
            Department = args[1];
            Salary = double.Parse(args[2]);
        }

        public override string ToString()
        {
            return $"\r\n{Name} {Department} {Salary:F2}";
        }
    }

    public class Pokemon
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public Pokemon(string[] args)
        {
            Name = args[0];
            Type = args[1];
        }

        public override string ToString()
        {
            return $"\r\n{Name} {Type}";
        }
    }

    public class Relative
    {
        public string Name { get; set; }
        public string BirthDay { get; set; }

        public Relative(string[] args)
        {
            Name = args[0];
            BirthDay = args[1];
        }

        public override string ToString()
        {
            return $"\r\n{Name} {BirthDay}";
        }
    }
    
    public class Car
    {
        public string Model { get; set; }
        public int Speed { get; set; }

        public Car(string[] args)
        {
            Model = args[0];
            Speed = int.Parse(args[1]);
        }

        public override string ToString()
        {
            return $"\r\n{Model} {Speed}";
        }
    }
}
