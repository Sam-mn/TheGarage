using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGarage.Garage.vehicles
{
    internal class Car : Vehicle
    {
        private string _fuelType {  get; set; }
        public Car(string ownerName, string brandName, string registrationNumber, string color, int numberOfWheels, string fuelType) : base(ownerName, brandName, registrationNumber, color, numberOfWheels)
        {
            _fuelType = fuelType;
        }
    }
}
