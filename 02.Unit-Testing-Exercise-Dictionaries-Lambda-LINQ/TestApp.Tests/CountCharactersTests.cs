using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.Tests;

public class CountCharactersTests
{
    [Test]
    public void Test_Count_WithEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<string> input = new();

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_Count_WithNoCharacters_ShouldReturnEmptyString()
    {
        // Arrange
        List<string> input = new List<string>() { "", "", "" };

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Count_WithSingleCharacter_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new List<string>() { "a" };

        string expected = "a -> 1";

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithMultipleCharacters_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new List<string>() { "ha", "hi", "ani" };

        string expected = "h -> 2" + Environment.NewLine +
                          "a -> 2" + Environment.NewLine +
                          "i -> 2" + Environment.NewLine +
                          "n -> 1";

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithSpecialCharacters_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new List<string>() { "#dido", "5$", "#$#i" };

        string expected = "# -> 3" + Environment.NewLine +
                          "d -> 2" + Environment.NewLine +
                          "i -> 2" + Environment.NewLine +
                          "o -> 1" + Environment.NewLine +
                          "5 -> 1" + Environment.NewLine +
                          "$ -> 2";

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
