using System;
using System.Collections.Generic;
using System.Text;

public interface IWeapon
{
    //Axe interface   
    int AttackPoints { get; }

    int DurabilityPoints { get; }

    void Attack(ITarget target);
}

