using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class DatabaseTests
{
    
    [TestCase()]
    [TestCase(new int[] {})]
    [TestCase(-1,-2,-3)]
    [TestCase(new int[3] { 1, 2, 3 })]
    [TestCase(new int[3] { -54, 12, -3333 })]
    [TestCase(1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16)]
    public void TestConstructor(params int[] args)
    {
        Database db = new Database(args);
        Assert.That(db.Fetch(), Is.EqualTo(args));
    }

    [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17})]
    [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17)]
    public void TestConstructor_ThowsError_BiggerSize(params int[] args)
    {
        Assert.That(() => new Database(args), 
            Throws.InvalidOperationException
            .With
            .Message
            .EqualTo("Size bigger than 16 integers!"));
    }

    [TestCase("1", "2", "3")]
    public void TestConstructor_WithStringParameters( params string[] args)
    {
        Assert.Throws<InvalidOperationException>(() => throw new InvalidOperationException());
    }

    [TestCase('1', '2', '3')]
    [TestCase(new char[] { '1', '2', '3' })]
    public void TestConstructor_WithCharParameters(params char[] args)
    {
        Assert.Throws<InvalidOperationException>(() => throw new InvalidOperationException());
    }

    [TestCase(true, false)]
    [TestCase(new bool[2] { true, false })]
    public void TestConstructor_WithBooleanParameters(params bool[] args)
    {
        Assert.Throws<InvalidOperationException>(() => throw new InvalidOperationException());
    }

    [TestCase(1)]
    [TestCase(15)]
    [TestCase(-1)]
    [TestCase(0)]
    [TestCase(int.MinValue)]
    [TestCase(int.MaxValue)]
    public void AddMethodTest(int item)
    {
        var expectedResult = new int[] { item };
        if (item == 0)
            expectedResult = new int[] {  };

        Database db = new Database();
        db.Add(item);
        Assert.That(db.Fetch(), Is.EqualTo(expectedResult));
    }

    [TestCase(55)]
    public void AddMethodTest_ThrowsExeption_ToMuchElements(int item)
    {
        Database db = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

        Assert.That(() => db.Add(item),
            Throws.InvalidOperationException
            .With.Message.EqualTo("Storage is full!"));
    }
    
    [Test]
    public void RemoveMethodTest()
    {
        Database db = new Database(1,2,3);
        db.Remove();

        Assert.That(db.Fetch(), 
            Is.EquivalentTo(new int[2]{1,2}));
    }
    
    [Test]
    public void RemoveMethodTest_ThrowsExeption_EmptyArray()
    {
        Database db = new Database();
        
        Assert.That(() => db.Remove(),
            Throws.InvalidOperationException
            .With.Message.EqualTo("Storage is Empty!"));
    }
    
    [Test]
    public void FetchMethodTest()
    {
        Database db = new Database(1,2,3);
        db.Add(4);
        db.Remove();
        db.Remove();

        Assert.That(db.Fetch(), Is.EquivalentTo(new int[] {1,2}));
    }


}
