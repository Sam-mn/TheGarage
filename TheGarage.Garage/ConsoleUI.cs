using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGarage.Garage.vehicles;

namespace TheGarage.Garage
{
    internal class ConsoleUI
    {
        public static Vehicle? PrintLog( string type)
        {

            Console.WriteLine("What is your name?");
            string? ownerName = Console.ReadLine();

            Console.WriteLine($"What is the brand of your {type}?");
            string? brandName = Console.ReadLine();

            Console.WriteLine("What is the registration number?");
            string? registrationNumber = Console.ReadLine();

            Console.WriteLine($"What is the color of your {type}?");
            string? color = Console.ReadLine();

            Console.WriteLine("What is the number of wheels?");
            int numberOfWheels = int.Parse(Console.ReadLine());

            switch (type)
            {
                case "Boat":
                     Console.WriteLine("What is the cylinder Volume?");
                     int cylinderVolume = int.Parse(Console.ReadLine());
                     Boat boat = new Boat(ownerName, brandName, registrationNumber, color, numberOfWheels, cylinderVolume);
                    return boat;
                case "Airplane":
                    Console.WriteLine("What is the number of engiens?");
                    int numberOfEngiens = int.Parse(Console.ReadLine());
                    Airplane airplane = new Airplane(ownerName, brandName, registrationNumber, color, numberOfWheels, numberOfEngiens);
                    return airplane;
                case "Bus":
                     Console.WriteLine("What is the number of seats?");
                     int numberOfSeats = int.Parse(Console.ReadLine());
                     Bus bus = new Bus(ownerName, brandName, registrationNumber, color, numberOfWheels, numberOfSeats);
                    return bus;
                case "Car":
                    Console.WriteLine("What is the type of fuel?");
                    string fuelType = Console.ReadLine();
                    Car car = new Car(ownerName, brandName, registrationNumber, color, numberOfWheels, fuelType);
                    return car;
                case "Motorcycle":
                    Console.WriteLine("What is the length of the motorcycle?");
                    int length = int.Parse(Console.ReadLine());
                    Motorcycle motorcycle = new Motorcycle(ownerName, brandName, registrationNumber, color, numberOfWheels, length);
                    return motorcycle;
                    default:
                   return null;
            }
        }
    }
}
