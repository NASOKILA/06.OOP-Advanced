using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {

            //NAPRAVIHME OBSH   IStreamProgressInfo  INTERFEIS SUS OBSHTOTO MEJDU File I Music ZA DA MOJE DA 
            //ZA DA MOJE DA SE POLZVAT I DVATA OT StreamProgressInfo KLASA
            var progressInfo = new StreamProgressInfo(new File("my file", 100, 1000));

            var progressInfo2 = new StreamProgressInfo(new Music("Lili Ivanova", "Vetrove", 5, 13));

            //SeGA VIJDAME CHE I DVATA KLASA Music I File SA VALIDNI ZA StreamProgressInfo KLASA.

        }
    }
}
