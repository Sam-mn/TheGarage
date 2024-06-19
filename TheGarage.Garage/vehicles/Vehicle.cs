using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGarage.Garage.vehicles
{
    internal class Vehicle : IVehicle
    {
        private string _ownerName;
        private string _brandName;
        private string _registrationNumber;
        private string _color;
        private int _numberOfWheels;

        public string OwnerName
        {
            get { return _ownerName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The Owner name is requierd.");
                }
                _ownerName = value;
            }
        }

        public string BrandName
        {
            get { return _brandName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The brand name is requierd.");
                }
                _brandName = value;
            }
        }
        public string RegistrationNumber
        {
            get { return _registrationNumber; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The registration number is requierd.");
                }
                _registrationNumber = value;
            }
        }

        public string Color
        {
            get { return _color; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The color is requierd.");
                }
                _color = value;
            }
        }

        public int NumberOfWheels
        {
            get { return _numberOfWheels; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Number of wheels must be greater then 0.");
                }
                _numberOfWheels = value;
            }
        }


        public Vehicle(string ownerName, string brandName, string registrationNumber, string color, int numberOfWheels)
        {
            _brandName = brandName;
            _ownerName = ownerName;
            _registrationNumber = registrationNumber;
            _color = color;
            _numberOfWheels = numberOfWheels;
        }
    }
}
