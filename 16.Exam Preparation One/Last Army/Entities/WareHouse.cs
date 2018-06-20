
using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{

    //suzdavame si spisuk s amonicii i go setvame v konstruktura
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

    //suzdavame si metod koito da gi equippva
    public bool TryEquipSoldier(ISoldier soldier)
    {

        //vzimame tezi koito sa izrazhodvani
        List<string> wornOutWeapons = soldier.Weapons
            .Where(w => w.Value == null || w.Value.WearLevel <= 0)
            .Select(w => w.Key).ToList();

        bool isSoldierEquipped = true;

        foreach (var weapon in wornOutWeapons)
        {

            //ako go imame tova urujie i kolichestvoto mu > 0 go davame na nashiq voinik
            if (this.ammunitionsQuantity.ContainsKey(weapon)
                && ammunitionsQuantity[weapon] > 0)
            {
                //direktno mu go suzdavame
                soldier.Weapons[weapon] = ammunitionFactory.CreateAmmunition(weapon);

                //i go magame ot nashiq spisuk
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

        //Ako q nqmame tazi amuniciq si q dobavqme sus quantitito
        if (!ammunitionsQuantity.ContainsKey(ammunition))
        {
            ammunitionsQuantity[ammunition] = quantity;
        }
        else
        {
            //ako veche go imame tova orujie znachi samo si mu dobavqme quantity
            ammunitionsQuantity[ammunition] += quantity;
        }
        
    }
    
}

