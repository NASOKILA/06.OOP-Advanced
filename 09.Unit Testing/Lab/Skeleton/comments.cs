namespace Skeleton
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class comments
    {
        /*
         
        PROVERI UnitTestExample i UnitTestExampleTests PROEKTITE !!!

            Shte razgedme:
                01.7 unit principi
                02.Kakvo e unit test ?
                03.dobri praktiki
                04.NUnit3 - unit tests engine framework 
                05.Mockvane i mock obekti - kak da suzdavame falshivi neshta s koito da si testvame unit testovete
            
            
                01. 7 Unit principi
                
                    Po princip specialni developerti (testeri) se zanimavat s testvane na aplikacii.
                    
                    V MNOGO FIRMI SAMITE DEVELOPERI SI TESTVAT SOBSTVENIQ KOD.
                    Testerite sledvat 7 pravila za testvane:

                    Testva se po vajnata funkcionalnost, ne vsichko moje da se iztestva v edno prilojenie.

                    Kolkoto po KUSNO se nameri daden bug tolkova poveche pri se vzimat za da se opravi.
                    Nai Skupi i slojni sa bugovete v specifikaciqta i arhitekturata.

                    Ako ima nov tester vuv firmata i namira mnogo bugove, drugite programisti s vremeto se 
                    adaptirat kum nego i kak toi testva.
                    TESTOVETE TRQBVA DA SA RAZNOOBRAZNI.

                    Ako ne namirame bugove ne oznachava che gi nqma.

                    KOGATO IMAME PREKALENO MNOGO BUGOVE SISTEMATA NE RABOTI ZA 
                    Trqbva nie da go testvame koda pone vednuj predi da go podadem na testera.
         
                    

                02.kakvo e unit test ? 
                    Znaem kakvo e, mojem da si testvame koda koeto go pravi po kachestven, po lesno 
                    se namirat grreshki.
                    PRAVAT SE TESTOVE i SE GLEDA DALI MINAVAT NA NSHIQ KOD.


                    Manual Testing (ruchno tetvane):
                        Taka sa testvali predi da izlezne unit testvaneto.
                        Ne e strukturirano.
                        Ne moje da se povtarq.
                        Gubi se mnogo vreme i ne se pokriva celiq kod.
                        I ne e tolkova lesno kakto v unit tetvaneto.                    
                        
                        Unit testvaneto e mnogo po burzo, lesno i efektivno.
                    
                    Celata e da si napravim struktura oqto da moje da refaktorira,
                    da namalqva nomera na defektite v koda, i da se podobrqva disaign-a na koda ni.

                

                    VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    Autamated Testing:
                        01.System tests  -  Tova e nai golqmata edinica, tova e kato dolnoto
                            (integration tests) samoche na po visoko nivo , testvat se celi sistemi, 
                            TOVA E SUVKUPNOST OT MODULI
                            
                        02.Integration tests  -  Sredna edinice, proverqva POSLEDOVATELNOSTTA 
                            NA NQKOLKO NESHTA, DALI SHTE IMAT DADEN REZULTAT,  
                            TOVA E MODUL

                        03.Unit test  -  nai malkata edinica, mnogo malki parchenca kod
                            TOVA E KLAS




                04.NUnit 3
                    Proizlqzlo e ot Junit (za Java) i posle e bilo prezapisano.
                    Open source e.
                    V momenta versiqta e 3.10

                    NUnit vs MSTest:
                        MSTest e oshte edin framework za testvane obache ima updeiti samo vednuj na vsqka nova 
                        VS versiq dokat NUnit se updeitva po chesto.
                        Exceptionite se handelvat po po razlichen nachin.                    

                        NUnit se moje da se istalira i kato NUGET PACKAGE, 
                        pozvolqva testove s parametri.
                        
                   Ot paketite trqbva da go instalirame za da moje Visual Studio da ni chete 
                        testovete.
                    
                   MOjem da instalirame NUnit i chrez samiq kod, bez da vlizame v Nuget aketite.
                    


            VAJNOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            DOBRI PRAKTIKI:

                IMENATA NA TESTOVETE MOJE I DA SA MNOGO DULGI, NQMA PROBLEM !!!
                CELTA E DA SE OTISVAT KAKVO TESTVAME I OCHAKVANIQTA V SAMOTO IME !!!

                Condition Asserts:
                    Kogato iskme da testvame dali neshto e true ili false mojem da 
                    polzvame Assert.That(bolevaPromenliva);
                
                Comparision Asserts:
                    Kogato iskame da testvame dali neshtoe e ravno na neshto drugo polzvame            
                    Assert.That(VARIABLE, Is.EqualTo(EXPECTEDVALUE));  ili 
                    Assert.AreEqual(EXPECTEDVALUE, VARIABLE)
        
                Exeption Asserts:
                    Assert.That(() => {code}, Throws.ExeptionType);   Mojem i da proverqvame suobshtenieto
                    Assert.That(() => {code},
                        Throws.InvalidOperationException.With.Message.EqualTo(MESSAGE));

                String Asserts:
                    Assert.That(stringVariable, Does.Contain(EXPECTEDSTRING));  //Proverqvame dali daden string se sudurja v drug string

                Collection Asserts:
                    Assert.That(IENUMERABLE KOLEKCIQ, Has.MEmber(EXPECTED_MEMBER));  //Proverqva dali neshto se sudurja v dadena kolekciq

                File Asserts ...
                IMA I OSHTE MNOGO...

                VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                HUBAVO E DA NE POLZVAME MAGICHESKI CHILA A DA SI IZPISVAME KONSTATNTI SUS STOINOSTI V NACHALOTO NA TESTOVETE.



            VAJNOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!
                Metodite SetUo i TearDown :
                    Te sudurjat [SetUp] i [TearDown] attributi.
                    TE SA KAT BeforeEach()  i AfterEach() V JavaScript
                    Trqbvat ni poleta koito da setvame v SetUp metoda !!!
                    ZA DA VIDIM DALI REBOTI PRAVILNO MOJEM DA GO DEBUGNEM I DA VIDIM KOLKO PUTI MINAVA OT TAM.
                    MOJEM DA GI POLZVME AKO IMAME EDNAKVA LOGIKA ZA VSICHKI TESTOVE !!!!
                    Vij v UnitTestExampleTests BancAccountTests



            VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!
            Debugvane na testove:
                Za da debugnem daden test go selektirame, posled dqsno kopche i debug selected test.
                MOJEM DA DEBUGVAME NQKOLKO TESTA NA VEDNUJ PO SUSHTIQ NACHIN KATO GI SELEKTIRAME.


        
            VAJNOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!! 
                Vsichki Unit testove sa void metodi, NQMA SMISUL DA VRUSHTATA STOINOST ZASHTOTO SE EXECUTVAT OT NUnit. 
                ZA REALNI PROEKTI E PREPORUCHITELNO AKO KLIENTA ISKA DA MU SE NAPISHAT UNIT TESTOVE TOVA PODOBRQVA KACHESTVOTO NA PRODUKTA.
         

            MOJEM DA PROVERQVAME KONSTRUKTURI S UNIT TESTOVE !!!!
         
         */





        /*
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





