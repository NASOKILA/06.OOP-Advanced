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
        //Ako nqmame konstrukturi znachi shte grumne zashtoto nqmame instancii, zatova si gi pravim ruchno

        string expectedValue = "20,00";

        Bank bank = new Bank(new FakeAccountManager(20, "EUR")); //SLAGAME I CURRENCY^DORI I DA NE GO POLZVAME DOKATO SUS 'moq' TOVA GO IZBQGVAME
        var bankAccount = new BankAccount(20);
        //bank.accountManager = new FakeAccountManager(20);

        Assert.That(bank.GetAccountBalance(), Is.EqualTo(expectedValue));


        //AccountManager si ima konstruktor za BnkAccount account

        //CELTA TUK E D RAZBEREM CHE AKO IMAME MNOGO KLASOVE KOITO SE IZPOLZVAT EDIN V DRUG 
        //STAWA TRUDNO ZA TESTVANE ZASHTOTO IMAME MNOGO DEPENDENCI-ta


        //VVAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!
        //TOZI PROBLEM SE RESHAVA S INTERFEIS
        //MOJEM AVTOMATICHNO DA GENERIRAME INTERFEIS KATO SELEKTIRAME IMETO NA KLASA V NEGO , Dqsno kopche, refactoring, generate interface

    }


    //SUZDAVAME SI FALSHIV AccountManager ZA DA NI E PO LESNo, SPESTIQVAME KOD I BUGOVE.
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



    //TUK SHTE POLZVAME FakeAccountManager, PO TOZI NACHIN E PO DOBRE.
    [Test]
    public void GetAccountBalance_FormatsToMoney_WithFakeAccountManager()
    {
        //Ako nqmame konstrukturi znachi shte grumne zashtoto nqmame instancii, zatova si gi pravim ruchno

        string expectedValue = "20,00";

        Bank bank = new Bank(new FakeAccountManager(20, "USD"));
        
        Assert.That(bank.GetAccountBalance(), Is.EqualTo(expectedValue));
    }



    //DVATA METODA PRAVQT EDNO I SUSHTO SAMOCHE PO VTORIQ NACHIN E PO DOBRE ZASHTOTO ZAVISI OT INTERFACE A NE OT KONKRETNI INSTANCII NA DRUGI KLASOVE !!!
    //KATO IZVEJDAME INTERFEISI SPESTQVAME KOD 



    //SEGA SHTE IZPOLZVAME BIBLIOTEKATA 'moq' I SHTE SI NAPRAVIM FAKE_ KLAS 
    [Test]
    public void GetAccountBalance_FormatsToMoney_MockingLibrary()
    {
        //iska using moq;
        //Pravim si falshiviq akaunt
        var fakeAccountManager = new Mock<IAccountManager>();

        //trqbva da mu setnem STOINOST KOQTO DA VRUSTHA KOGATO MU IZVIKAME GetBalanceInCents();
        fakeAccountManager.Setup(m => m.GetBalnceInCents())
            .Returns(20); //setvame 20

        //podavame obekta mu vutre v bankata 
        Bank bank = new Bank(fakeAccountManager.Object);


        string expectedValue = "20,00";
        Assert.That(bank.GetAccountBalance(), Is.EqualTo(expectedValue));

        //VIJDAME CHE NQMA NUJDA DA SLAGAME CURRENCY NIKADE
    }


    [Test]
    public void GetCurrency_MockingLibrary()
    {
        //iska using moq;
        //Pravim si falshiviq akaunt
        var fakeAccountManager = new Mock<IAccountManager>();

        //trqbva da mu setnem STOINOST KOQTO DA VRUSTHA KOGATO MU IZVIKAME GetBalanceInCents();
        fakeAccountManager.Setup(m => m.Currency)
            .Returns("GBP"); //setvame 20

        //podavame obekta mu vutre v bankata 
        Bank bank = new Bank(fakeAccountManager.Object);


        string expectedValue = "GBP";
        Assert.That(fakeAccountManager.Object.Currency, Is.EqualTo(expectedValue));

        //VIJDAME CHE NQMA NUJDA DA SLAGAME CURRENCY NIKADE
        //SETUPVAME SAMO TOVA KOETO NI TRQBVA.
        //OBACHE 'moq' RABOTI S INTERFEISI.
    }







}

