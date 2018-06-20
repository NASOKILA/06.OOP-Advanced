using System.Collections.Generic;
using System.Text;


public class SpecialForce : Soldier

{
    //ZA DA SERNEM KAKVOTO I DA E PURVO GO IZVEJDAME V PRIVATE POLE
    private const double overallSkillMultiplier = 3.5;
    private const int regenerationParameter = 30;
    private readonly List<string> weaponsAllowed = new List<string>(){
            "Gun",
            "AutomaticMachine",
            "MachineGun",
            "RPG",
            "Helmet",
            "Knife",
            "NightVision"
    };    

    public SpecialForce(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    { }

    protected override List<string> WeaponsAllowed => weaponsAllowed;

    protected override double OverallSkillMultiplier => overallSkillMultiplier;
    
    protected override int RegenerationParameter => regenerationParameter;
}
