using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace TestApp.UnitTests;

public class ExceptionTests
{
    private Exceptions _exceptions = null!;

    [SetUp]
    public void SetUp()
    {
        this._exceptions = new();
    }

    [Test]
    public void Test_Reverse_ValidString_ReturnsReversedString()
    {
        // Arrange
        string input = "Hello, world!";
        string expected = "!dlrow ,olleH";

        // Act
        string result = _exceptions.ArgumentNullReverse(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Reverse_NullString_ThrowsArgumentNullException()
    {
        // Arrange
        string input = null;
        string expectedMessage = "String cannot be null. (Parameter 's')";

        // Act & Assert
        Assert.That(() => _exceptions.ArgumentNullReverse(input), Throws.ArgumentNullException);

        // check exception message -> New syntax
        try
        {
            _exceptions.ArgumentNullReverse(input);
        }
        catch (ArgumentNullException ex)
        {
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }
    }

    [Test]
    public void Test_CalculateDiscount_ValidInput_ReturnsDiscountedPrice()
    {
        // Arrange
        decimal totalPrice = 200;
        decimal discount = 15;
        decimal discountedPrice = 170;

        // Act
        decimal result = _exceptions.ArgumentCalculateDiscount(totalPrice, discount);

        // Assert
        Assert.That(result, Is.EqualTo(discountedPrice));
    }

    [Test]
    public void Test_CalculateDiscount_NegativeDiscount_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 200;
        decimal discount = -10;

        // Act & Assert - OLD SYNTAX
        ArgumentException ex = Assert.Throws<ArgumentException>(() => _exceptions.ArgumentCalculateDiscount(totalPrice, discount));

        Assert.That(ex.Message, Is.EqualTo("Discount must be between 0 and 100. (Parameter 'discount')"));
    }

    [Test]
    public void Test_CalculateDiscount_DiscountOver100_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 200;
        decimal discount = 110;

        // Act & Assert - OLD SYNTAX
        ArgumentException ex = Assert.Throws<ArgumentException>(() => _exceptions.ArgumentCalculateDiscount(totalPrice, discount));

        Assert.That(ex.Message, Is.EqualTo("Discount must be between 0 and 100. (Parameter 'discount')"));
    }

    [Test]
    public void Test_GetElement_ValidIndex_ReturnsElement()
    {
        // Arrange
        int[] input = { 7, 2, 13, 8, -5, 23 };
        int index = 2;

        int exected = 13;

        // Act
        int result = _exceptions.IndexOutOfRangeGetElement(input, index);

        // Assert
        Assert.That(result, Is.EqualTo(exected));
    }

