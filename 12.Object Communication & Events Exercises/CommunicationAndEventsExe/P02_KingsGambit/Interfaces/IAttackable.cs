namespace P02_KingsGambit.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    //pravim si delegata
    public delegate void GetAttackedEventHandler();

    public interface IAttackable
    {
        //i eventa koito vseki kral she ima zashtoto samo kralete sa IAttackable
        event GetAttackedEventHandler GetAttackedEvent;

        void GetAttacked();
    }
}
