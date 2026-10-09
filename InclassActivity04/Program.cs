
using System;

namespace InclassActivity04
{
    // Abstract product: Vehicle
    public interface IVehicle
    {
        void ShowDetails();
    }

    // Abstract product: Engine
    public interface IEngine
    {
        void Start();
    }

    // Abstract factory
    public interface IVehicleFactory
    {
        IVehicle CreateCar();
        IVehicle CreateTruck();
        IEngine CreateEngine();
    }

    // Gasoline vehicles
    public class GasolineCar : IVehicle
    {
        public void ShowDetails()
        {
            Console.WriteLine("Vehicle: Gasoline Car");
        }
    }

    public class GasolineTruck : IVehicle
    {
        public void ShowDetails()
        {
            Console.WriteLine("Vehicle: Gasoline Truck");
        }
    }

    // Electric vehicles
    public class ElectricCar : IVehicle
    {
        public void ShowDetails()
        {
            Console.WriteLine("Vehicle: Electric Car");
        }
    }

    public class ElectricTruck : IVehicle
    {
        public void ShowDetails()
        {
            Console.WriteLine("Vehicle: Electric Truck");
        }
    }

    // Gasoline engine
    public class GasolineEngine : IEngine
    {
        public void Start()
        {
            Console.WriteLine("Gasoline engine started.");
        }
    }

    // Electric engine
    public class ElectricEngine : IEngine
    {
        public void Start()
        {
            Console.WriteLine("Electric engine started.");
        }
    }

    // Concrete factory: Gasoline
    public class GasolineVehicleFactory : IVehicleFactory
    {
        public IVehicle CreateCar()
        {
            return new GasolineCar();
        }

        public IVehicle CreateTruck()
        {
            return new GasolineTruck();
        }

        public IEngine CreateEngine()
        {
            return new GasolineEngine();
        }
    }

    // Concrete factory: Electric
    public class ElectricVehicleFactory : IVehicleFactory
    {
        public IVehicle CreateCar()
        {
            return new ElectricCar();
        }

        public IVehicle CreateTruck()
        {
            return new ElectricTruck();
        }

        public IEngine CreateEngine()
        {
            return new ElectricEngine();
        }
    }

    // Main program
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("VEHICLE MANUFACTURING SYSTEM");
            Console.WriteLine("1. Gasoline");
            Console.WriteLine("2. Electric");
            Console.Write("Select engine type (1 or 2): ");

            string choice = Console.ReadLine() ?? "";

            IVehicleFactory factory;

            if (choice == "1")
            {
                factory = new GasolineVehicleFactory();
            }
            else if (choice == "2")
            {
                factory = new ElectricVehicleFactory();
            }
            else
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            Console.WriteLine("\nSelect vehicle type:");
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Truck");
            Console.Write("Enter choice (1 or 2): ");

            string vehicleChoice = Console.ReadLine() ?? "";

            IVehicle vehicle;

            if (vehicleChoice == "1")
            {
                vehicle = factory.CreateCar();
            }
            else if (vehicleChoice == "2")
            {
                vehicle = factory.CreateTruck();
            }
            else
            {
                Console.WriteLine("Invalid vehicle selection.");
                return;
            }

            IEngine engine = factory.CreateEngine();

            Console.WriteLine("\n--- Manufacturing Result ---");
            vehicle.ShowDetails();
            engine.Start();

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
