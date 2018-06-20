namespace P02_KingsGambit
{
    using P02_KingsGambit.Interfaces;
    using System;

    public class Footman : Subordinate
    {
        public Footman(string name) : base(name, "panicking")
        {
            this.Hits = 2;
        }
    }
}
