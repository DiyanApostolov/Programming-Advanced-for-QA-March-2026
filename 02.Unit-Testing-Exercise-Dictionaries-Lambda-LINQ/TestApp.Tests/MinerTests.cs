using NUnit.Framework;

using System;
using static NUnit.Framework.Constraints.Tolerance;

namespace TestApp.Tests;

public class MinerTests
{
    [Test]
    public void Test_Mine_WithEmptyInput_ShouldReturnEmptyString()
    {
        // Arrange
        string[] input = Array.Empty<string>();

        // Act
        string result = Miner.Mine(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_Mine_WithMixedCaseResources_ShouldBeCaseInsensitive()
    {
        // Arrange
        string[] input = new string[] { "GOLD 4", "Silver 10", "Gold 2", "goLd 2", "siLvEr 20" };
        string exected = "gold -> 8" + Environment.NewLine + 
                         "silver -> 30";

        // Act
        string result = Miner.Mine(input);

        // Assert
        Assert.That(result, Is.EqualTo(exected));
    }

    [Test]
    public void Test_Mine_WithDifferentResources_ShouldReturnResourceCounts()
    {
        // Arrange
        string[] input = new string[] { "Gold 40", "Silver 10", "Copper 5", "Gold 20", "Silver 15", "Copper 25", "Gold 5" };

        string exected = "gold -> 65" + Environment.NewLine +
                         "silver -> 25" + Environment.NewLine +
                         "copper -> 30";

        // Act
        string result = Miner.Mine(input);

        // Assert
        Assert.That(result, Is.EqualTo(exected));
    }
}
