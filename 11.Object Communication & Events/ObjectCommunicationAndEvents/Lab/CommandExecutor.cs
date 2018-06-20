using System;
using System.Collections.Generic;
using System.Text;


public class CommandExecutor : IExecutor
{
    public void ExecuteCommand(Command command)
    {
        command.Execute();
    }
}

