namespace TheGarage.Garage.vehicles
{
    internal interface IVehicle
    {
        string BrandName { get; set; }
        string Color { get; set; }
        int NumberOfWheels { get; set; }
        string OwnerName { get; set; }
        string RegistrationNumber { get; set; }
    }
}