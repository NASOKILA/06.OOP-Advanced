
using System;
using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public RegisterCommand(IList<string> args, IHarvesterController harvesterController, IProviderController providerController)
        : base(args)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {

        string command = "Register" + Arguments[0];
        string result = "";
        if (command == Commands.RegisterHarvesterCommand)
        {
            IList<string> tokens = Arguments.Skip(1).ToList();
            result = this.harvesterController.Register(tokens);
        }
        else if (command == Commands.RegisterProviderCommand)
        {

            IList<string> tokens = Arguments.Skip(1).ToList();
            result = this.providerController.Register(tokens);

        }

        return result;
    }
    
}

