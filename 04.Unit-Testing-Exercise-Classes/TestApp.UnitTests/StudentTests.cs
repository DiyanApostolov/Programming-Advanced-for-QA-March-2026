using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class StudentTests
{
    // декларирам обект от типа Student
    private Student studentList;

    [SetUp]
    public void SetUp()
    {
        // инициализирам обект от типа Student
        studentList = new Student();
    }

    [Test]
    public void Test_AddAndGetByCity_ReturnsStudentsInCity_WhenCityExists()
    {
        // Arrange
        string[] students = { "John Doe 25 Sofia", "Jane Smith 22 Varna", "Alice Johnson 20 Sofia", "Diyan Apostolov 40 Varna" };
        string wantedTown = "Sofia";

        string expected = $"John Doe is 25 years old.{Environment.NewLine}" +
                          $"Alice Johnson is 20 years old.";

        // Act
        string result = studentList.AddAndGetByCity(students, wantedTown);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddAndGetByCity_ReturnsEmptyString_WhenCityDoesNotExist()
    {
        // Arrange
        string[] students = { "John Doe 25 Sofia", "Jane Smith 22 Plovdiv", "Alice Johnson 20 Sofia", "Diyan Apostolov 40 Varna" };
        string wantedTown = "Burgas";

        // Act
        string result = studentList.AddAndGetByCity(students, wantedTown);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_AddAndGetByCity_ReturnsEmptyString_WhenNoStudentsGiven()
    {
        // Arrange
        string[] students = Array.Empty<string>();
        string wantedTown = "Burgas";

        // Act
        string result = studentList.AddAndGetByCity(students, wantedTown);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // BONUS TEST - NOT FOR JUDGE
    [Test]
    public void Test_AddAndGetByCity_UpdateStudentsInCity_WhenCityExists()
    {
        // Arrange
        string[] students = { "John Doe 25 Sofia", "Jane Smith 22 Varna", "Alice Johnson 20 Sofia", "Diyan Apostolov 40 Varna", "John Doe 26 Sofia", "Jane Smith 23 Sofia" };
        string wantedTown = "Sofia";

        string expected = $"John Doe is 26 years old.{Environment.NewLine}" +
                          $"Jane Smith is 23 years old.{Environment.NewLine}" +
                          $"Alice Johnson is 20 years old.";

        // Act
        string result = studentList.AddAndGetByCity(students, wantedTown);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
