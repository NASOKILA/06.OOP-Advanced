using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;


public class PersonTests
{
    [Test]
    public void Constructor_Parameter_Test()
    {
        string initialName = "Nasko";
        int initialAge = 10;

        Person person = new Person(initialName, initialAge);

        Assert.That($"{person.Age} {person.Name}", Is.EquivalentTo($"{initialAge} {initialName}"));
    }
}