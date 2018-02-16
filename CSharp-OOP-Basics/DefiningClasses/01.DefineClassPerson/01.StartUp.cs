using System;

class Program
{
    static void Main(string[] args)
    {
        var firstPerson = new Person();
        firstPerson.Name = "Pesho";
        firstPerson.Age = 20;
        var secondPerson = new Person() { Name = "Gosho", Age = 18 };
        var thirdPerson = new Person() { Name = "Stamat" };
        thirdPerson.Age = 43;
    }
}

