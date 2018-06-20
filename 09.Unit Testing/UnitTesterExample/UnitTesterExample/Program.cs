namespace UnitTesterExample
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            /*
             
            //Testovete s pishat v nov proekt
            //MOjem da instalirame NUnit i chrez samiq kod, bez da vlizame v Nuget aketite.

            //SEGA SHTE GO INSTALIRAME OT NUGET PAKETITE
            

             Instalirame:  
                'NUnit' : Pozvolqva ni da pishem testove,
                'NUnit3TestAdapter' : Pozvolqva ni da gi runvame vuv Visual Studio
                'Microsoft.Net.Test.Sdk'  : Adaptera s koito pusmkame Unit testovete se nujdae ot tazi biblioteka
            
            //SLED INSTALIRANETO REBUILDVAME Solution-a !!!!!!!!!!!!!!

            //Pravim 'UnitTestExampleTests' proekt koito e  bibilioteka class lybrary 
            //v koqto shte sa nashite testove.

            
             VAJNO:
                Otvarqme si 'test expolrer' ot  'Test > Window > TestExplorer'  za da si sledim testovete.
                RUNVAME GI S 'Run All' i ni pokazva dali testa e minal ili ne.
            
             VAJNOOOOOOOOOOO!!!!!!!!!!!!!!!
                TESTOVETE SE PISHAT V OTDELEN PROEKT KOITO E S IMETO NA TOZI KOITO HTe tESTVAME SAMOCH SUS 'Tests' NAI OTZAD.
                Primerno : CarProject i CarProjectTests TRQBVA DA SA IMAENATA NA DVATA PROEKTA.
                TOVA E KONVENCIQ NA NUnit !!!!!!!!!!!!!!
              
             AAA:
                Arrange - podgotvqme koda v testa,
                Act - izvikvame koda ot testa,
                Assert - Proverqvame rezultata ot testa sled izvikvaneto na koda sus 'Assert'
             
             VAJNOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!
             [Test] - Kazvame  che tova e test i to NE moje da priema parametri
             
             [TestCase(param1, param2, param3, ...)]  -  Mojem da podavame parametri i da testvame 
                mnogo testove na vednuj 
             
             IMA I DRUGI ATTRIBUTI ... NQKOIT OT TQH NE IDVAT OT NUNIT A OT SAMIQ .Net Framework !!!
            



            VAJNOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!
            Metodite SetUo i TearDown:
            Te sudurjat[SetUp] i[TearDown] attributi.
                    TE SA KAT BeforeEach()  i AfterEach() V JavaScript
                    Trqbvat ni poleta koito da setvame v SetUp metoda !!!
                    ZA DA VIDIM DALI REBOTI PRAVILNO MOJEM DA GO DEBUGNEM I DA VIDIM KOLKO PUTI MINAVA OT TAM.
                    MOJEM DA GI POLZVME AKO IMAME EDNAKVA LOGIKA ZA VSICHKI TESTOVE !!!!
                    PO NQKOGA NE NI VURSHI RABOTA I MOJEM DA SI NAPRAVIM OTDELN METODI KOITO DA POLZVAME PREDI ILI VUV VSEKI TEST.
                    Vij v UnitTestExampleTests BancAccountTests



            VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!
            Debugvane na testove:
                Za da debugnem daden test go selektirame, posled dqsno kopche i debug selected test.
                MOJEM DA DEBUGVAME NQKOLKO TESTA NA VEDNUJ PO SUSHTIQ NACHIN KATO GI SELEKTIRAME.



            Imenuvane na testove:
                IMENATA NA TESTOVETE MOJE I DA SA MNOGO DULGI, NQMA PROBLEM !!!
                CELTA E DA SE OTISVAT KAKVO TESTVAME I OCHAKVANIQTA V SAMOTO IME !!!

        



            VAJNOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!! 
                Vsichki Unit testove sa void metodi, NQMA SMISUL DA VRUSHTATA STOINOST ZASHTOTO SE EXECUTVAT OT NUnit. 
                ZA REALNI PROEKTI E PREPORUCHITELNO AKO KLIENTA ISKA DA MU SE NAPISHAT UNIT TESTOVE TOVA PODOBRQVA KACHESTVOTO NA PRODUKTA.
             

            
            MOJEM DA PROVERQVAME KONSTRUKTURI S UNIT TESTOVE !!!!
            Vij UnitTestExample Person klasa

            
        VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            DEPENDENCIES:
                Po dobre da polzvame interfeisi otkolkoto klasove zashtoto chsto se sluchvat bugove
                zashtoto moje da imame klas koito da polzva drug klas.
                Nqkoi klasove v konstrukturite poluchavat instancii ot drugi klasove, PO DOBRE DA GO 
                NAPRAVIM TAKA CHE DA POLUCHAVAT INTERFEISI OT KOLKOTO SAMITE KLASOVE.
                Vij v UnitTestExample testovete za klasovete AccountManager i Bank 
                    
                KOGATO IMAME KLASOVE KOITO PREIZPOLZVAT DRUGI KLASOVE STAWA TRUDNO ZA TESTVANE ZATOVA 
                SI PRAVIM INTERFEISI.

                VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    Selektirame samoti ime na kalsa, 'dqsno kopche' , posle 'refactoring' i 'extract interface' 
                    AVTOMATICHNO NI GENERIRA INTERFEISA !!!!!!!!!!!!!!!!!!!!!!!!!!
                
                    CELTA E DA ZAVISIM OT INTERFEISI I DA GO INJECTVAME PREZ KONSTRUKTURITE.
                    I MOJEM DA PRAVIM FAKE_CLASSES ZA DA NI BUDE PO LESNO TESTVANETO 
                        Vij UnitTestExample BankTests
                  
                
            
        Mocking:
            Vmesto da suzdavame ruchno FAKE_CLASSES ima edna biblioteka koqto go pravi avtomatichno za nas.
            Naricha se 'moq' tova e Mocking Framework .

            Instalaciq:
                Dqsno kopche na nashiq proekt,
                INSTALIRAME GO OT NugetPackagees
                Tursim 'moq' i go instalirame

                CELTA E DA MAHNEM FAKE_KLASOVETE ZASHTOTO INACHE TRQBVA ZA
                VSEKI UNIT TEST.

                
           IMA I DRUGI TAKIVA BIBLIOTEKI KOITO DA SUZDAVAT FALSHIVI KLASOVE.
           OBACHE 'moq' RABOTI S INTERFEISI.
            
            MOJEM I DA VERIFICIRAME KOI METOD SE E IZVIKAL I S KAKVO SE E IZVIKAL.


        VAJNOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Start Live unit Testing:
                Tova e nastroika koqto ni runva testovete avtomaticho pri promqna na koda.
            
                OUSKAME GO OT: Navigacionnoto meniq    Tests > Live Unit Testing
        

             */

        }
    }
}




