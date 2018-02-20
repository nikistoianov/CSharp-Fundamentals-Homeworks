using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var cats = new Dictionary<string, Cat>();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var cat = new Cat(input);
            cats.Add(cat.Name, cat);
        }

        input = Console.ReadLine();
        Console.WriteLine(cats[input]);
    }
}
