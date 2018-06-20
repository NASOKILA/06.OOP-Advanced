using System;
using System.Collections.Generic;
using System.Text;

public class Group : IAttackGroup
{
    private List<IAttacker> attackers;

    public void AddMember(IAttacker attacker)
    {
        this.attackers.Add(attacker);
    }

    public Group() { this.attackers = new List<IAttacker>(); }
    
    public void GroupAttack()
    {
        foreach (var attacker in attackers)
        {
            attacker.Attack();
        }
    }

    public void GroupTarget(ITarget target)
    {
        throw new NotImplementedException();
    }

    public void GroupTargetAndAttack(ITarget target)
    {
        throw new NotImplementedException();
    }


}
