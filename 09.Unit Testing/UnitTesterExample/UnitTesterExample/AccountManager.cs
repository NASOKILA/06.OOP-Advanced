using System;
using System.Collections.Generic;
using System.Text;
using UnitTesterExample;

public class AccountManager : IAccountManager
{
    //account mangera polzva BankAccount
    public BankAccount Account { get; private set; }

    public string Currency => "BNG";

    public AccountManager(BankAccount account)
    {
        //AKO NE GO SETVAME TUK SHTE TRQBVA RUCHNO V TESTA DA SI NAPRAVIM INSTANCIQ NA ACCOUNT
        //Obache ako e taka znachi Account settera trqbva da e publichen inache ne mojem da go dostupim

        //balansa se setva na 0
        this.Account = account;
    }

    public int GetBalnceInCents()
    {
        //vrushtame balansa
        return Account.Balance;
    }

}

