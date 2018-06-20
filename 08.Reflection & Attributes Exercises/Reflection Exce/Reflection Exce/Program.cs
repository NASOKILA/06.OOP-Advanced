using System;


public class Program
{
    static void Main(string[] args)
    {

        /*
            Comments:
                '^' - e znam koito sravnqva po bitovo pokzva 'true' kogato ednoto e true a drugoto ne e !
                Assembly - e vseki otdelen proekt
         */
        Console.WriteLine(true ^ true);
        Console.WriteLine(false ^ false);
        Console.WriteLine(true ^ false);
        Console.WriteLine(false ^ true);
        Console.WriteLine(1 ^ 0);


        //SERVICE PROVIDERA MNOGO CHESTO SE IZPOLZVA ZA DEPENDENCY INJECTION

    }
}

