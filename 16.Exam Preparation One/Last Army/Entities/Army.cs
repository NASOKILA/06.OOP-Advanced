using System.Collections.Generic;
using System.Linq;

public class Army : IArmy
{
    private List<ISoldier> soldiers;
       
    public IReadOnlyList<ISoldier> Soldiers => soldiers;

    public Army()
    {
        this.soldiers = new List<ISoldier>();
    }
    
    public void AddSoldier(ISoldier soldier)
    {    
        if(!this.soldiers.Contains(soldier))
            this.soldiers.Add(soldier);
    }

    public void RegenerateTeam(string soldierType)
    {
        foreach (Soldier soldier in this.Soldiers.Where(s => s.GetType().Name == soldierType))
            soldier.Regenerate();   
    }
}