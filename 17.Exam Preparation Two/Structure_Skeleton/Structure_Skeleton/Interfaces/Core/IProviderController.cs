using System.Collections.Generic;

public interface IProviderController : IController
{
    double TotalEnergyProduced { get; }

    IList<IProvider> Entities { get; }

    string Repair(double val);
}