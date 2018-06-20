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
        
        //Kastvame go kum private kolekciqta
        public IReadOnlyCollection<ISubordinate> Subordinates => (IReadOnlyCollection<ISubordinate>)this.subordinates;
        
        public void GetAttacked()
        {
            Console.WriteLine($"{this.GetType().Name} {this.Name} is under attack!");

            //Ako eventa ne e null TOEST AKO NE E PRAZEN A IMA NESHTO VUTRE
            if (this.GetAttackedEvent != null)
            {
                //ako imame metodi v zakacheni za tozi event gi izvikvame
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

            //trqbva da se zakachim kum eventa na podchineniq za da znaem koga eumrql i da go premahnem
            subordinate.DeathSubordinate += this.OnSubordinateDeath;

            //dobavqme metoda na 'podchineniq' v eventa na tozi 'King'
            this.GetAttackedEvent += subordinate.ReactToAttack;
        }

        public void OnSubordinateDeath(object sender)
        {
            //Mahame sendera koito e samiq murtav podchinen
            this.subordinates.Remove((ISubordinate)sender);
        }

    }
}
