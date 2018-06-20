using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{

    private const int maxEndurance = 100;

    protected Soldier(string name,
        int age,
        double experience,
        double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;


        this.Weapons = new Dictionary<string, IAmmunition>();
        //Trqbva da go napulnim
        foreach (var weapon in WeaponsAllowed)
            Weapons.Add(weapon, null);
    }

    public string Name { get; }

    public int Age { get; }

    public double Experience { get; private set; }

    private double endurance;

    public double Endurance
    {
        get { return endurance; }
        private set
        {
            //ne moje endurance da e nad 100 za tova go pravim da e sus setter
            //koito da vzima minimalnoto mejdu 100 i podadenata stoinsot
            endurance = Math.Min(value, maxEndurance);
        }
    }


    //vseki voinik si go ima tova zatova go pravim da moje da se prezpisva
    protected abstract double OverallSkillMultiplier { get; }

    public double OverallSkill => (Age + Experience) * OverallSkillMultiplier;
    
    //vseki voinik si ima pozvoleni orujiq
    protected abstract List<string> WeaponsAllowed { get; }

    public IDictionary<string, IAmmunition> Weapons { get; }


    //Pravim go virtual i go setvame da e 10 po default 
    //shte go promenim sa mo za SpecialSoldier kudeto trqbva da e 30
    protected virtual int RegenerationParameter => 10;

    public void Regenerate()
    {
        this.Endurance += (RegenerationParameter + this.Age);
    }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        //broim tezi koito sa razlichni ot null
        bool hasAllEquipment = this.Weapons.Values.All(weapon => weapon == null);

        if (!hasAllEquipment)
        {
            return false;
        }

        //trqbva wearLevel da im e nad 0 PO USLOVIE, tova proverqvame tuka, ako ne e taka vrushta false
        return this.Weapons.Values.All(weapon => weapon.WearLevel > 0);
    }

    public void CompleteMission(IMission mission)
    {

        //uvelichava experienca i namalqva enduransa sus endurance required ot misiqta
        this.Experience += mission.EnduranceRequired;
        this.Endurance -= mission.EnduranceRequired;

        //I na vsqko orujie se namalqva wearLevel s tova na misiqta
        foreach (var weapon in Weapons.Values.Where(w => w != null).ToList())  //vzimame tezi na koito stoinostta im e razlichna ot null
        {
            weapon.DecreaseWearLevel(mission.WearLevelDecrement);

            //Ako WearLevel e <= 0 znachi go setvame na null vse edno nikoga ne go e imalo 
            if (weapon.WearLevel <= 0)
                Weapons[weapon.Name] = null;
        }

    }
 
    //Proverqva dali amuniciite stawat za misiqta, ako ne stawat gi setva na null
    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> keys = this.Weapons.Keys.ToList();
        foreach (string weaponName in keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    //prezapisvame si ToString kato go formatirame polzvaiki OutputMessages klasa
    //NA SoldierToString koeto e = "{0} => {1}" mu podavame Imeto i OverallSkill
    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
    
}