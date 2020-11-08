using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle car, truck, bus;
            ReadVehicles(out car, out truck, out bus);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var cmdArgs = Console.ReadLine().Split();
                if (cmdArgs[1] == "Car")
                {
                    VehicleAction(cmdArgs, car);
                }
                else if (cmdArgs[1] == "Truck")
                {
                    VehicleAction(cmdArgs, truck);
                }
                else if (cmdArgs[1] == "Bus")
                {
                    VehicleAction(cmdArgs, bus);
                }
            }
            PrintVehicle(car);
            PrintVehicle(truck);
            PrintVehicle(bus);

        }

        private static void ReadVehicles(out Vehicle car, out Vehicle truck, out Vehicle bus)
        {
            var carArgs = Console.ReadLine().Split();
            var truckArgs = Console.ReadLine().Split();
            var busArgs = Console.ReadLine().Split();

            car = new Car(double.Parse(carArgs[1]), double.Parse(carArgs[2]), double.Parse(carArgs[3]));
            truck = new Truck(double.Parse(truckArgs[1]), double.Parse(truckArgs[2]), double.Parse(truckArgs[3]));
            bus = new Bus(double.Parse(busArgs[1]), double.Parse(busArgs[2]), double.Parse(busArgs[3]));
        }

        private static void VehicleAction(string[] cmdArgs, Vehicle vehicle )
        {
            if (cmdArgs[0] == "Drive")
            {
                Console.WriteLine(vehicle.Drive(double.Parse(cmdArgs[2]), vehicle.AcFuelIncrease));
            }
            else if (cmdArgs[0] == "Refuel")
            {
                vehicle.Refuel(double.Parse(cmdArgs[2]));
            }
            else if (cmdArgs[0] == "DriveEmpty")
            {
                vehicle.IsAcTurnedOn = false;
                Console.WriteLine(vehicle.Drive(double.Parse(cmdArgs[2]), vehicle.AcFuelIncrease));
            }
        }
        private static void PrintVehicle(Vehicle vehicle)
        {
            Console.WriteLine($"{vehicle.GetType().Name}: {vehicle.FuelQuantity:F2}");
        }
    }
}
