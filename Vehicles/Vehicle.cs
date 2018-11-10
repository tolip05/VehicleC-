using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;

        private double fuelConsumption;

        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption,double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            
        }
        public bool IsVehicleEmpty { get; set; }

        public double FuelQuantity
        {
            get => fuelQuantity;
            set
            {
                if (value > this.TankCapacity)
                {
                    value = 0;
                }
                fuelQuantity = value;
            }
        }
        public double FuelConsumption
        {
            get => fuelConsumption;
            set
            {
                fuelConsumption = value;
            }
        }

        public double TankCapacity
        {
            get => tankCapacity;
            set
            {
                tankCapacity = value;
            }
        }

        public virtual void Drive(double distance)
        {
            double neededFuel = this.FuelConsumption * distance;

            if (this.FuelQuantity < neededFuel)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }
            this.FuelQuantity -= neededFuel;
            Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            
        }

        public void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (this.FuelQuantity + fuel > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }
            if (this is Truck)
            {
                fuel *= 0.95;
            }
            this.FuelQuantity += fuel;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
