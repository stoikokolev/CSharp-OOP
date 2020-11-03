using System;
using Vehicles.Core.Contracts;
using Vehicles.Factories;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private VehicleFactory vehicleFactory;

        public Engine()
        {
            vehicleFactory = new VehicleFactory();
        }

        public void Run()
        {
            var car = ProduceVehicle();
            var truck = ProduceVehicle();
            var bus = ProduceVehicle();

            var repeats = int.Parse(Console.ReadLine());

            for (int i = 0; i < repeats; i++)
            {
                var cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    ProcessCommand(cmdArgs, car, truck, (Bus)bus);

                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void ProcessCommand(string[] cmdArgs, Vehicle car, Vehicle truck, Bus bus)
        {
            var cmdType = cmdArgs[0];
            var vehicleType = cmdArgs[1];
            var arg = double.Parse(cmdArgs[2]);

            if (cmdType == "Drive")
            {
                if (vehicleType == "Car")
                {
                    Console.WriteLine(car.Drive(arg));

                }
                else if (vehicleType == "Truck")
                {
                    Console.WriteLine(truck.Drive(arg));
                }
                else if (vehicleType == "Bus")
                {
                    Console.WriteLine(bus.Drive(arg));
                }
            }
            else if (cmdType == "DriveEmpty")
            {
                if (vehicleType == "Bus")
                {
                    Console.WriteLine(bus.DriveEmpty(arg));
                }
            }
            else if (cmdType == "Refuel")
            {
                if (vehicleType == "Car")
                {
                    car.Refuel(arg);
                }
                else if (vehicleType == "Truck")
                {
                    truck.Refuel(arg);
                }
                else if (vehicleType == "Bus")
                {
                    bus.Refuel(arg);
                }
            }
        }

        private Vehicle ProduceVehicle()
        {
            var args = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var type = args[0];
            var fuelQty = double.Parse(args[1]);
            var fuelConsumption = double.Parse(args[2]);
            var tankCapacity = double.Parse(args[3]);
            Vehicle vehicle = vehicleFactory.ProduceVehicle(type, fuelQty, fuelConsumption, tankCapacity);
            return vehicle;
        }


    }
}
