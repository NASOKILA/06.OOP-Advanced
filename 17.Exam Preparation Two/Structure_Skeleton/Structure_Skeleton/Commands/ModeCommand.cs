
using System.Collections.Generic;

public class ModeCommand : Command
{
    private IHarvesterController harvesterController;

    public ModeCommand(IList<string> args, IHarvesterController harvesterController) 
        : base(args)
    {
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        string mode = this.Arguments[0];
        return this.harvesterController.ChangeMode(mode);
    }
}

