using System.Collections.Generic;

public interface IHarvesterController : IController
{
    double OreProduced { get; }

    IList<IHarvester> Entities { get; }
    
    string ChangeMode(string mode);
}