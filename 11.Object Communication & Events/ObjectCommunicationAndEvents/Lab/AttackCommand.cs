using System;
using System.Collections.Generic;
using System.Text;


public class AttackCommand : ICommand
{
    private IAttacker attacker;

    public AttackCommand(IAttacker attacker)
    {
        this.attacker = attacker;
    }

    public void Execute()
    {
        throw new NotImplementedException();
    }
}

