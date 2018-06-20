namespace P02_KingsGambit
{
    using P02_KingsGambit.Interfaces;
    using System;

    public class RoyalGuard : Subordinate
    {
        public RoyalGuard(string name) : base(name, "defending")
        {
            this.Hits = 3;
        }

        
        public override void ReactToAttack()
        {
            if(this.IsAlive)
                Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}

