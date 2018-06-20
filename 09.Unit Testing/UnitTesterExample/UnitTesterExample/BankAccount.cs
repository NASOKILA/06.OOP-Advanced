namespace UnitTesterExample
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BankAccount
    {

        public BankAccount()
        {
            this.Balance = 0;
        }

        public BankAccount(int balance)
        {
            this.Balance = balance;
        }

        public int Balance { get; private set; }

        public void Deposit(int amount)
        {
            this.Balance += amount;
        }

        public void Withdraw(int amount)
        {
            if (this.Balance < amount)
                throw new InvalidOperationException("Insufficient balance !");

            this.Balance -= amount;
        }

    }
}
