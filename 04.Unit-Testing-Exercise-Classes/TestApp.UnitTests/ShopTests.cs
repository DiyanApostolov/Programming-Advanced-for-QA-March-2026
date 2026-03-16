using NUnit.Framework;

using System;
using System.Text;
using TestApp.Store;

namespace TestApp.UnitTests;

public class ShopTests
{
    private Shop _shop;

    [SetUp]
    public void SetUp()
    {
        _shop = new Shop();
    }

    [Test]
    public void Test_AddAndGetBoxes_ReturnsSortedBoxes()
    {
        // Arrange
        //"{serial_number} {name} {quantity} {price}"
        string[] products = new string[] { "98765 Pad 2 8", "12345 Keyboard 5 100", "54321 Mouse 3 15" };

        StringBuilder expected = new StringBuilder();
        expected.AppendLine("12345");
        expected.AppendLine("-- Keyboard - $100.00: 5");
        expected.AppendLine("-- $500.00");
        expected.AppendLine("54321");
        expected.AppendLine("-- Mouse - $15.00: 3");
        expected.AppendLine("-- $45.00");
        expected.AppendLine("98765");
        expected.AppendLine("-- Pad - $8.00: 2");
        expected.AppendLine("-- $16.00");

        // Act
        string result = this._shop.AddAndGetBoxes(products);

        // Assert
        Assert.That(result, Is.EqualTo(expected.ToString().Trim()));
    }

    [Test]
    public void Test_AddAndGetBoxes_ReturnsEmptyString_WhenNoProductsGiven()
    {
        // Arrange
        string[] products = new string[0];

        // Act
        string result = this._shop.AddAndGetBoxes(products);

        // Assert
        Assert.That(result, Is.Empty);
    }
}
