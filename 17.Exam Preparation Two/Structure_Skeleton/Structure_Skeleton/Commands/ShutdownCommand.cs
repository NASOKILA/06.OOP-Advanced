
using System.Collections.Generic;
using System.Text;

public class ShutdownCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public ShutdownCommand(IList<string> args, IHarvesterController harvesterController, IProviderController providerController)
        : base(args)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {

        var sb = new StringBuilder();
        sb.AppendLine(OutputMessages.ShutDown);
        sb.AppendLine(string.Format(OutputMessages.TotalEnergyProduced, this.providerController.TotalEnergyProduced));
        sb.Append(string.Format(OutputMessages.TotalOreMined, harvesterController.OreProduced));

        return sb.ToString();
    }
}

