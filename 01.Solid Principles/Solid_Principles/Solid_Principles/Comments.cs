using System;

namespace Solid_Principles
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             
             Veche sme q vijdali tazi praktika, 
             trqbvaa ni godini opit za da sviknem dobre da q prilagame.

            Chistiq kod e polezen, trbva da pishem kod lesen za chetene i za pisane.


            SOLID PRINCIPLES:

            01.Single Responsability:
                Da NE slagame mnogo neshta v edno, ako imame edin klas koito da pravi mnogo neshta
                    ako opitame da promenim neshto malko to shte schupi i drugi neshta v proekta.
                Vseki klas trqbva da otgovarq smo za edna funkcionalnost.
                Klasa trqbva da se zanimava samo s edno neshto.






        Stron Cohesion & Loose Coupling 
            Stron Cohesion - Silna splotenost, t.e. klasa da e fokusiran vurhu samo edno neshto.

            Loose Coupling - Tova e kogato koda ni e mnooogo oburkan i truden za opravqne, opisan e 
                kato topche s kabeli.
                TRQBVA da se stremim s edna malka promqna v edin fail da afektirame i drugi za da ne 
                hodim na 10 mesta da promenqme kod.

            S unit testovete shte sviknem da pishem pravilen kod.

            KAKVO DA PRAVIM ? 
                promenlivite i metodite v klasovete da sa malko na broi, ne moje da imame primerno 2000 reda kod v edin klas,
                dobre e da se razdeli na nqkolko klasa.

                Dva modula bi trqbvalo da otmenqt vuzmojno po malko informaciq.
                    
             




           //VAJNOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                Ne e hubavo da pishem mnogo 'statichni' metodi v proekti osven ako ne iskame da extendvame
                daden metod.

            


            
            //VAJNOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                Dobra praktika e vmesto da hvurlqme navsqkude exceptioni da si napravim edin klas koito da gi 
                sudurja i da gi vzimame ot nego.

                Ili da si napravim klas koito da ima metod koito priema exception i ni vruhta 
                    suobshtenieto ot dadena greshka.   
            



            02.Open & Closed Principles:
                Klasovete, metodite i modulite koito pravim teqbva da sa lesni za extendvane i
                no trudni za modificirane.
                'Open for extensions & Closed for modifications.'

            Reusability - da preizpolzvame kod koito veche sme napisali.
            
            Design Smell Violations - Tova e kogato vijdame che neshto ne e nared s dizaina na aplikaciqta
                i znaem che shte ima nqkakvi greshki.
                NOVITE NESHTA NE TRQBVA DA AFEKTIRAT STARITE ZASHTOTO SHTE IMA BUGOVE.
                AKO PROMQNATA V EDIN MODUL PROMENQ I DRUGITE ZNACHI NESHtO NE E NARED.





            OCP - Approaches
                Trqbva da razchitame na ABSTRAKCIQ  NE NA IMPLEMENTACIQ.
                
                MOJEM DA POLZVAME I 'DEPENDENCY INJECTION':
                Kogato ni trqbva promqna taka trqbva da ni e strukturiran koda che 
                kato promenim edno neshto da se promenat vsichki neshta koito iskame.

            Refactoring:
                Postoqnno se pravi v programiraneto, mojem edin golqm klas da go razdelim na 
                mnogo malki klasove.





            VAJNOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            TEMPLATE METHOD PATTERN (TMP):
                Tuk imame bazov abstrakten klas s nqkakva funkcionalnost, 
                v nego imame :
                01.Template Method
                02.StepOneMethod()          abstrakten metod
                03.StepTwoMethod()          abstrakten metod
            
            Template Methoda izvikva abstraktnite metodi !!!!!!!!!!!!!


            


            03.Liskov Substitution Principle:
                Klasovete deca da mogat da se kastnat kum bazoviq klas BEZ DA MU NARUSHAVATLOGIKATA.
                NE TRQBVA DA IMA VIRTUALNI METODI V KONSTRUKTURITE
                
                Ne e vuzmojno daden Child klas da se inicilizira chrez konstruktura na negoviq bazov klas
                koito bazov klas obache polzva metod ot decata si
                Tova e NEVUZMOJNO ZASHTOTO DECATA NE SA OSHTE INICIALIZIRANI.





            04.Interface Segregation:
                Ako imame obshti chasti mejdu nqkolko neshta si pravim za vsqko obshto neshto po edin
                interfeis vmesto samo edin golqm interfeis.
                Ideqta e da imame mnogo malki i leki interfeisi vmesto edin golqm debel interfeis
                zashtoto e po lesno za refkturirane i za promenqne.

            VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                Ako dva interfeisa imat mnogo metodi obache imat i edin obsht metod, mojem 
                da si napravim otdelen interfeis sudurjasht samo tozi metod.



            Adapter Pattern:
                Tova e kogato imame neshto otvunka kato vunshen service
                togava si pravim adapred koito da n go izivikva puk nie da izvikvame tozi 
                suzdaden ot nas adapter.










            05.Dependency Inversion Principle
                Neshtata trqbva da zavisqt ot abstrakciqta
                Dependency e vseki vunshen komponent koito za da go promenim NE e nujno da se 
                obtushtame direktno kum nego.
                Primeri:
                    Framework,
                    Database,
                    'new' keyword,
                    File System,
                    Web Service,
                    Static methods,
                    Console,
                    Global function,
                    ...

                Tova sa neshta koito zavisqt ot drugi neshta.  


            Types of Dependency Injection:

                01.Constructor Injection - Kogato kazvame na daden klas che trqbva da poluchi neshto v konstruktura.
                    inache nqma da moje da se instancira.
                
                02.Property Injection - Pravim podobno neshto samoche ne v konstruktura a polzvame 
                    suzdadeno ot nas property, t.e. sled suzdavaneto da si go setnem ot vunka.  //LESNO E
                
                03.Parameter Injection - Dadenoto neshto (Interfeis primerno) se iziskva kato parametur 
                    na funkiite NE SE POLZVA MNOGO

                KONSTRUKTOR INJECtioN E NAI DOBRIQ VARIANT



            Summary:
                01.Single Responsability Principle  -  Edin kas trqbva da se zanimava samo s edno neshto
                02.Open/Closed Principle  -  Da promenqme daden kla samo kogato negovata logika e promenena a ne kogato prosto go extendvame
                03.Liskov Substitution Principle  -  Prosto da mojem da dobavqme novi CHILD klasove
                    bez da promenqme logikata na bazoviq klas ili na drugite sushtestvuvashti derived klasove.
                04.Interfeis Segragation Principle  -  po dobre da pravim povechko malki interfeisi otkolkoto
                    samo edin golqm zashtoto moje da se implementira v klas na koito NE mu trqbvat vsichki 
                    neshta v tozi golqm interfeis.
                05.Dependency Inversion  -  Razgledahme Razlichnite vidove dependency injection, nai polzvanoto e 
                    Contruktor injection ,prosto kazvame koi interfeis na koi klas da otgovarq.



            //NE E NUJNO D GI ZNEM VSICHKI NA IZUS.
            
            

             */
             
        }
    }
}
