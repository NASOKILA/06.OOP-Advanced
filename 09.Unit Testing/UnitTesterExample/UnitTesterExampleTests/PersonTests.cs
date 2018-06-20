using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;


public class PersonTests
{



    [Test]
    public void Constructor_Parameter_Test()
    {
        //SHTE TESTVAME KONSTUKTUTA:

        //Izvejdame si parametrite zashtoto tova e po PRAVILNATA PRAKTIKA 
        string initialName = "Nasko";
        int initialAge = 10;

        //Pravim si Person obekta
        Person person = new Person(initialName, initialAge);

        //Testvame i dvata parametura
        Assert.That($"{person.Age} {person.Name}", Is.EquivalentTo($"{initialAge} {initialName}"));

    }


}

