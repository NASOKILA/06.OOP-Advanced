using System.Collections.Generic;
using System.Linq;

public class Army : IArmy
{

    //Tui kato ne moje mda dobavqme v IReadOnlyList si pravim private List<> koito shte pulnim
    private List<ISoldier> soldiers;

        //setvame ednoto da e ravno na drugoto
    public IReadOnlyList<ISoldier> Soldiers => soldiers;

    public Army()
    {
        this.soldiers = new List<ISoldier>();
    }
    
    public void AddSoldier(ISoldier soldier)
    {
        //pulnim si List<> soldiers  ,  a new direktno IReadOnlyList<> Soldiers
        
        if(!this.soldiers.Contains(soldier))
            this.soldiers.Add(soldier);
    }

    public void RegenerateTeam(string soldierType)
    {
        //regenerirame asmo tezi koito sa sus podadeniq tip
        foreach (Soldier soldier in this.Soldiers.Where(s => s.GetType().Name == soldierType))
            soldier.Regenerate();   
    }

}

