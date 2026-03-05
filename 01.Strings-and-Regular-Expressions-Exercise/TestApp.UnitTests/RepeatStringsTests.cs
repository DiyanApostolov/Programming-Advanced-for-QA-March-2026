using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class RepeatStringsTests
{
    [Test]
    public void Test_Repeat_EmptyInput_ReturnsEmptyString()
    {
        // Arrange
        string[] input = Array.Empty<string>();

        // Act
        string result = RepeatStrings.Repeat(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Repeat_SingleInputString_ReturnsRepeatedString()
    {
        // Arrange
        string[] input = new string[] { "hello" };
        string expected = "hellohellohellohellohello";

        // Act
        string result = RepeatStrings.Repeat(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Repeat_MultipleInputStrings_ReturnsConcatenatedRepeatedStrings()
    {
        // Arrange
        string[] input = new string[] { "hello", "abc", "GO" };
        string expected = "hellohellohellohellohelloabcabcabcGOGO";

        // Act
        string result = RepeatStrings.Repeat(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // BONUS TESTS: NOT FOR JUDGE
    [Test]
    public void Test_Repeat_MultipleInputStringsWithLengthOne_ReturnsConcatenatedRepeatedStrings()
    {
        // Arrange
        string[] input = new string[] { "H", "i", "Di" };
        string expected = "HiDiDi";

        // Act
        string result = RepeatStrings.Repeat(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Repeat_InputStringsWithWhitespace_ReturnsConcatenatedRepeatedStrings()
    {
        // Arrange
        string[] input = new string[] { " Hi abc", "Di " };
        string expected = "Hi abc Hi abc Hi abc Hi abc Hi abc Hi abc Hi abcDi Di Di";

        // Act
        string result = RepeatStrings.Repeat(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
