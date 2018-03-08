using System;

class Program
{
    static void Main()
    {
        var arr = Console.ReadLine().Split();
        var car = new Car(double.Parse(arr[1]), double.Parse(arr[2]), double.Parse(arr[3]));
        
        arr = Console.ReadLine().Split();
        var truck = new Truck(double.Parse(arr[1]), double.Parse(arr[2]), double.Parse(arr[3]));
        
        arr = Console.ReadLine().Split();
        var bus = new Bus(double.Parse(arr[1]), double.Parse(arr[2]), double.Parse(arr[3]));
        
        int num = int.Parse(Console.ReadLine());
        for (int i = 0; i < num; i++)
        {
            string command = Console.ReadLine();
            arr = command.Split();
            double arg = double.Parse(arr[2]);
            if (arr[1] == "Car")
            {
                if (arr[0] == "Drive")
                {
                    car.Drive(arg);
                }
                else if (arr[0] == "Refuel")
                {
                    car.Refuel(arg);
                }
            }
            else if (arr[1] == "Truck")
            {
                if (arr[0] == "Drive")
                {
                    truck.Drive(arg);
                }
                else if (arr[0] == "Refuel")
                {
                    truck.Refuel(arg);
                }
            }
            else if (arr[1] == "Bus")
            {
                if (arr[0] == "Drive")
                {
                    bus.Drive(arg, true);
                }
                else if (arr[0] == "DriveEmpty")
                {
                    bus.Drive(arg, false);
                }
                else if (arr[0] == "Refuel")
                {
                    bus.Refuel(arg);
                }
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);
    }
}