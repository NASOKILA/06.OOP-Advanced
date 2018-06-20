
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class InspectCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public InspectCommand(
        IList<string> args, 
        IHarvesterController harvesterController, 
        IProviderController providerController)
        : base(args)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        string id = this.Arguments[0];
        var sb = new StringBuilder();
        if (this.providerController.Entities.Any(p => p.ID.ToString() == id))
        {
            IProvider provider = this.providerController.Entities.FirstOrDefault(p => p.ID.ToString() == id);
            sb.AppendLine(provider.ToString());
        }
        if (this.harvesterController.Entities.Any(h => h.ID.ToString() == id))
        {
            IHarvester harvester = this.harvesterController.Entities.FirstOrDefault(h => h.ID.ToString() == id);
            sb.AppendLine(harvester.ToString());
        }
        if (string.IsNullOrWhiteSpace(sb.ToString()))
        {
            sb.AppendLine(string.Format(OutputMessages.NoElementFound, id));
        }

        return sb.ToString().Trim();
    }
}

