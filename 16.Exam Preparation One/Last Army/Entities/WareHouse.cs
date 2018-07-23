
using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private Dictionary<string, int> ammunitionsQuantity;

    private IAmmunitionFactory ammunitionFactory;

    public WareHouse()
    {
        this.ammunitionFactory = new AmmunitionFactory();
        this.ammunitionsQuantity = new Dictionary<string, int>();
    }

    public void EquipArmy(IArmy army)
    {
        foreach (Soldier soldier in army.Soldiers)
        {
            this.TryEquipSoldier(soldier);
        }
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        List<string> wornOutWeapons = soldier.Weapons
            .Where(w => w.Value == null || w.Value.WearLevel <= 0)
            .Select(w => w.Key).ToList();

        bool isSoldierEquipped = true;

        foreach (var weapon in wornOutWeapons)
        {
            if (this.ammunitionsQuantity.ContainsKey(weapon)
                && ammunitionsQuantity[weapon] > 0)
            {
                soldier.Weapons[weapon] = ammunitionFactory.CreateAmmunition(weapon);
                ammunitionsQuantity[weapon]--;
            }
            else
            {
                isSoldierEquipped = false;
            }
        }

        return isSoldierEquipped;
    }

    public void AddAmmunition(string ammunition, int quantity)
    {
		if (!ammunitionsQuantity.ContainsKey(ammunition))
        {
            ammunitionsQuantity[ammunition] = quantity;
        }
        else
        {
            ammunitionsQuantity[ammunition] += quantity;
        }  
    }
}