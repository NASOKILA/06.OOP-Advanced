namespace UnitTesterExampleTests
{
    using NUnit.Framework;
    using System;
    using UnitTesterExample;

    [TestFixture] 
    public class BankAccountTests
    {
        BankAccount bankAccount;

        [SetUp]
        public void InitializeTest()
        {
            bankAccount = new BankAccount();
        }

        [Test]  
        public void DepositShouldIncreaseBalance()
        {
            bankAccount.Deposit(10);
            
			Assert.That(bankAccount.Balance, Is.EqualTo(10));
        }

        [Test ]
        public void WithDrawTest()
        {
            BankAccount bankAccount = new BankAccount();
            bankAccount.Deposit(10);
            bankAccount.Withdraw(5);

            Assert.AreEqual(bankAccount.Balance, 5); 
        }

        [TestCase(10)]
        [TestCase(2255)]
        [TestCase(5)]	
        public void WithDrawMethodThrowsExceptionInsufficientBalnce(int amount)
        {        
            BankAccount bankAccount = new BankAccount();
            
            Assert.Throws<InvalidOperationException>(() => bankAccount.Withdraw(amount));
        }
    }
}