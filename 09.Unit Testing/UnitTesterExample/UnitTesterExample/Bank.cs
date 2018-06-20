using System;
using System.Collections.Generic;
using System.Text;

public class Bank
{

    //Klasa Bank polzva obekt ot tip AccountManager koito e drug klas
    //SLED KATO SI GENERIRAHME INTERFEIS E DOBRE DA GO POLZVAME NEGO
    private IAccountManager accountManager;


    public Bank(IAccountManager accountManager)
    {
        //AKO NE GO SETVAME TUK SHTE TRQBVA RUCHNO V TESTA DA SI NAPRAVIM INSTANCIQ NA ACCOUNTMANAGER
        //Obache ako e taka znachi AccountManager settera trqbva da e publichen inache ne mojem da go dostupim

        this.accountManager = accountManager;
    }


    //metoda polzva tozi obekt ot tip AccountManager
    //SHTE NAPRAVIM TESTOVE NA TOZI METOD
    public string GetAccountBalance()
    {
        //Metoda formatira ot integer kum double do dve chisla sled desetichna zapetaq tostringnato
        return accountManager.GetBalnceInCents().ToString("F2");
    }


}

