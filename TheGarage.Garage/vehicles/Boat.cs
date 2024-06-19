using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGarage.Garage.vehicles
{
    internal class Boat : Vehicle
    {
        private int _cylinderVolume { get; }
        public Boat(string ownerName, string brandName, string registrationNumber, string color, int numberOfWheels, int cylinderVolume) : base(ownerName, brandName, registrationNumber, color, numberOfWheels)
        {
            _cylinderVolume = cylinderVolume;
        }
    }
}
