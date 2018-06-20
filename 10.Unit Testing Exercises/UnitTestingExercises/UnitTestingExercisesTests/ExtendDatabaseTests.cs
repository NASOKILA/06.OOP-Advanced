using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[TestFixture]
public class ExtendDatabaseTests
{
    [Test]
    public void TestConstructor()
    {
        Person[] people = new Person[2] { new Person(1, "Ivcho_55"), new Person(2, "Nasko_123") };
        ExtendDatabase db = new ExtendDatabase(people);
        Assert.That(db.Fetch(), Is.EqualTo(people));
    }

    [Test]
    public void TestConstructor_NoArray()
    {
        ExtendDatabase db = new ExtendDatabase(new Person(1, "Ivcho_55"), new Person(2, "Nasko_123"));

        Person[] result = db.Fetch();
        
        Assert.That(result.FirstOrDefault().Username, Is.EqualTo("Ivcho_55"));
    }

    [Test]
    public void TestConstructor_NoParameters()
    {
        ExtendDatabase db = new ExtendDatabase();
        Assert.That(db.Fetch(), Is.EqualTo(new Person[] { }));
    }
    
    [Test]
    public void TestConstructor_ToMuchParameters()
    {
        Person[] people = new Person[17] {
            new Person(1, "Ivcho_55"),
            new Person(2, "Nasko_123"),
            new Person(3, "Asi_123"),
            new Person(4, "Toni_123"),
            new Person(5, "VanioHaha"),
            new Person(6, "GafyKucheto"),
            new Person(7, "NasoKila"),
            new Person(8, "GennadyGolovkin"),
            new Person(9, "CaneloAlvares"),
            new Person(10, "FloydMayweather"),
            new Person(11, "ConnotMcgregor"),
            new Person(12, "DanaWhite"),
            new Person(13, "Joshua"),
            new Person(14, "Mamba"),
            new Person(15, "KocetoManiqka"),
            new Person(16, "IoanEKomarjiq"),
            new Person(17, "IvanaE...")
        };

        Assert.That(() => new ExtendDatabase(people),
            Throws.InvalidOperationException
            .With
            .Message
            .EqualTo("Size bigger than 16!"));

    }

    //VVAAAAAJJJJJJJNNNNNNNNNNOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!
    //Polzvame go za da podaveme instancii na klasa 'Person' v testa za 'Add' Metoda !!!
    public static object[] singlePerson =
    {
        new Person(17, "asi")
    };

    //ZA DA PODADEM INSTANCIQ NA OBEKT POLZVAME object[]{...} KOITO DA VRUSHTA 
    //TOVA KOETO ISKAME DA PODADEM 
    //POLZVAME I : TestCaseSource("ImetoNamasivaSobekti")
    [TestCaseSource("singlePerson")]
    public void AddMethodTest(Person person)
    {
        ExtendDatabase db = new ExtendDatabase();
        db.Add(person);
        Assert.That(db.Fetch(), Is.EqualTo(new Person[] { person }));
    }

    [TestCaseSource("singlePerson")]
    public void AddMethodTest_ThrowsExeption_ToManyElements(Person person)
    {
        Person[] people = new Person[16] {
            new Person(1, "Ivcho_55"),
            new Person(2, "Nasko_123"),
            new Person(3, "Asi_123"),
            new Person(4, "Toni_123"),
            new Person(5, "VanioHaha"),
            new Person(6, "GafyKucheto"),
            new Person(7, "NasoKila"),
            new Person(8, "GennadyGolovkin"),
            new Person(9, "CaneloAlvares"),
            new Person(10, "FloydMayweather"),
            new Person(11, "ConnotMcgregor"),
            new Person(12, "DanaWhite"),
            new Person(13, "Joshua"),
            new Person(14, "Mamba"),
            new Person(15, "KocetoManiqka"),
            new Person(16, "IoanEKomarjiq")
        };

        ExtendDatabase db = new ExtendDatabase(people);

        Assert.That(() => db.Add(person),
            Throws.InvalidOperationException
            .With.Message.EqualTo("Storage is full!"));
    }
    
