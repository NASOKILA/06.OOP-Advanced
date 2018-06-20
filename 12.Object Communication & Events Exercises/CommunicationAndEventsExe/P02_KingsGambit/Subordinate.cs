namespace P02_KingsGambit
{
    using P02_KingsGambit.Interfaces;
    using System;

    public abstract class Subordinate : ISubordinate
    {
        public event SubordinatedEventHandler DeathSubordinate;

        protected Subordinate(string name, string action)
        {
            this.Name = name;
            this.Action = action;
            this.IsAlive = true;
        }

        public string Name { get; }

        public bool IsAlive { get; private set; }

        public string Action { get; }

        public int Hits { get; protected set; }
        
        public void TakeDamage()
        {
            this.Hits--;

            if (this.Hits == 0)
                this.Die();    
            
            
        }

        public void Die()
        {
            this.IsAlive = false;

            if (this.DeathSubordinate != null)
            {
                //izvikvame go sus this za da se znae che tozi podchinen e umrql
                DeathSubordinate.Invoke(this);
            }
        }


        //pravim go virtual
        public virtual void ReactToAttack()
        {
            if(IsAlive)
                Console.WriteLine($"{this.GetType().Name} {this.Name} is {this.Action}!");    
        }
        
    }
}
