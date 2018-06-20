using System;
using System.Collections.Generic;

public class Ranker : Soldier
{
    private const double overallSkillMultiplier = 1.5;

    private List<string> weaponsAllowed = new List<string>()
    {
        "Gun",
        "AutomaticMachine",
        "Helmet"
    };

    public Ranker(string name, int age, double experience, double endurance) 
        : base(name, age, experience, endurance)
    {}

    protected override double OverallSkillMultiplier => overallSkillMultiplier;

    //po default e 10 i nqma nujda da go prezapisvam
    //protected override int RegenerationParameter => base.RegenerationParameter;

    protected override List<string> WeaponsAllowed => weaponsAllowed;

}

