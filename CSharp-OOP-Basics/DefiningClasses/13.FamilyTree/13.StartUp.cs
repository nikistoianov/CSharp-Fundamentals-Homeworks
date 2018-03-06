using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main_()
    {
        var people = new List<Person>();
        var firstPerson = new Person("Az", "28/2/1980");
        var secondPerson = new Person("Ti", "1/1/2000");
        firstPerson.test = new List<Person>();
        firstPerson.test.Add(secondPerson);
        people.Add(firstPerson);
        people.Add(new Person());
        people.Add(secondPerson);
        
        firstPerson.Name = "SSS";
        people[2].Name = "Change";
        people.RemoveAt(1);
        people[1].Name = "New";
    }

    static void Main()
    {
        var people = new List<Person>();
        string input = Console.ReadLine();
        var mainPerson = new Person(input);

        input = "";
        while ((input = Console.ReadLine()) != "End")
        {
            var args = input.Split(new string[] { " - " }, StringSplitOptions.None);
            if (args.Length == 1)
            {
                var splitInput = input.Split();
                var person = new Person(splitInput[0] + " " + splitInput[1], splitInput[2]);                
                UpdatePerson(person, people);
            }
            else
            {
                var parent = new Person(args[0]);
                var child = new Person(args[1]);

                var parentId = FindPersonId(parent, people);
                var childId = FindPersonId(child, people);

                if (parentId == -1)
                {
                    people.Add(parent);
                    parentId = people.Count - 1;
                }

                if (childId == -1)
                {
                    people.Add(child);
                    childId = people.Count - 1;
                }

                people[parentId].AddChild(child);
                people[childId].AddParent(parent);
            }
        }

        mainPerson = people.Where(x => x.Name == mainPerson.Name || x.BirthDay == mainPerson.BirthDay).ToList()[0];

        Console.WriteLine(mainPerson);
        Console.WriteLine("Parents:");
        foreach (var parent in mainPerson.Parents)
        {
            Console.WriteLine(parent);
        }
        Console.WriteLine("Children:");
        foreach (var child in mainPerson.Children)
        {
            Console.WriteLine(child);
        }
    }

    public static void UpdatePerson(Person person, List<Person> people)
    {
        var foundPeople = people.Where(x => x.Name == person.Name || x.BirthDay == person.BirthDay).ToList();
        if (foundPeople.Count == 0)
        {
            people.Add(person);
            return;
        }

        foundPeople[0].Update(person);

        if (foundPeople.Count == 2)
        {
            foundPeople[0].Update(foundPeople[1]);
            foundPeople[1].Update(foundPeople[0]);
            people.Remove(foundPeople[1]);
        }
        //foreach (var foundPerson in foundPeople)
        //{
        //    person.Update(foundPerson);
        //}
        //people = people.Where(x => x.Name != person.Name && x.BirthDay != person.BirthDay).ToList();
        //people.Add(person);
    }

    public static int FindPersonId(Person person, List<Person> people)
    {
        for (int i = 0; i < people.Count; i++)
        {
            if ((person.Name != "" && person.Name == people[i].Name) || (person.BirthDay != "" && person.BirthDay == people[i].BirthDay))
            {
                return i;
            }
        }
        return -1;
    }
}
