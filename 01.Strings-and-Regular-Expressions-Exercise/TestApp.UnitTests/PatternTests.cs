using NUnit.Framework;
using System;

namespace TestApp.UnitTests;

public class PatternTests
{
    // TODO: finish the test cases
    [TestCase("Hello", 3, "hElLohElLohElLo")]
    [TestCase("DIDO", 5, "dIdOdIdOdIdOdIdOdIdO")]
    [TestCase("$pesho#", 4, "$PeShO#$PeShO#$PeShO#$PeShO#")]
    public void Test_GeneratePatternedString_ValidInput_ReturnsExpectedResult(string input, 
        int repetitionFactor, string expected)
    {
        // Arrange

        // Act
        string result = Pattern.GeneratePatternedString(input, repetitionFactor);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("")]
    [TestCase(null)]
    public void Test_GeneratePatternedString_EmptyOrNullInput_ThrowsArgumentException(string input)
    {
        // Arrange
        //string input = "";
        int repetitionFactor = 3;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Pattern.GeneratePatternedString(input, repetitionFactor));
    }

    [Test]
    public void Test_GeneratePatternedString_NegativeRepetitionFactor_ThrowsArgumentException()
    {
        // Arrange
        string input = "Hello";
        int repetitionFactor = -3;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Pattern.GeneratePatternedString(input, repetitionFactor));
    }

    [Test]
    public void Test_GeneratePatternedString_ZeroRepetitionFactor_ThrowsArgumentException()
    {
        // Arrange
        string input = "Hello";
        int repetitionFactor = 0;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Pattern.GeneratePatternedString(input, repetitionFactor));
    }
}
