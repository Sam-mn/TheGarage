using Garage;
using TheGarage.Garage;
using TheGarage.Garage.vehicles;

namespace Garage.Tests
{
    public class GarageTests
    {
        [Fact]
        public void CanParkeAVehicle()
        {
            // Arrange
            var garage = new MainGarage<Vehicle>(10);
            var car = new Car("Sam", "BMW", "ABC123", "Red", 4, "diesel");

            // Act
            garage.ParkAVehicle(car);

            // Assert
            Assert.Contains(car, garage);
        }     
        
        [Fact]
        public void CanRemoveAVehicle()
        {
            // Arrange
            var garage = new MainGarage<Vehicle>(10);
            var car = new Car("Sam", "BMW", "ABC123", "Red", 4, "diesel");

            // Act
            garage.RemoveAVehicleByRNumber("ABC123");

            // Assert
            Assert.DoesNotContain(car, garage);
        }

        [Fact]
        public void CannotParkeAVehicleWhenGarageIsFull()
        {
            // Arrange
            var garage = new MainGarage<Vehicle>(1);
            var car1 = new Car("Sam", "BMW", "ABC123", "Red", 4, "diesel");
            var car2 = new Car("Johanna", "Audi", "ABC321", "Black", 4, "Bensin");
            garage.ParkAVehicle(car1);

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(()=> garage.ParkAVehicle(car2));
            Assert.Equal("Garage is full.", ex.Message);
        }

        [Fact]
        public void FindAVehicleByRegistrationNumber()
        {
            // Arrange
            var garage = new MainGarage<Vehicle>(2);
            var car1 = new Car("Sam", "BMW", "ABC123", "Red", 4, "diesel");
            var car2 = new Car("Johanna", "Audi", "ABC321", "Black", 4, "Bensin");
            garage.ParkAVehicle(car1);
            garage.ParkAVehicle(car2);

            // Act
            var vehicle = garage.GetVehicleByRNumber("ABC123");

            // Assert

            Assert.NotNull(vehicle);
            Assert.Equal("ABC123", vehicle.RegistrationNumber);
        }
    }
}