using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTesterExample;

public class BankTests
{
    [Test]
    public void GetAccountBalance_FormatsToMoney()
    {
        string expectedValue = "20,00";

        Bank bank = new Bank(new FakeAccountManager(20, "EUR")); 
        var bankAccount = new BankAccount(20);

        Assert.That(bank.GetAccountBalance(), Is.EqualTo(expectedValue));
    }

    class FakeAccountManager : IAccountManager
    {
        private int centsToReturn;
        private string currency;

        public FakeAccountManager(int centsToReturn, string currency)
        {
            this.centsToReturn = centsToReturn;
            this.currency = currency;
        }

        public string Currency => currency;

        public int GetBalnceInCents()
        {
            return centsToReturn;
        }
    }

    [Test]
    public void GetAccountBalance_FormatsToMoney_WithFakeAccountManager()
    {
        string expectedValue = "20,00";

        Bank bank = new Bank(new FakeAccountManager(20, "USD"));
        
        Assert.That(bank.GetAccountBalance(), Is.EqualTo(expectedValue));
    }

    [Test]
    public void GetAccountBalance_FormatsToMoney_MockingLibrary()
    {
        var fakeAccountManager = new Mock<IAccountManager>();

        fakeAccountManager.Setup(m => m.GetBalnceInCents())
            .Returns(20); 

        Bank bank = new Bank(fakeAccountManager.Object);

        string expectedValue = "20,00";
        Assert.That(bank.GetAccountBalance(), Is.EqualTo(expectedValue));
    }

    [Test]
    public void GetCurrency_MockingLibrary()
    {
        var fakeAccountManager = new Mock<IAccountManager>();

        fakeAccountManager.Setup(m => m.Currency)
            .Returns("GBP"); 

        Bank bank = new Bank(fakeAccountManager.Object);

        string expectedValue = "GBP";
        Assert.That(fakeAccountManager.Object.Currency, Is.EqualTo(expectedValue));
    }
}