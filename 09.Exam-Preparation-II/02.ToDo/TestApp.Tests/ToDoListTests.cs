using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using NUnit.Framework;

using TestApp.Todo;
using NUnit.Framework.Constraints;

namespace TestApp.Tests;

[TestFixture]
public class ToDoListTests
{
    private ToDoList _toDoList = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._toDoList = new();
    }
    
    [Test]
    public void Test_AddTask_TaskAddedToToDoList()
    {
        // Arrange
        _toDoList.AddTask("Task1", DateTime.Now);

        string expected = "To-Do List:" + Environment.NewLine +
                          "[ ] Task1 - Due: 04/09/2026";

        // Act
        string result = _toDoList.DisplayTasks();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_CompleteTask_TaskMarkedAsCompleted()
    {
        // Arrange
        _toDoList.AddTask("Task1", DateTime.Now);

        string expected = "To-Do List:" + Environment.NewLine +
                          "[✓] Task1 - Due: 04/09/2026";

        // Act
        _toDoList.CompleteTask("Task1");

        string result = _toDoList.DisplayTasks();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_CompleteTask_TaskNotFound_ThrowsArgumentException()
    {
        // Arrange
        _toDoList.AddTask("Task1", DateTime.Now);

        // Act & Assert
        Assert.That(() => _toDoList.CompleteTask("InvalidTask"), Throws.ArgumentException);
    }

    [Test]
    public void Test_DisplayTasks_NoTasks_ReturnsEmptyString()
    {
        // Arrange
        string expected = "To-Do List:";

        // Act
        string result = _toDoList.DisplayTasks();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_DisplayTasks_WithTasks_ReturnsFormattedToDoList()
    {
        // Arrange
        _toDoList.AddTask("Task1", DateTime.Now);
        _toDoList.AddTask("Task2", DateTime.Now);
        _toDoList.AddTask("Task3", DateTime.Now);

        _toDoList.CompleteTask("TASK2");

        string expected = "To-Do List:" + Environment.NewLine +
                          "[ ] Task1 - Due: 04/09/2026" + Environment.NewLine +
                          "[✓] Task2 - Due: 04/09/2026" + Environment.NewLine +
                          "[ ] Task3 - Due: 04/09/2026";

        // Act
        string result = _toDoList.DisplayTasks();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
