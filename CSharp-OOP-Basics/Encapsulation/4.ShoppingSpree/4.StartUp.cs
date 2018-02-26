using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var peopleInput = Console.ReadLine().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
        var productsInput = Console.ReadLine().Split(new string[] {";"}, StringSplitOptions.RemoveEmptyEntries);

        var people = new List<Person>();
        var products = new List<Product>();

        try
        {
            foreach (var personInput in peopleInput)
            {
                people.Add(new Person(personInput));
            }

            foreach (var productInput in productsInput)
            {
                products.Add(new Product(productInput));
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var cmdSplit = command.Split();
                var person = people.FirstOrDefault(x => x.Name == cmdSplit[0]);
                var product = products.FirstOrDefault(x => x.Name == cmdSplit[1]);
                Console.WriteLine(person.BuyProduct(product));
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
}
