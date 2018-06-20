namespace P02_KingsGambit.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IMortal
    {
        bool IsAlive { get; }

        void TakeDamage();

        void Die();
    }
}

