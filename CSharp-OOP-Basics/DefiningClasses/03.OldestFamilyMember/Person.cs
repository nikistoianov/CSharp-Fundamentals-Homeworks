using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private int age;

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Person()
    {
        name = "No name";
        age = 1;
    }

    public Person(int age) : this()
    {
        this.age = age;
    }

    public Person(int age, string name) : this(age)
    {
        this.name = name;
    }

    public Person(string[] personArgs) : this(int.Parse(personArgs[1]), personArgs[0]) { }

    public Person(string personLine) : this(personLine.Split()) { }

    public override string ToString()
    {
        return $"{name} {age}";
    }

}

