using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class FruitsTests
{
    [Test]
    public void Test_GetFruitQuantity_FruitExists_ReturnsQuantity()
    {
        // Arrange
        Dictionary<string,  int> warehouse = new Dictionary<string, int>();
        warehouse.Add("Banana", 10);
        warehouse.Add("Orange", 12);
        warehouse.Add("Grape", 6);
        warehouse.Add("Apple", 15);

        string fruit = "Apple";

        int expected = 15;

        // Act
        int result = Fruits.GetFruitQuantity(warehouse, fruit);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFruitQuantity_FruitDoesNotExist_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int> warehouse = new Dictionary<string, int>();
        warehouse.Add("Banana", 10);
        warehouse.Add("Orange", 12);
        warehouse.Add("Grape", 6);
        warehouse.Add("Apple", 15);

        string fruit = "Raspberry";

        int expected = 0;

        // Act
        int result = Fruits.GetFruitQuantity(warehouse, fruit);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFruitQuantity_EmptyDictionary_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int> warehouse = new Dictionary<string, int>();

        string fruit = "Raspberry";

        int expected = 0;

        // Act
        int result = Fruits.GetFruitQuantity(warehouse, fruit);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFruitQuantity_NullDictionary_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int> warehouse = null;

        string fruit = "Raspberry";

        int expected = 0;

        // Act
        int result = Fruits.GetFruitQuantity(warehouse, fruit);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFruitQuantity_NullFruitName_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int> warehouse = new Dictionary<string, int>();
        warehouse.Add("Banana", 10);
        warehouse.Add("Orange", 12);
        warehouse.Add("Grape", 6);
        warehouse.Add("Apple", 15);

        string fruit = null;

        int expected = 0;

        // Act
        int result = Fruits.GetFruitQuantity(warehouse, fruit);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // DEMO TEST - NOT FOR JUDGE
    [Test]
    public void Test_GetFruitQuantity_NegativeQuanity_ThrowArgumentException()
    {
        // Arrange
        Dictionary<string, int> warehouse = new Dictionary<string, int>();
        warehouse.Add("Banana", 10);
        warehouse.Add("Orange", 12);
        warehouse.Add("Grape", -6);
        warehouse.Add("Apple", 15);

        string fruit = "Grape";

        // Act & Assert
        Assert.That(() => Fruits.GetFruitQuantity(warehouse, fruit), Throws.ArgumentException);
    }
}
