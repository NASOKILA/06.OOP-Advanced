    
using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{

    public IAmmunition CreateAmmunition(string name)
    {
        //vzimame si ot proekta tipa na klasa
        var type = Assembly.GetCallingAssembly().GetTypes().Single(t => t.Name == name);

        //i suzdavame instanciq ot nego koqto vrushtame
        return (IAmmunition)Activator.CreateInstance(type);   
    }
    
}
