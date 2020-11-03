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

            var repeats = int.Parse(Console.ReadLine());

            for (int i = 0; i < repeats; i++)
            {
                var cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    ProcessCommand(cmdArgs, car, truck);

                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static void ProcessCommand(string[] cmdArgs, Vehicle car, Vehicle truck)
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
            }
        }

        private Vehicle ProduceVehicle()
        {
            var args = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var type = args[0];
            var fuelQty = double.Parse(args[1]);
            var fuelConsumption = double.Parse(args[2]);
            Vehicle vehicle = vehicleFactory.ProduceVehicle(type, fuelQty, fuelConsumption);
            return vehicle;
        }


    }
}
