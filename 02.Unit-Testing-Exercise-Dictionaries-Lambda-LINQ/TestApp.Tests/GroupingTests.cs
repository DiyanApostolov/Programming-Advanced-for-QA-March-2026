using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.Tests;

public class GroupingTests
{
    // TODO: finish test
    [Test]
    public void Test_GroupNumbers_WithEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<int> input = new List<int>();

        // Act
        string result = Grouping.GroupNumbers(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_GroupNumbers_WithEvenAndOddNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> input = new List<int>() { 13, 8, 12, 5, 7, 1, 6 };

        string expected = "Odd numbers: 13, 5, 7, 1" + Environment.NewLine +
                          "Even numbers: 8, 12, 6";

        // Act
        string result = Grouping.GroupNumbers(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GroupNumbers_WithOnlyEvenNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> input = new List<int>() { 12, 8, 22, 6 };

        string expected = "Even numbers: 12, 8, 22, 6";

        // Act
        string result = Grouping.GroupNumbers(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GroupNumbers_WithOnlyOddNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> input = new List<int>() { 15, 7, 3, 9 };

        string expected = "Odd numbers: 15, 7, 3, 9";

        // Act
        string result = Grouping.GroupNumbers(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GroupNumbers_WithNegativeNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> input = new List<int>() { -4, -125, -13, -7, -12 };

        string expected = "Even numbers: -4, -12" + Environment.NewLine +
                          "Odd numbers: -125, -13, -7";

        // Act
        string result = Grouping.GroupNumbers(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
