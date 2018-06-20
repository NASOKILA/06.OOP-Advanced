using System;
using System.Collections.Generic;
using System.Text;


public class GroupTargetCommand : ICommand
{
    private IAttackGroup attacker;
    private ITarget target;

    public GroupTargetCommand(IAttackGroup attacker, ITarget target)
    {
        this.attacker = attacker;
        this.target = target;
    }

    public void Execute()
    {
        throw new NotImplementedException();
    }
}

