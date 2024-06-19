using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGarage.Garage.vehicles;
using TheGarage.Garage;

namespace TheGarage.Garage
{
    internal class GarageHandlar
    {
        MainGarage<Vehicle> garage { get; }
        private static bool _parkingInProgress;
        private static bool _parkingMenu;
        public static MainGarage<Vehicle>? theGarage { get; set; }
        public GarageHandlar() 
        { 
        }

        private static void InitializeAGrage()
        {
            try
            {
                Console.WriteLine("Create a garage");
                Console.WriteLine("How many Pakings do you need?");
                int garagePlaceis = 0;
                while (garagePlaceis == 0) 
                { 
                    string? userInput = Console.ReadLine();
                    if (string.IsNullOrEmpty(userInput))
                    {
                        Console.Clear();
                        Console.WriteLine("How many Pakings do you need?");
                        Console.WriteLine("The input should be a number.");
                    }
                    else 
                    {
                        if (int.TryParse(userInput, out int result))
                        {
                            garagePlaceis = result;
                            theGarage = new MainGarage<Vehicle>(result);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("How many Pakings do you need?");
                            Console.WriteLine("The input should be a number.");
                        }
                    } 
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.Clear();
                Console.WriteLine("The input can not be empty.");
            }
        }
        public static void Run()
        {
            InitializeAGrage();
       
            _parkingInProgress = true;

            while (_parkingInProgress) 
            {
                Console.WriteLine("Do You wamt to park or get your vehicle?");
                Console.WriteLine("Type 1 to park.");
                Console.WriteLine("Type 2 to check if your vehicle is here by registration Number");
                Console.WriteLine("Type 3 to pick up your vehicle");
                Console.WriteLine("Type 4 to print vehicles types");
                Console.WriteLine("Type 5 to print all vehicles");
                Console.WriteLine("Type 6 to Finda vehicles by properties.");
                Console.WriteLine("Type 7 Go back.");
                Console.WriteLine("Type 0 to exit.");
         
                char input = ' ';
                try
                {
                    input = Console.ReadLine()![0];
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Clear();
                    Console.WriteLine("You have to chose a number between 0 and 5.");
                }

                switch (input) 
                {
                    case '1':
                        try
                        {
                            if (theGarage?.GetNumberOfParking() >= theGarage?.Length())
                            {
                                _parkingMenu = false;
                                throw new InvalidOperationException("garage is full");
                            }
                            else
                            {
                                Park();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                        }
                        break;
                    case '2':
                        CheckIfParkedByRN();
                        break;
                    case '3':
                        RemoveAVehicle();
                        break;
                    case '4':
                        PrintVehiclesTypes();
                        break; 
                    case '5':
                        PrintVehicles();
                        break;  
                    case '6':
                        FindVehiclesByProperties();
                        break; 
                    case '7':
                        Console.Clear();
                        InitializeAGrage();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4, 5)");
                        break;
                }
            }
        }
        private static void FindVehiclesByProperties()
        {
            var vehiclesList = theGarage?.AsEnumerable();
            Console.WriteLine("Type a brand name or leave it empty");
            string? brandName = Console.ReadLine(); 
            Console.WriteLine("Type a Color or leave it empty");
            string? color = Console.ReadLine();  
            Console.WriteLine("Number of wheels");
            var input = Console.ReadLine();
            int? numberOfWheels;
            if (int.TryParse(input, out int result))
            {
                numberOfWheels = result;
                if (numberOfWheels.HasValue)
                {
                    vehiclesList = vehiclesList?.Where(x => x.NumberOfWheels == numberOfWheels.Value);
                }
            }

            if (!string.IsNullOrEmpty(color))
            {
                vehiclesList= vehiclesList?.Where(x=>x.Color == color);
            }

            if (!string.IsNullOrEmpty(brandName))
            {
                vehiclesList = vehiclesList?.Where(x => x.BrandName == brandName);
            }

            Console.WriteLine("---------------------------------------------------------");
            foreach (var item in vehiclesList!)
            {
                Console.WriteLine($"- Owner name: {item.OwnerName}, Color: {item.Color}, Brand name: {item.BrandName}, Number of wheels: {item.NumberOfWheels}, Registration number: {item.RegistrationNumber}");
            }
            Console.WriteLine("---------------------------------------------------------");
        }
        private static void PrintVehicles()
        {
            if (theGarage != null)
            {
                Console.WriteLine("---------------------------------------------------------");
                foreach (var vehicle in theGarage)
                {
                    Console.WriteLine($"- Owner name: {vehicle.OwnerName}, Color: {vehicle.Color}, Brand name: {vehicle.BrandName}, Number of wheels: {vehicle.NumberOfWheels}, Registration number: {vehicle.RegistrationNumber}");
                }
                Console.WriteLine("---------------------------------------------------------");
            }
        }
        private static void PrintVehiclesTypes()
        {
            var vehicleGroup = theGarage?.GroupBy(v => v.GetType().Name);
            if (vehicleGroup != null) 
            {
                Console.WriteLine("---------------------------------------------------------");
                foreach (var group in vehicleGroup)
                {
                    Console.WriteLine($"{group.Key}: {group.Count()}");
                }
                Console.WriteLine("---------------------------------------------------------");
            }
        }
        private static void RemoveAVehicle()
        {
            try
            {
                Console.WriteLine("Type The registration Number of your vehicle.");
                string rn = Console.ReadLine();
                if (theGarage is not null && theGarage.RemoveAVehicleByRNumber(rn))
                {
                    Console.WriteLine("You can pick up your vehicle now.");
                }
                else
                {
                    Console.WriteLine("This registration Number is not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
       
        }
        private static void Park()
        {
            _parkingMenu = true;
            while (_parkingMenu)
            {
                Console.WriteLine("Witch kind of vehicle is yours?");
                Console.WriteLine("1. Airplane.");
                Console.WriteLine("2. Boat.");
                Console.WriteLine("3. Car.");
                Console.WriteLine("4. Motorcycle.");
                Console.WriteLine("5. Bus.");
                Console.WriteLine("6. Go back.");
                Console.WriteLine("0 to exit.");

                char vehicleType = ' ';
                try
                {
                    vehicleType = Console.ReadLine()![0];
                }
                catch (IndexOutOfRangeException)
                {
                    Console.Clear();
                    Console.WriteLine("You have to chose a number between 0 and 5.");
                }

                switch (vehicleType)
                {
                    case '1':
                        parkAVehicleByType("Airplane");
                        break;
                    case '2':
                        parkAVehicleByType("Boat");
                        break;
                    case '3':
                        parkAVehicleByType("Car");
                        break;
                    case '4':
                        parkAVehicleByType("Motorcycle");
                        break;
                    case '5':
                        parkAVehicleByType("Bus");
                        break;
                    case '6':
                        _parkingMenu = false;
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4, 5)");
                        break;
                }
            }
        }
        private static void CheckIfParkedByRN()
        {
            try
            {
                Console.WriteLine("Type The registration Number of your vehicle.");
                string rn = Console.ReadLine();
                var vehicle = theGarage?.GetVehicleByRNumber(rn);
                if (vehicle != null) 
                { 
                    Console.WriteLine($"Your vehicle with registration Number {vehicle.RegistrationNumber} is parked here.");
                }
                else
                {
                    Console.WriteLine($"Sorry the vehicle with registration Number {rn} is not parked here."); 
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
        private static void parkAVehicleByType(string type)
        {
            try
            {
                theGarage?.ParkAVehicle(ConsoleUI.PrintLog(type)!);
                Console.WriteLine("Vehicle parked successfully.");
                _parkingMenu = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}
