using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.UnitTests;

public class PersonTests
{
    private Person _person;

    [SetUp]
    public void SetUp()
    {
        _person = new Person(); 
    }

    // TODO: finish test
    [Test]
    public void Test_AddPeople_ReturnsListWithUniquePeople()
    {
        // Arrange
        //"{name} {id} {age}"
        string[] peopleData = { "Alice A001 25", "Bob B002 30", "Annie A001 35", "Dido D007 20" };

        List<Person> expectedPeopleList = new List<Person>();
        expectedPeopleList.Add(new Person()
        {
            Name = "Annie",
            Id = "A001",
            Age = 35
        });
        expectedPeopleList.Add(new Person()
        {
            Name = "Bob",
            Id = "B002",
            Age = 30
        });
        expectedPeopleList.Add(new Person()
        {
            Name = "Dido",
            Id = "D007",
            Age = 20
        });

        // Act
        List<Person> resultPeopleList = this._person.AddPeople(peopleData);

        // Assert
        Assert.That(resultPeopleList, Has.Count.EqualTo(3));

        for (int i = 0; i < resultPeopleList.Count; i++)
        {
            Assert.That(resultPeopleList[i].Name, Is.EqualTo(expectedPeopleList[i].Name));
            Assert.That(resultPeopleList[i].Id, Is.EqualTo(expectedPeopleList[i].Id));
            Assert.That(resultPeopleList[i].Age, Is.EqualTo(expectedPeopleList[i].Age));
        }
    }

    [Test]
    public void Test_GetByAgeAscending_SortsPeopleByAge()
    {
        // Arrange
        List<Person> input = new List<Person>();
        input.Add(new Person()
        {
            Name = "Gosho",
            Id = "A001",
            Age = 35
        });
        input.Add(new Person()
        {
            Name = "Bob",
            Id = "B002",
            Age = 30
        });
        input.Add(new Person()
        {
            Name = "Pesho",
            Id = "D007",
            Age = 20
        });
        input.Add(new Person()
        {
            Name = "Dimitrichko",
            Id = "D003",
            Age = 28
        });

        StringBuilder expected = new StringBuilder();
        expected.AppendLine("Pesho with ID: D007 is 20 years old.");
        expected.AppendLine("Dimitrichko with ID: D003 is 28 years old.");
        expected.AppendLine("Bob with ID: B002 is 30 years old.");
        expected.Append("Gosho with ID: A001 is 35 years old.");

        // Act
        string result = _person.GetByAgeAscending(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected.ToString()));
    }
}
