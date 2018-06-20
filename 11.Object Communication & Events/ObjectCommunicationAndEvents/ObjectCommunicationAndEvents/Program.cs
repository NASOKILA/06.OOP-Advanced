using System;


public class Program
{

    //suzdavame si delegat koito priema string i vrushta void
    //Mojem da gi setvame na drugi funkcii koito priemat string i vrushtat void
    public delegate void DelegateToPrint(string stringToPrint);

    

    static void Main(string[] args)
    {



        //VAJNOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //System.Threading.Thread.Sleep(2000);     e kto setTimeont(function(){}, 2000); v JavaScript


        //printirame sekundite v segashtnata data
        Console.WriteLine(DateTime.Now.Second);
        
        //Shte zabavim koda s 2 sekundi
        System.Threading.Thread.Sleep(2000);

        Console.WriteLine(DateTime.Now.Second);

        Console.WriteLine();





        /*
        Shte govorim za eventi i delegati:
            01.Delegats,
            02.Events
                Evants vs Delegates
                EventHandlers
                Custom Events,
            03.ObserverPtterns  -  Neshto kato NOTIFICATiON, kazva na subscriberite za nqkuv event
      
        
        01.Delegates:
            Delegatite sa bputq mejdu eventa i eventhandlera (PREDSTAVI SI DETE (event) i RODITEL (eventHandler)) 
            Za edni event moje da imame mnogo subscriberi zatova moje da imame nqkolko delekgati 
            koito da obslujvat tezi delegati.
            Delegata TIP no e i funkciq i mojem da q polzvame kato TIP na PROMENLIVA.     
            I mojem da q podavame kato parametur na drugi funkcii.
            Te sa kato POINTERITE v C i C++;

            Func<> i Action<> sa delegati mojem da se tvame neshta i nda tqh
        */


        Program.PrintToConsole("Hello World!");

        //Mojem da setvame delegata na drugi funkcii i dagi pozvame
        DelegateToPrint functionToPrint = PrintToConsole;
        functionToPrint("Hello World From a delegate function!");

        //VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!
        //MOJEM DA POLZVAME Func I Action, TE SA GOTOVI DELEGATI I MOJEM DA GI POLZVAME
        Action<string> actionPrint = PrintToConsole1;

        //Funkciqta ne pravi nishto no otgovarq na usloviqta na delegata i zatova mojem da q setneme
        DelegateToPrint functonDoNothing = DoNothing;
        functonDoNothing("Nothing");
        
        //MOJEM DA POLZVAME DELEGATITE KATO PARAMETRI ZA DRUGI FUNKCII I DA GI POLZVAME VUTRE V TQH
        Program.PrintStringByFunction(functionToPrint, "Hello from delegate passed as a parameter");


        Console.WriteLine();
        //Edin delegate moje da ima nqkolko parametura, mojem da imame dva delegata s razlichni imena NO SUS EDNAKVI KRITERII.
        DelegateToPrint delegateToPrint1 = PrintToConsole1;
        delegateToPrint1("Hello");

        DelegateToPrint delegateToPrint2 = PrintToConsole2;
        delegateToPrint2("Hello");


        //MOJEM DA NAVURZVAME DELEGATI
        //Shte se izpulnqt vsichki po red
        Console.WriteLine();
        DelegateToPrint delegateToPrintChain = PrintToConsole1;
        delegateToPrintChain += PrintToConsole2;
        delegateToPrintChain += PrintToConsole3;
        delegateToPrintChain("Hello");


        //MOJEM I  DA GI MAHAME SUS -
        delegateToPrintChain += PrintToConsole2;
        delegateToPrintChain -= PrintToConsole2;


        //DELEGATITE IMAT MNOGOG FUNKCIONALNOSTI VIJ . + SPACE
        Console.WriteLine();
        var functionsUsedByDelegate = delegateToPrintChain.GetInvocationList(); // vrushta vsichkipolzvani funkcii

        //Mojem da gi foreachvame i daje sus for cikul mojem da mahame i dobavqme novi funkcii kum nashiq delegat 
        //Mojem i da extractvame delegati
        foreach (var del in functionsUsedByDelegate)
        {
            Console.WriteLine(del);
        }

        /*
         MULTICAts DELEGATES:
            Mojem da setvame nqkolko funkcii v edin delegat, te shte se izpulnqt edna sled druga.    
         
         
         */


        Console.WriteLine();
        //VAJNOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //Mojem v Action<> da assignvame i Lambda expressions koito sa sakraten variant na funkciq   


        //DELEGATITE MOGAT DA SE IZVIKVAT I PO DRUG NACHIN, Chrez '.invoke();' METODA
        delegateToPrint1.Invoke("Invoke method used");
        //sushtotto e kato delegateToPrint1("Invoke method used");


        //EDIN DELEGAT MOJE DA E NULL, MOJEM DA SUKRATIM if(...){...} sus '?'  !!!
        delegateToPrint1?.Invoke("Not null");




        /*
        02.Events:

            EVENTITE SA MNOGO PODOBNI NA DELEGATITE !!!!!!!!!!!!!!!!!!!!!!!!
            MOJEM DA IM ASSIGNNEM I NA TQH SPISUK SUS FUNKCII KOITO DA SE IZPULNQVAT.
            Znaem kakvo sa eventite !!! LESNI SA !
            Event e neshto koeto se e sluchilo, te sa notifikacii.
            Eventi ima na vsqkude.
            Znaem kakvo e klick event !!!

            Event Handler :
                Event Handler e kod koito se aktivira kogato se sluchi.
                Po princip e funkciq koqto poluchava dva parametura 'Sender' i 'EventArgs'
                    'Sender' - tozi koito e izpratil eventa
                    'EventArgs' - informaciqta za eventa, MOJEM DA VKARVAME DANNI ZA EVENTA V EVENTHANDLER FUNKCIQTA.

            Custom Event Handler:
                Tova e event andler koito moje da poluchava poveche ot 2 parametura
                NIE SAMI MOJEM DA SI NAPRAVIM.



            Kak da si napravim nashi si eventi,
            po princip se polzvat gotovi eventi.
            Polzvat se mngogo pri WPF (Windows forms Application) 
         

            
            Razlikata mejdu Eventi i Delegati:
                Eventite mogat da se opisvat v interfeis dokato delegatite ne mogat.
                Eventite sa chasti ot klas koito trqbva da budat izvikani samo ot tozi klas.

        
            Ima nad 150 vida eventa, nai izpolzvaniqt e click eventa i mouseMouve, eyPress i dr.

         */




        /*
         Event loop:
            Pravili sme go v konzolnite prilojeniq,
            Tova e kato da imame while() cikul v koito da imame Console.ReadLine() i da chakame usera da 
            ni podade neshto.
            Sushto taka v nego da imame i Environmenr.Exit(0);
         
         
         */




        /*
            Observer design pattern:
                Tova e kogato dadeni useri iskat da se priseidenqt kum nqkakvo subitie.
        
            PRIMER: KAK SE DOBAVQT
                Subject subject = new Subject();
                subject.addObserver(new Observer());
                subject.addObserver(new Observer());
        
            NIE VECHE GO NAPRAVIHME PO GORE S DELEGATITE. 
                DOBAVQHME GI SUS  '+='
                I GI MAHAHME SUS '-='
                
                

         */


    }



