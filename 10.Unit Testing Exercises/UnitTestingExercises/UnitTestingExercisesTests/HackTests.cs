using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[TestFixture]
public class HackTests
{
    [TestCase(5)]
    [TestCase(0)]
    [TestCase(12)]
    [TestCase(124)]
    [TestCase(69121)]
    public void TestMathAbs_Integers(int num)
    {
        int result = Math.Abs(num);
        Assert.That(result, Is.EqualTo(num));
    }

    [TestCase(-5)]
    [TestCase(-51)]
    [TestCase(-552)]
    public void TestMathAbs_Negative_Integers(int num)
    {
        string str = num.ToString().Substring(1);
        int expectedResult = int.Parse(str);
        int result = Math.Abs(num);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase(5.123)]
    [TestCase(0.00)]
    [TestCase(999.1200)]
    public void TestMathAbs_Doubles(double num)
    {
        double result = Math.Abs(num);
        Assert.That(result, Is.EqualTo(num));
    }

    [TestCase(-0.7654)]
    [TestCase(-5.81)]
    [TestCase(-545.12358)]
    public void TestMathAbs_Doubles_Negative(double num)
    {
        double expectedResult = double.Parse(num.ToString().Substring(1));
        double result = Math.Abs(num);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase(5.11123411)]
    [TestCase(5123.111)]
    [TestCase(51.12311)]
    [TestCase(0.12313)]
    public void TestMathAbs_Decimal(decimal num)
    {
        decimal result = Math.Abs(num);
        Assert.That(result, Is.EqualTo(num));
    }

    [TestCase(-5123.999)]
    [TestCase(-512415.999)]
    [TestCase(-235.999)]
    public void TestMathAbs_Decimal_NegativeNumbers(decimal num)
    {
        decimal expectedResult = decimal.Parse(num.ToString().Substring(1));
        decimal result = Math.Abs(num);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase(22.2)]
    [TestCase(2.542)]
    [TestCase(0.50)]
    [TestCase(112.7123)]
    [TestCase(554.999)]
    [TestCase(0.0123)]
    [TestCase(0.0)]
    public void MathFloor(double num)
    {
        double result = Math.Floor(num);
        double expectedResult = double.Parse(num.ToString().Split(",").First());
        Assert.AreEqual(result, expectedResult);
    }
    
    [TestCase(-2.99)]
    [TestCase(-0.0)]
    [TestCase(-0.1)]
    [TestCase(-31.012)]
    [TestCase(-212.012)]
    [TestCase(-0.0123)]
    public void MathFloor_Negative_Numbers(double num)
    {
        double result = Math.Floor(num);
        double expectedResult = double.Parse(num.ToString().Split(",").First()) - 1;
        if (num.ToString("F2") == "0,00")
            expectedResult += 1;

        Assert.AreEqual(result, expectedResult);
    }

}

