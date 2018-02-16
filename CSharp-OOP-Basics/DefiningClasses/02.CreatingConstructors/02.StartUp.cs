using System;

class Program
{
    static void Main()
    {
        var firstPerson = new Person();
        firstPerson.Name = "Pesho";
        firstPerson.Age = 20;
        var secondPerson = new Person(18, "Gosho");
        var thirdPerson = new Person(43);
        thirdPerson.Name = "Stamat";
    }
}

