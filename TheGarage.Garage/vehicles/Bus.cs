using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGarage.Garage.vehicles
{
    internal class Bus: Vehicle
    {
        private int _numberOfSeats {  get; }
        public Bus(string ownerName, string brandName, string registrationNumber, string color, int numberOfWheels, int numberOfSeats) : base(ownerName, brandName, registrationNumber, color, numberOfWheels)
        {
            _numberOfSeats = numberOfSeats;
        }
    }
}
