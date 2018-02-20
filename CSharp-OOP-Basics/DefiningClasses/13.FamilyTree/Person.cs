using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class Person
{
    public string Name { get; set; }
    public string BirthDay { get; set; }
    List<Person> parents;
    List<Person> children;
    public List<Person> test { get; set; }

    public List<Person> Parents { get { return parents; } }
    public List<Person> Children { get { return children; } }

    public Person()
    {
        parents = new List<Person>();
        children = new List<Person>();
        Name = "";
        BirthDay = "";
    }

    public Person(string nameOrBirthDay) : this()
    {
        if (Regex.Match(nameOrBirthDay, @"^[0-9]+\/[0-9]+\/[0-9]+$").Success)
            BirthDay = nameOrBirthDay;
        else
            Name = nameOrBirthDay;
    }

    public Person(string name, string birthDay) : this()
    {
        BirthDay = birthDay;
        Name = name;
    }

    public void Update(Person person)
    {
        if (person.Name != "")
        {
            Name = person.Name;
        }
        if (person.BirthDay != "")
        {
            BirthDay = person.BirthDay;
        }
        if (person.parents.Count > 0)
        {
            parents.AddRange(person.parents);
        }
        if (person.children.Count > 0)
        {
            children.AddRange(person.children);
        }
    }

    public void AddParent(Person parent)
    {
        parents.Add(parent);
    }

    public void AddChild(Person child)
    {
        children.Add(child);
    }

    public override string ToString()
    {
        return $"{Name} {BirthDay}";
    }
}
