using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class HarvesterFactory : IHarvesterFactory
{

    public IHarvester GenerateHarvester(IList<string> args)
    {
        string type = args[0];
        var id = int.Parse(args[1]);
        var oreOutput = double.Parse(args[2]);
        var energyReq = double.Parse(args[3]);

        Type @class = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type + "Harvester");
        IHarvester harvester = (IHarvester)Activator.CreateInstance(@class, id, oreOutput, energyReq);
        return harvester;
    }
}

