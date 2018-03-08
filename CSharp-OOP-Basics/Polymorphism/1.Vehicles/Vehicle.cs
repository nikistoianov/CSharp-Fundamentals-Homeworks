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

    private string vehicleType;

    public Vehicle(double fuelQuantity, double fuelPerKm, string vehicleType)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelPerKm = fuelPerKm;
        this.vehicleType = vehicleType;
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
        this.FuelQuantity += fuelAmount;
    }

    public override string ToString()
    {
        return $"{this.vehicleType}: {this.fuelQuantity:F2}";
    }
}