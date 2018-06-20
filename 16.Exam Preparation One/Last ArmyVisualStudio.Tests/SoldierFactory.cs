
using System;
using System.Linq;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, 
        string name, 
        int age, 
        double experience, 
        double endurance)
    {
        //vzimame si ot proekta tipa na klasa koito trqbva da napravim
        var type = Assembly.GetCallingAssembly()
            .GetTypes()
            .Single(t => t.Name == soldierTypeName);
        
        //i suzdavame instanciq ot nego koqto vrushtame KATO MU PODAVAME PARAMETRITE SLED type
        return (ISoldier)Activator.CreateInstance(type, name, age, experience, endurance);
    }
}



