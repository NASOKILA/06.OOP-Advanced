namespace P02_KingsGambit
{
    using P02_KingsGambit.Interfaces;
    using System;
    using System.Collections.Generic;

    public class King : IKing   
    {
        public event GetAttackedEventHandler GetAttackedEvent;

        private ICollection<ISubordinate> subordinates;
        
        public string Name { get; }

        public King(string name, ICollection<ISubordinate> subordinates)
        {
            this.Name = name;
            this.subordinates = subordinates;
        }
        
        public IReadOnlyCollection<ISubordinate> Subordinates => (IReadOnlyCollection<ISubordinate>)this.subordinates;
        
        public void GetAttacked()
        {
            Console.WriteLine($"{this.GetType().Name} {this.Name} is under attack!");

            if (this.GetAttackedEvent != null)
            {
                this.GetAttackedEvent.Invoke();
            }
        }
        
        public void RemoveSubortinate(ISubordinate subordinate)
        {
            this.subordinates.Remove(subordinate);

            this.GetAttackedEvent -= subordinate.ReactToAttack;
        }
        
        public void AddSubortinate(ISubordinate subordinate)
        {
            this.subordinates.Add(subordinate);

            subordinate.DeathSubordinate += this.OnSubordinateDeath;

            this.GetAttackedEvent += subordinate.ReactToAttack;
        }

        public void OnSubordinateDeath(object sender)
        {
            this.subordinates.Remove((ISubordinate)sender);
        }
    }
}