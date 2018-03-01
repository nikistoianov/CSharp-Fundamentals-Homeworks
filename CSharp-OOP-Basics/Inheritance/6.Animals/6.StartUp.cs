using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var animals = new List<Animal>();
        string input;
        while ((input = Console.ReadLine()) != "Beast!")
        {
            try
            {
                var animalType = input;
                switch (animalType)
                {
                    case "Dog":
                        animals.Add(new Dog(Console.ReadLine()));
                        break;
                    case "Cat":
                        animals.Add(new Cat(Console.ReadLine()));
                        break;
                    case "Frog":
                        animals.Add(new Frog(Console.ReadLine()));
                        break;
                    case "Kitten":
                        animals.Add(new Kitten(Console.ReadLine()));
                        break;
                    case "Tomcat":                        
                        animals.Add(new Tomcat(Console.ReadLine()));
                        break;
                    default:
                        Console.ReadLine();
                        throw new ArgumentException("Invalid input!");
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }            
        }

        animals.ForEach(x => Console.WriteLine(x + Environment.NewLine + x.ProduceSound()));
    }
}
