using NUnit.Framework;

using System;
using System.Text;
using TestApp.Vehicle;

namespace TestApp.UnitTests;

public class VehicleTests
{
    private Vehicles _vehicles;

    [SetUp]
    public void SetUp()
    {
        _vehicles = new Vehicles();
    }

    [Test]
    public void Test_AddAndGetCatalogue_ReturnsSortedCatalogue()
    {
        // Arrange
        //"{type}/{brand}/{model}/{power}"
        string[] input = new string[] { "Car/Opel/Corsa/100", "Truck/Volvo/VNL/500", "Car/Ford/Focus/120", "Car/Toyota/Camry/150", "Truck/Scania/S500/850" };

        StringBuilder expected = new StringBuilder();
        expected.AppendLine("Cars:");
        expected.AppendLine("Ford: Focus - 120hp");
        expected.AppendLine("Opel: Corsa - 100hp");
        expected.AppendLine("Toyota: Camry - 150hp");
        expected.AppendLine("Trucks:");
        expected.AppendLine("Scania: S500 - 850kg");
        expected.Append("Volvo: VNL - 500kg");

        // Act
        string result = this._vehicles.AddAndGetCatalogue(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected.ToString()));
    }

    [Test]
    public void Test_AddAndGetCatalogue_ReturnsEmptyCatalogue_WhenNoDataGiven()
    {
        // Arrange
        string[] input = new string[0];

        StringBuilder expected = new StringBuilder();
        expected.AppendLine("Cars:");
        expected.Append("Trucks:");

        // Act
        string result = this._vehicles.AddAndGetCatalogue(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected.ToString()));
    }

    // BONUS TESTS - NOT FOR JUDGE
    [Test]
    public void Test_AddAndGetCatalogue_ReturnsOnlyTrucks_WhenNoCarDataGiven()
    {
        // Arrange
        string[] input = new string[] { "Truck/Volvo/VNL/500", "Truck/Scania/S500/850" };

        StringBuilder expected = new StringBuilder();
        expected.AppendLine("Cars:");
        expected.AppendLine("Trucks:");
        expected.AppendLine("Scania: S500 - 850kg");
        expected.Append("Volvo: VNL - 500kg");

        // Act
        string result = this._vehicles.AddAndGetCatalogue(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected.ToString()));
    }

    [Test]
    public void Test_AddAndGetCatalogue_ReturnsOnlyCars_WhenNoTruckDataGiven()
    {
        // Arrange
        //"{type}/{brand}/{model}/{power}"
        string[] input = new string[] { "Car/Opel/Corsa/100", "Car/Ford/Focus/120", "Car/Toyota/Camry/150", "Car/Honda/Civic/150" };

        StringBuilder expected = new StringBuilder();
        expected.AppendLine("Cars:");
        expected.AppendLine("Ford: Focus - 120hp");
        expected.AppendLine("Honda: Civic - 150hp");
        expected.AppendLine("Opel: Corsa - 100hp");
        expected.AppendLine("Toyota: Camry - 150hp");
        expected.Append("Trucks:");

        // Act
        string result = this._vehicles.AddAndGetCatalogue(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected.ToString()));
    }
}
