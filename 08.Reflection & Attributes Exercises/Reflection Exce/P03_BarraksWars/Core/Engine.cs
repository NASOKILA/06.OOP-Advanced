namespace _03BarracksFactory.Core
{
    using System;
    using Contracts;
    using P03_BarraksWars.Core.Commands;
    using System.Reflection;
    using System.Linq;
    using P03_BarraksWars.Core;

    class Engine : IRunnable
    {

        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];

                    IExecutable command = commandInterpreter
                        .InterpretCommand(data, commandName);
                    
                    try
                    {
                        MethodInfo method = typeof(IExecutable).GetMethods().First();

                        string result = (string)method.Invoke(command, null);

                        Console.WriteLine(result);
                    }
                    catch (TargetInvocationException e)
                    {
                        throw e.InnerException;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }  
    }
}