    [Test]
    public void Test_GetElement_IndexLessThanZero_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] input = { 7, 2, 13, 8, -5, 23 };
        int index = -2;

        // Act & Assert
        Assert.That(() => _exceptions.IndexOutOfRangeGetElement(input, index), Throws.TypeOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElement_IndexEqualToArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] input = { 7, 2, 13, 8, -5, 23 };
        int index = input.Length;

        // Act & Assert
        Assert.That(() => _exceptions.IndexOutOfRangeGetElement(input, index), Throws.TypeOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElement_IndexGreaterThanArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] input = { 7, 2, 13, 8, -5, 23 };
        int index = 10;

        // Act & Assert
        Assert.That(() => _exceptions.IndexOutOfRangeGetElement(input, index), Throws.TypeOf<IndexOutOfRangeException>());

        // check exception message
        try
        {
            _exceptions.IndexOutOfRangeGetElement(input, index);
        }
        catch (IndexOutOfRangeException ex)
        {
            Assert.That(ex.Message, Is.EqualTo("Index is out of range."));
        }
    }

    [Test]
    public void Test_PerformSecureOperation_UserLoggedIn_ReturnsUserLoggedInMessage()
    {
        // Arrange
        bool input = true;
        string expected = "User logged in.";

        // Act
        string result = _exceptions.InvalidOperationPerformSecureOperation(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_PerformSecureOperation_UserNotLoggedIn_ThrowsInvalidOperationException()
    {
        // Arange
        bool input = false;

        // Act & Arrange
        Assert.That(() => _exceptions.InvalidOperationPerformSecureOperation(input), Throws.TypeOf<InvalidOperationException>());
    }

    [Test]
    public void Test_ParseInt_ValidInput_ReturnsParsedInteger()
    {
        // Arrange
        string input = "7";
        int expected = 7;

        // Act
        int result = _exceptions.FormatExceptionParseInt(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("5a")]
    [TestCase("5.5")]
    [TestCase("pet")]
    public void Test_ParseInt_InvalidInput_ThrowsFormatException(string input)
    {
        // Act & Assert
        Assert.That(() => _exceptions.FormatExceptionParseInt(input), Throws.TypeOf<FormatException>());
    }

    [TestCase("two", 2)]
    [TestCase("five", 5)]
    public void Test_FindValueByKey_KeyExistsInDictionary_ReturnsValue(string key, int expected)
    {
        // Arrange
        Dictionary<string, int> input = new Dictionary<string, int>();
        input.Add("one", 1);
        input.Add("two", 2);
        input.Add("three", 3);
        input.Add("four", 4);
        input.Add("five", 5);

        // Act
        int result = _exceptions.KeyNotFoundFindValueByKey(input, key);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindValueByKey_KeyDoesNotExistInDictionary_ThrowsKeyNotFoundException()
    {
        // Arrange
        Dictionary<string, int> input = new Dictionary<string, int>();
        input.Add("one", 1);
        input.Add("two", 2);
        input.Add("three", 3);
        input.Add("four", 4);
        input.Add("five", 5);

        string invalidKey = "six";

        // Act & Assert
        Assert.That(() => _exceptions.KeyNotFoundFindValueByKey(input, invalidKey), Throws.TypeOf<KeyNotFoundException>());

        try
        {
            _exceptions.KeyNotFoundFindValueByKey(input, invalidKey);
        }
        catch (KeyNotFoundException ex)
        {
            Assert.That(ex.Message, Is.EqualTo("The specified key was not found in the dictionary."));
        }
    }

    [Test]
    public void Test_AddNumbers_NoOverflow_ReturnsSum()
    {
        // Arrange
        int a = 5;
        int b = 100;
        int expected = 105;

        // Act
        int result = _exceptions.OverflowAddNumbers(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddNumbers_PositiveOverflow_ThrowsOverflowException()
    {
        // Arrange
        int a = int.MaxValue;
        int b = 1;

        // Act & Assert
        Assert.That(() => _exceptions.OverflowAddNumbers(a, b), Throws.TypeOf<OverflowException>());
    }

    [Test]
    public void Test_AddNumbers_NegativeOverflow_ThrowsOverflowException()
    {
        // Arrange
        int a = int.MinValue;
        int b = -1;

        // Act & Assert
        Assert.That(() => _exceptions.OverflowAddNumbers(a, b), Throws.TypeOf<OverflowException>());
    }

    [Test]
    public void Test_DivideNumbers_ValidDivision_ReturnsQuotient()
    {
        // Arrange
        int a = 13;
        int divisor = 4;

        int expected = 3;

        // Act
        int result = _exceptions.DivideByZeroDivideNumbers(a, divisor);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_DivideNumbers_DivideByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        int a = 13;
        int divisor = 0;

        // Act & Assert
        Assert.That(() => _exceptions.DivideByZeroDivideNumbers(a, divisor), Throws.TypeOf<DivideByZeroException>());
    }

    [Test]
    public void Test_SumCollectionElements_ValidCollectionAndIndex_ReturnsSum()
    {
        // Arrange
        int[] input = { 1, 2, 3, 7, 15, 2 };
        int index = 3;

        int expected = 30;

        // Act
        int result = _exceptions.SumCollectionElements(input, index);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_SumCollectionElements_NullCollection_ThrowsArgumentNullException()
    {
        // Arrange
        int[] input = null;
        int index = 3;

        // Act & Assert
        Assert.That(() => _exceptions.SumCollectionElements(input, index), Throws.TypeOf<ArgumentNullException>());
    }

    [TestCase(-1)]
    [TestCase(6)]
    [TestCase(10)]
    public void Test_SumCollectionElements_IndexOutOfRange_ThrowsIndexOutOfRangeException(int index)
    {
        // Arrange
        int[] input = { 1, 2, 3, 7, 15, 2 };

        // Act & Assert
        Assert.That(() => _exceptions.SumCollectionElements(input, index), Throws.TypeOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElementAsNumber_ValidKey_ReturnsParsedNumber()
    {
        // Arrange
        Dictionary<string, string> input = new Dictionary<string, string>();
        input["one"] = "1";
        input["two"] = "2";
        input["three"] = "3";
        input["four"] = "4";
        input["five"] = "5";

        string key = "four";

        int expected = 4;

        // Act
        int result = _exceptions.GetElementAsNumber(input, key);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetElementAsNumber_KeyNotFound_ThrowsKeyNotFoundException()
    {
        // Arrange
        Dictionary<string, string> input = new Dictionary<string, string>();
        input["one"] = "1";
        input["two"] = "2";
        input["three"] = "3";
        input["four"] = "4";
        input["five"] = "5";

        string key = "seven";

        // Act & Assert - OLD SYNTAX
        var ex = Assert.Throws<KeyNotFoundException>(() => _exceptions.GetElementAsNumber(input, key));

        Assert.That(ex.Message, Is.EqualTo("Key not found in the dictionary."));
    }

    [TestCase("one")]
    [TestCase("two")]
    [TestCase("three")]
    public void Test_GetElementAsNumber_InvalidFormat_ThrowsFormatException(string key)
    {
        // Arrange
        Dictionary<string, string> input = new Dictionary<string, string>();
        input["one"] = "1a";
        input["two"] = "2.5";
        input["three"] = "tri";

        // Act & Assert - OLD SYNTAX
        var ex = Assert.Throws<FormatException>(() => _exceptions.GetElementAsNumber(input, key));

        Assert.That(ex.Message, Is.EqualTo("Can't parse string."));
    }
}
