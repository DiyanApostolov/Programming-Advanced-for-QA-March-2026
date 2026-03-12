using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class OrdersTests
{
    [Test]
    public void Test_Order_WithEmptyInput_ShouldReturnEmptyString()
    {
        // Arrange
        string[] input = Array.Empty<string>();

        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_Order_WithMultipleOrders_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = new string[] { "apple 1.50 2", "banana 1.25 3", "apple 1.99 1", "orange 0.99 2" };

        string expected = $"apple -> 5.97{Environment.NewLine}" +
                          $"banana -> 3.75{Environment.NewLine}" +
                          $"orange -> 1.98";

        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Order_WithRoundedPrices_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = new string[] { "apple 2.123 2", "banana 2.563 3", "apple 3.225 3" };

        string expected = $"apple -> 16.13{Environment.NewLine}" +
                          $"banana -> 7.69";

        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Order_WithDecimalQuantities_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = new string[] { "apple 2 2.40", "banana 2 3.1", "apple 3 3.25", "banana 2 2.35" };

        string expected = $"apple -> 16.95{Environment.NewLine}" +
                          $"banana -> 10.90";

        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
