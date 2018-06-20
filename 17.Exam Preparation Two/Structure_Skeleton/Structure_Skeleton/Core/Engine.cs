using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{

    private ICommandInterpreter commandInterpreter;
    private IWriter writer;
    private IReader reader;
    
    public Engine(IWriter writer, IReader reader, ICommandInterpreter commandInterpreter)
    {    
        this.commandInterpreter = commandInterpreter;
        this.writer = writer;
        this.reader = reader; 
    }
    
    public void Run()
    {
        while (true)
        {
            List<string> data = reader.ReadLine().Split().ToList();
            
            string line = this.commandInterpreter.ProcessCommand(data);

            writer.WriteLine(line);

            if (data[0] == Commands.ShutDownCommand)
                Environment.Exit(0);

        }
    }
}
