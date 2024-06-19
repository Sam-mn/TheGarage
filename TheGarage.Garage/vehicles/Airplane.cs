using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGarage.Garage.vehicles
{
    internal class Airplane : Vehicle
    {
        private int _numberOfEngiens { get; }
        public Airplane(string ownerName, string brandName, string registrationNumber, string color, int numberOfWheels, int numberOfEngiens) : base(ownerName, brandName, registrationNumber, color, numberOfWheels)
        {
            _numberOfEngiens = numberOfEngiens;
        }
    }
}
