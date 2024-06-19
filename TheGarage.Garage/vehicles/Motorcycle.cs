using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGarage.Garage.vehicles
{
    internal class Motorcycle: Vehicle
    {
        private int _length { get; set; }
        public Motorcycle(string ownerName, string brandName, string registrationNumber, string color, int numberOfWheels, int length) : base(ownerName, brandName, registrationNumber, color, numberOfWheels)
        {
            _length = length;
        }
    }
}
