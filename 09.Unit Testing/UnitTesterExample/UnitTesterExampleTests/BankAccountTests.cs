namespace UnitTesterExampleTests
{
    using NUnit.Framework;
    using System;
    using UnitTesterExample;

    [TestFixture] //S tozi atribut kazvame che tozi klas sudurja unit testove
    public class BankAccountTests
    {

        //predi setUp metoda ni trqbva takova pole koeto da setnem vednuj za da ne go pihem vuv vseki test
        BankAccount bankAccount;

        //Tova e kato BeforeEach v JS, izpulva se predi vseki test, po princip vmukvame povtarqshta se logiza
        [SetUp]
        public void InitializeTest()
        {
            //PREDI VSEKI METOD SE IZVIKVA TOZI METOD
            bankAccount = new BankAccount();
        }


        //Slagame mu speciqlen atribut s koito kazvame che tova e funckiq koqto shte testva neshto !!!
        //TRQBVA DA REBULDNA PROEKTA
        [Test]  //Moje mchre skobki da mu slojim i dopulnitelni neshta ... [Test(...)]
        public void DepositShouldIncreaseBalance()
        {
            //Kato si napravim takuv klas ni dobavq referenciq kum proekta kum koito shte pravim testovete
            //BankAccount bankAccount = new BankAccount();
            //NO AKO NQMAME NAMESPACE-ove NQMA DA NI PODSKAJE I TRQBVA DA DOBAVQME REFERENCIQTA RUCHNO, S DQSNO KOPCHE VURHU PROEKTA...

            //Pravim si testa
            bankAccount.Deposit(10);
            Assert.That(bankAccount.Balance, Is.EqualTo(10));

            //ZA DA PROVERIM DALI TESTA REBOTI KLIKVAME NA 'Run All' V 'Test Explorer' !!! 
            //AKO IMAME GRESHKA OT DOLO NI IZPISVA KAKVA E TQ

            //RAZGLEJDAME 'Assert' METODA: DAI MU Assetr. + SPACE i shte vidish
                //Assert.AreEqual(bankAccount.Balance, 10);     //Moje i taka.

            //MOJEM DA DEBUGVAME TESTOVE SUS Dqsno kopche na testa i 'Debug Selected Test' !!!
        }


        [Test ]
        public void WithDrawTest()
        {
            //Shte testvame withdraw metoda

            BankAccount bankAccount = new BankAccount();
            bankAccount.Deposit(10);
            bankAccount.Withdraw(5);

            Assert.AreEqual(bankAccount.Balance, 5); //Trqbva  balansa da e 5
        }

        //Assert.   IMA MNOGO NESHTA V NEGO


        //VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //TestCase(---) ATTRIBUTA POZVOLQVA DA VMUKVAME STOINOSTI S KOITO DA TESTVAME NASHIQ KOD
        //MOJEM DA NAPRAVIM MNOGO TESTOVE NA VEDNUJ
        [TestCase(10)]
        [TestCase(2255)]
        [TestCase(5)]
        //[TestCase(110, 55, 11)]    //MOJEM DA PODAVAME MNOGO PARAMETRI V EDIN TEST NO TRQBVA FUNKCIQTA DA GI PRIEMA
        public void WithDrawMethodThrowsExceptionInsufficientBalnce(int amount) //PRIEMAME GI CHREZ PARAMETUR
        {
            //TESTOVETE MOGAT I DA HVURLQT GRESHKI
            BankAccount bankAccount = new BankAccount();
            
            //TRQBVA DA HVURLI GRESHKA, TRQBVA DA MU PODADEM LAMBDA FUNKCIQ S KOQTO OBQSNQVAME NA NUNIT KAKVO TESTVAME
            Assert.Throws<InvalidOperationException>(() => bankAccount.Withdraw(amount));

            //Ovhakva tochniq tip Exeption
        }



        //TearDown metoda priema [TearDown] attribut i se izpulnqva sled vseki test,
        //mojem dago polzvame za zachistvane na danni ili daden fail primerno. 


    }
}