    private static void PrintToConsole(string stringToPrint)
    {
        Console.WriteLine(stringToPrint);
    }

    private static void PrintToConsole1(string stringToPrint)
    {
        Console.WriteLine("!: 1 " + stringToPrint);
    }
    
    private static void PrintToConsole2(string stringToPrint)
    {
        Console.WriteLine("!: 2 " + stringToPrint);
    }

    private static void PrintToConsole3(string stringToPrint)
    {
        Console.WriteLine("!: 3 " + stringToPrint);
    }



    private static void DoNothing(string stringParam)
    {

    }

    //Funkciq koqto priema za parametur druga funkciq i q polzva
    private static void PrintStringByFunction(DelegateToPrint delegateToPrint, string str)
    {
        //polzvam epodadenata funkciq s podadeniq string
        delegateToPrint(str);
    }



    /*
      
     Summary:
        Delegat e promenliva ot tip metod,
        Multicast delegat e delegat s mnogo metodi v nego,
        Zapazva se reda i se izvikvat asinhromno, toest te se izchakvat !!!
        Kogato nqkoi izvika delegata  shte se izvikat vsichki funkciiv nego
        Eventite sa delegati, razliata e che eventite mogat da se definirat i v INTERFEIS
        Moje da imame eventi koito da primat samo delegati !!!!!
        Ideqta na eventite e da kajat na tehnite subscriberi che samiq event se e sluchil i te da si
            hendelvat tehniq si kod.
     */



}

