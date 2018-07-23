using System;
using System.Collections.Generic;
using System.Text;

public class Bank
{
    private IAccountManager accountManager;

    public Bank(IAccountManager accountManager)
    {
        this.accountManager = accountManager;
    }

    public string GetAccountBalance()
    {
        return accountManager.GetBalnceInCents().ToString("F2");
    }
}