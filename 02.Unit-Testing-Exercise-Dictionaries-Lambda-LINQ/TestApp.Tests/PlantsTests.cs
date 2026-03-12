using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class PlantsTests
{
    [Test]
    public void Test_GetFastestGrowing_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        string[] input = Array.Empty<string>();

        // Act
        string result = Plants.GetFastestGrowing(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_GetFastestGrowing_WithSinglePlant_ShouldReturnPlant()
    {
        // Arrange
        string[] input = new string[] { "Rose" };

        string exected = "Plants with 4 letters:" + Environment.NewLine +
                         "Rose";


        // Act
        string result = Plants.GetFastestGrowing(input);

        // Assert
        Assert.That(result, Is.EqualTo(exected));
    }

    [Test]
    public void Test_GetFastestGrowing_WithMultiplePlants_ShouldReturnGroupedPlants()
    {
        // Arrange
        string[] input = new string[] { "Orchid", "Hibiscus", "Rose", "Tulip", "Daisy", "Lily", "Peony",  "Plumeria" };

        string exected = "Plants with 4 letters:" + Environment.NewLine +
                         "Rose" + Environment.NewLine +
                         "Lily" + Environment.NewLine +
                         "Plants with 5 letters:" + Environment.NewLine +
                         "Tulip" + Environment.NewLine +
                         "Daisy" + Environment.NewLine +
                         "Peony" + Environment.NewLine +
                         "Plants with 6 letters:" + Environment.NewLine +
                         "Orchid" + Environment.NewLine +
                         "Plants with 8 letters:" + Environment.NewLine +
                         "Hibiscus" + Environment.NewLine +
                         "Plumeria";


        // Act
        string result = Plants.GetFastestGrowing(input);

        // Assert
        Assert.That(result, Is.EqualTo(exected));
    }

    [Test]
    public void Test_GetFastestGrowing_WithMixedCasePlants_ShouldBeCaseInensitive()
    {
        // Arrange
        string[] input = new string[] { "Rose", "Tulip", "TULip", "ROSE", "Peony", "Tulip" };

        string exected = "Plants with 4 letters:" + Environment.NewLine +
                         "Rose" + Environment.NewLine +
                         "ROSE" + Environment.NewLine +
                         "Plants with 5 letters:" + Environment.NewLine +
                         "Tulip" + Environment.NewLine +
                         "TULip" + Environment.NewLine +
                         "Peony" + Environment.NewLine +
                         "Tulip";


        // Act
        string result = Plants.GetFastestGrowing(input);

        // Assert
        Assert.That(result, Is.EqualTo(exected));
    }
}
