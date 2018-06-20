using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

[TestFixture]
public class ListIteratorTests
{
    [TestCase("nasko", "asi")]
    [TestCase("Stefcho", "Goshky")]
    [TestCase("1", "2", "3")]
    public void ConstructorTest(params string[] collection)
    {
        ListIterator listIterator = new ListIterator(collection);

        //get collection with reflection
        FieldInfo privateFieldCollection = listIterator
            .GetType()
            .GetField("collection", BindingFlags.NonPublic
                | BindingFlags.Public
                | BindingFlags.Instance);

        ICollection<string> values = (ICollection<string>)privateFieldCollection.GetValue(listIterator);

        Assert.That(values, Is.EquivalentTo(collection));
    }

    [TestCase()]
    public void ConstructorTest_EmptyInput(params string[] collection)
    {
        ListIterator listIterator = new ListIterator(collection);
        Assert.That(() => listIterator.Print(), 
            Throws.InvalidOperationException);
    }

    [TestCase(null)]
    public void ConstructorTest_NullInput(params string[] collection)
    {
        collection = null;
        Assert.That(() => { ListIterator listIterator = new ListIterator(collection); },
             Throws.ArgumentNullException);
    }

    [Test]
    public void HasNextTest_ReturnsTrue()
    {
        ListIterator listIterator = new ListIterator(new string[] { "Stefcho", "Goshky" });
        Assert.That(listIterator.HasNext(), Is.EqualTo(true));
    }

    [Test]
    public void HasNextTest_ReturnsFalse()
    {
        ListIterator listIterator = new ListIterator(new string[] { "1", "2", "3" });
        listIterator.Move();
        listIterator.Move();
        Assert.That(listIterator.HasNext(), Is.EqualTo(false));
    }

    [Test]
    public void MoveTest_ReturnsTrue()
    {
        ListIterator listIterator = new ListIterator(new string[] { "Stefcho", "Goshky" });
        Assert.That(listIterator.Move(), Is.EqualTo(true));
    }

    [Test]
    public void MoveTest_ReturnsFalse()
    {
        ListIterator listIterator = new ListIterator(new string[] { "Stefcho", "Goshky" });
        listIterator.Move();
        Assert.That(listIterator.Move(), Is.EqualTo(false));
    }

    [Test]
    public void PrintTest()
    {
        ListIterator listIterator = new ListIterator(new string[] { "Stefcho", "Goshky" });


        FieldInfo privateFieldCollection = listIterator
            .GetType()
            .GetField("collection", BindingFlags.NonPublic
                | BindingFlags.Public
                | BindingFlags.Instance);

        ICollection<string> values = (ICollection<string>)privateFieldCollection.GetValue(listIterator);
        string[] arr = values.ToArray();


        //get the index so we can use it
        FieldInfo privateFieldIndex = listIterator
            .GetType()
            .GetField("currentIndex", BindingFlags.NonPublic
                | BindingFlags.Public
                | BindingFlags.Instance);
        
        int index = (int)privateFieldIndex.GetValue(listIterator);
        
        Assert.That(() => arr[index], Is.EquivalentTo("Stefcho"));
    }

}