    [TestCaseSource("singlePerson")]
    public void AddMethodTest_UserExists_Exeption(Person person)
    {

        ExtendDatabase db = new ExtendDatabase(new Person(17, "asi"), new Person(7, "Nasko"), new Person(11, "Toni"));

        Assert.That(() => db.Add(person), 
            Throws
            .InvalidOperationException
            .With
            .Message
            .EqualTo("Username already exists!"));
    }
    
    [TestCaseSource("singlePerson")]
    public void AddMethodTest_IdExists_Exeption(Person person)
    {

        ExtendDatabase db = new ExtendDatabase(new Person(17, "Gaby"), new Person(7, "Nasko"), new Person(11, "Toni"));

        Assert.That(() => db.Add(person),
            Throws
            .InvalidOperationException
            .With
            .Message
            .EqualTo("Id already exists!"));
    }

    [Test]
    public void RemoveTest()
    {
        Person[] people = new Person[1] {
            new Person(1, "Ivcho_55")
        };

        ExtendDatabase db = new ExtendDatabase(people);
        db.Remove();

        Assert.That(db.Fetch(), Is.EqualTo(new Person[] { }));
    }

    [Test]
    public void RemoveTest_ThrowError_EmptyArray()
    {
        Person[] people = new Person[1] {
            new Person(1, "Ivcho_55")
        };

        ExtendDatabase db = new ExtendDatabase(people);
        db.Remove();
        
        Assert.That(() => db.Remove(), Throws.InvalidOperationException.With.Message.EqualTo("Storage is Empty!"));
    }

    [Test]
    public void FetchMethodTest()
    {
        ExtendDatabase db = new ExtendDatabase(new Person(1, "Ivcho_55"), new Person(2, "Ivcho_1255"), new Person(3, "Ivcho_55325"));
        db.Add(new Person(4, "IvanchoGolemeca"));
        db.Remove();
        db.Remove();
        db.Remove();
        db.Remove();

        Assert.That(db.Fetch(), Is.EquivalentTo(new Person[] { }));
    }

    [TestCase("Ivcho_55")]
    [TestCase("Ivcho_1255")]
    [TestCase("Ivcho_55325")]
    public void FindByUsername(string username)
    {
        ExtendDatabase db = new ExtendDatabase(new Person(1, "Ivcho_55"), new Person(2, "Ivcho_1255"), new Person(3, "Ivcho_55325"));

        Assert.That(db.FindByUsername(username).Username, Is.EquivalentTo(username));
    }

    [TestCase("Ivcho_55")]
    public void FindByUsername_ThrowExeption_UserNotFound(string username)
    {
        ExtendDatabase db = new ExtendDatabase(new Person(1, "IvoIvo"), new Person(2, "Kondio"), new Person(3, "KrasoTapaka"));

        Assert.That(() => db.FindByUsername(username),
            Throws.InvalidOperationException
            .With
            .Message
            .EqualTo($"User with Username {username} don't exists!"));
    }

    [TestCase(null)]
    public void FindByUsername_ThrowError_InputIsNull(string username)
    {
        ExtendDatabase db = new ExtendDatabase(new Person(1, "Ivcho_55"), new Person(2, "Ivcho_1255"));
        
        Assert.That(() => db.FindByUsername(username), 
            Throws.ArgumentNullException);
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    public void FindById(int id)
    {
        ExtendDatabase db = new ExtendDatabase(new Person(1, "Ivcho_55"), new Person(2, "Ivcho_1255"), new Person(3, "Ivcho_55325"));

        Assert.That(db.FindById(id).Id, Is.EqualTo(id));
    }
    
    [TestCase(11)]
    public void FindById_ThrowExeption_UserNotFound(int id)
    {
        ExtendDatabase db = new ExtendDatabase(new Person(1, "IvoIvo"), new Person(2, "Kondio"), new Person(3, "KrasoTapaka"));

        Assert.That(() => db.FindById(id),
            Throws.InvalidOperationException
            .With
            .Message
            .EqualTo($"User with Id {id} don't exists!"));
    }

    [TestCase(null)]
    public void FindByUsername_ThrowError_InputIsNull(int id)
    {
        ExtendDatabase db = new ExtendDatabase(new Person(1, "Ivcho_55"), new Person(2, "Ivcho_1255"));

        Assert.That(() => db.FindById(id),
            Throws.Exception);
    }
}

