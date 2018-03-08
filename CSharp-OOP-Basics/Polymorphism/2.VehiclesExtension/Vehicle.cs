using System;
using System.Collections.Generic;
using System.Text;

public abstract class Vehicle
{
    private double fuelQuantity;

    public double FuelQuantity
    {
        get { return fuelQuantity; }
        private set { fuelQuantity = value; }
    }

    private double fuelPerKm;

    public double FuelPerKm
    {
        get { return fuelPerKm; }
        private set { fuelPerKm = value; }
    }

    private double tankCapacity;

    public double TankCapacity
    {
        get { return tankCapacity; }
        private set { tankCapacity = value; }
    }

    private string vehicleType;

    public Vehicle(double fuelQuantity, double fuelPerKm, double tankCapacity, string vehicleType)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelPerKm = fuelPerKm;
        this.vehicleType = vehicleType;
        if (fuelQuantity <= tankCapacity) 
            this.TankCapacity = tankCapacity;
    }

    //public virtual void Drive(double distance)
    //{
    //    if (distance * fuelPerKm > fuelQuantity)
    //    {
    //        Console.WriteLine($"{vehicleType} needs refueling");
    //    }
    //    else
    //    {
    //        fuelQuantity -= distance * fuelPerKm;
    //        Console.WriteLine($"{vehicleType} travelled {distance} km");
    //    }
    //}

    protected void Drive(double distance, double consumptionInrease)
    {
        //consumptionInrease += 1;
        if (distance * (fuelPerKm + consumptionInrease) > fuelQuantity)
        {
            Console.WriteLine($"{vehicleType} needs refueling");
        }
        else
        {
            fuelQuantity -= distance * (fuelPerKm + consumptionInrease);
            Console.WriteLine($"{vehicleType} travelled {distance} km");
        }
    }

    public virtual void Refuel(double fuelAmount)
    {
        Refuel(fuelAmount, 0);
    }

    public virtual void Refuel(double fuelAmount, double fuelLost)
    {
        if (fuelAmount <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
            return;
        }
        if (this.FuelQuantity + fuelAmount > this.TankCapacity)
        {
            Console.WriteLine($"Cannot fit {fuelAmount} fuel in the tank");
            return;
        }
        this.FuelQuantity += fuelAmount - fuelLost;
    }

    public override string ToString()
    {
        return $"{this.vehicleType}: {this.fuelQuantity:F2}";
    }
}