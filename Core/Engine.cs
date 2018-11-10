using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Vehicles;

namespace Vehicles.Core
{
   public class Engine
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            double carFuelQuantiry = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);


            double truckFuelQuantiry = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);

            double busFuelQuantiry = double.Parse(busInfo[1]);
            double busFuelConsumption = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);
            IVehicle car = new Car(carFuelQuantiry,carFuelConsumption,carTankCapacity);

            IVehicle truck = new Truck(truckFuelQuantiry,truckFuelConsumption,truckTankCapacity);

            IVehicle bus = new Bus(busFuelQuantiry,busFuelConsumption,busTankCapacity);

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                try
                {
                    string[] inputArgs = Console.ReadLine().Split();
                    string action = inputArgs[0];
                    string vehicleType = inputArgs[1];
                    double valeu = double.Parse(inputArgs[2]);

                    if (action == "Refuel")
                    {
                        if (vehicleType == "Car")
                        {
                            car.Refuel(valeu);
                        }
                        else if(vehicleType == "Truck")
                        {
                            truck.Refuel(valeu);
                        }
                        else if (vehicleType == "Bus")
                        {
                            bus.Refuel(valeu);
                        }
                    }
                    else if(action == "Drive")
                    {
                        if (vehicleType == "Car")
                        {
                            car.Drive(valeu);
                        }
                        else if(vehicleType == "Truck")
                        {
                            truck.Drive(valeu);
                        }
                        else if(vehicleType == "Bus")
                        {
                            bus.IsVehicleEmpty = false;
                            bus.Drive(valeu);
                        }
                    }
                    else if  (action == "DriveEmpty")
                    {
                        bus.IsVehicleEmpty = true;
                        bus.Drive(valeu);
                    }
                }
                catch (ArgumentException e)
                {

                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
