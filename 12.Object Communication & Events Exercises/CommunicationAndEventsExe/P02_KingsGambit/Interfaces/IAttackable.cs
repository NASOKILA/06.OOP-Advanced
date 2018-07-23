namespace P02_KingsGambit.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public delegate void GetAttackedEventHandler();

    public interface IAttackable
    {
        event GetAttackedEventHandler GetAttackedEvent;

        void GetAttacked();
    }
}
