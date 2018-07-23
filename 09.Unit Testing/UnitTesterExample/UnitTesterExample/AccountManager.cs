using System;
using System.Collections.Generic;
using System.Text;
using UnitTesterExample;

public class AccountManager : IAccountManager
{
    public BankAccount Account { get; private set; }

    public string Currency => "BNG";

    public AccountManager(BankAccount account)
    {     
        this.Account = account;
    }

    public int GetBalnceInCents()
    {
        return Account.Balance;
    }
}