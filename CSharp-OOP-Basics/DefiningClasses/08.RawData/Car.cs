using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    public string Model { get; set; }
    public Engine CarEngine { get; set; }
    public Cargo CarCargo { get; set; }
    public Tire[] Tires { get; set; }

    public Car(string carLine)
    {
        var carArgs = carLine.Split();
        Model = carArgs[0];
        CarEngine = new Engine(int.Parse(carArgs[1]), int.Parse(carArgs[2]));
        CarCargo = new Cargo(int.Parse(carArgs[3]), carArgs[4]);
        Tires = new Tire[4];
        for (int i = 0; i < 4; i++)
        {
            Tires[i] = new Tire(double.Parse(carArgs[i * 2 + 5]), int.Parse(carArgs[i * 2 + 6]));
        }
    }

    public class Engine
    {
        public int Speed { get; set; }
        public int Power { get; set; }

        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }
    }

    public class Cargo
    {
        public int Weight { get; set; }
        public string Type { get; set; }

        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }
    }

    public class Tire
    {
        public double Pressure { get; set; }
        public int Age { get; set; }

        public Tire(double pressure, int age)
        {
            Pressure = pressure;
            Age = age;
        }
    }
}