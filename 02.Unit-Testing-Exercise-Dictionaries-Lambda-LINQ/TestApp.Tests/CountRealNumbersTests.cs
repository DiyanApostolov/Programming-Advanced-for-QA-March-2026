using NUnit.Framework;

using System;
using System.Security.Cryptography.X509Certificates;

namespace TestApp.Tests;

public class CountRealNumbersTests
{
    // TODO: finish test
    [Test]
    public void Test_Count_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        int[] input = Array.Empty<int>();

        // Act
        string result = CountRealNumbers.Count(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Count_WithSingleNumber_ShouldReturnCountString()
    {
        // Arrange
        int[] input = new int[] { 42 };
        string expected = "42 -> 1";

        // Act
        string result = CountRealNumbers.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithMultipleNumbers_ShouldReturnCountString()
    {
        // Arrange
        int[] input = new int[] { 42, 7, 2, 15, 7, 42 };
        string expected = "2 -> 1" + Environment.NewLine +
                          "7 -> 2" + Environment.NewLine +
                          "15 -> 1" + Environment.NewLine +
                          "42 -> 2";

        // Act
        string result = CountRealNumbers.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithNegativeNumbers_ShouldReturnCountString()
    {
        // Arrange
        int[] input = new int[] { -42, -7, -3, -15, -7, -42 };

        string expected = "-42 -> 2" + Environment.NewLine +
                          "-15 -> 1" + Environment.NewLine +
                          "-7 -> 2" + Environment.NewLine +
                          "-3 -> 1";

        // Act
        string result = CountRealNumbers.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithZero_ShouldReturnCountString()
    {
        // Arrange
        int[] input = new int[] { 0, 0 };
        string expected = "0 -> 2";

        // Act
        string result = CountRealNumbers.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
