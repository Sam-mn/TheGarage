using TheGarage.Garage.vehicles;

namespace TheGarage.Garage
{
    internal interface IMainGarage<T> where T : Vehicle
    {
        IEnumerator<T> GetEnumerator();
        int GetNumberOfParking();
        T? GetVehicleByRNumber(string registrationNumber);
        int Length();
        void ParkAVehicle(T vehicle);
        bool RemoveAVehicleByRNumber(string registrationNumber);
    }
}