using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TheGarage.Garage.vehicles;
[assembly: InternalsVisibleTo("Garage.Tests")]
namespace TheGarage.Garage
{
    internal class MainGarage<T> : IEnumerable<T>, IMainGarage<T> where T : Vehicle
    {
        private T[] _vehiclesList;
        private int _numberOfParkengs = 0;
        public MainGarage(int capacity)
        {
            _vehiclesList = new T[capacity];
        }
        public int GetNumberOfParking() => _numberOfParkengs;
        public int Length() => _vehiclesList.Length;
        public void ParkAVehicle(T vehicle)
        {
            if (_numberOfParkengs >= _vehiclesList.Length)
            {
                throw new InvalidOperationException("Garage is full.");
            }
            _vehiclesList[_numberOfParkengs++] = vehicle;
        }
        public T? GetVehicleByRNumber(string registrationNumber)
        {
            try
            {

                for (int i = 0; i < _vehiclesList.LongLength; i++)
                {
                    if (_vehiclesList[0] != null && _vehiclesList[i].RegistrationNumber.ToLower() == registrationNumber.ToLower())
                    {
                        return _vehiclesList[i];
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            return null;
        }
        public bool RemoveAVehicleByRNumber(string registrationNumber)
        {
            try
            {
                for (int i = 0; i < _vehiclesList.LongLength; i++)
                {
                    if (_vehiclesList[0] != null && _vehiclesList[i].RegistrationNumber.ToLower() == registrationNumber.ToLower())
                    {
                        _vehiclesList[i] = _vehiclesList[--_numberOfParkengs];
                        _vehiclesList[_numberOfParkengs] = null!;
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Your vehicle is not here.");
            }

            return false;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _numberOfParkengs; i++)
            {
                yield return _vehiclesList[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
