namespace P02_KingsGambit
{
    using Interfaces;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private IKing king;

        public Engine(IKing king)
        {
            this.king = king;
        }

        //vmukvame si kralq
        public void Run()
        {
            string input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split().ToArray();

                string command = tokens[0];
                string name = tokens[1];

                switch (command)
                {
                    case "Attack":
                        //kralq i podchinenite mu reaigirat na atakata
                        king.GetAttacked();
                        break;
                    case "Kill":
                        //trqbva da ubiem podchineniq
                        //namirame go po ime kato go tursim v kralq
                        ISubordinate subordinate = king.Subordinates.First(s => s.Name == name);

                        //i go obivame
                        subordinate.TakeDamage();

                        //TRQBVA DA STANE S EVENT  NE S METOD I PROVERKA NA VSEKI 'Kill'
                        //if (!subordinate.IsAlive)
                        //  king.RemoveSubortinate(subordinate);



                        break;
                    default:
                        throw new ArgumentException("Invalid Command !");
                }

            }

        }

    }
}
