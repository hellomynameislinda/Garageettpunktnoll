using Garageettpunktnoll;
namespace Garageettpunktnoll.MSTest
{
    [TestClass]
    public class GarageTest
    {
        [TestMethod]
        public void IsEmpty_ShouldReturn_True()
        {
            // Arrange
            Garage<Vehicle> testGarage = new Garage<Vehicle>("Test Garage", 12);

            var expected = true;

            // Act
            var actual = testGarage.IsEmpty();

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void IsFull_ShouldReturn_False()
        {
            // Arrange
            Garage<Vehicle> testGarage = new Garage<Vehicle>("Test Garage", 12);
            Vehicle testVehicle;

            testVehicle = new Car($"ABC123", "Volvo", "Grön", 4, 200, 4);
            testGarage.parkingSpaces[0] = testVehicle;

            var expected = false;

            // Act
            var actual = testGarage.IsFull();

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void RegistrationAvailable_ShouldReturn_False()
        {
            // Arrange
            Garage<Vehicle> testGarage = new Garage<Vehicle>("Test Garage", 12);
            Vehicle testVehicle;

            testVehicle = new Car($"ABC123", "Volvo", "Grön", 4, 200, 4);
            testGarage.parkingSpaces[0] = testVehicle;

            var expected = false;

            // Act
            var actual = testGarage.RegistrationAvailable("ABC123");

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void RegistrationAvailable_ShouldReturn_True()
        {
            // Arrange
            Garage<Vehicle> testGarage = new Garage<Vehicle>("Test Garage", 12);
            Vehicle testVehicle;

            testVehicle = new Car($"ABC123", "Volvo", "Grön", 4, 200, 4);
            testGarage.parkingSpaces[0] = testVehicle;

            var expected = true;

            // Act
            var actual = testGarage.RegistrationAvailable("DEF456");

            Assert.AreEqual(expected, actual);

        }
    }
}