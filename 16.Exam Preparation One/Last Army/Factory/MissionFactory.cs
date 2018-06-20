
using System;
using System.Linq;
using System.Reflection;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        //DificultyLevel e Easy, Medium ili Hard

        //vzimame si ot proekta tipa na klasa koito trqbva da napravim
        var type = Assembly.GetCallingAssembly()
            .GetTypes()
            .Single(t => t.Name == difficultyLevel);

        //i suzdavame instanciq ot nego koqto vrushtame KATO MU PODAVAME PARAMETRITE SLED type
        //Activator-a vrusta obekt zatova go kastvame za da ni vurne IMission
        return (IMission)Activator.CreateInstance(type, neededPoints);
    }
}

