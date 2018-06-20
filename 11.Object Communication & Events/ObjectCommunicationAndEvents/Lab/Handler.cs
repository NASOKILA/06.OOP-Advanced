using System;
using System.Collections.Generic;
using System.Text;


public class Handler : IHandler
{
    public void Handle(LogType type, string message)
    {
        Console.WriteLine($"{type} {message} handled!");
    }

    public void SetSuccessor(IHandler handler)
    {
        throw new NotImplementedException();
    }
}

