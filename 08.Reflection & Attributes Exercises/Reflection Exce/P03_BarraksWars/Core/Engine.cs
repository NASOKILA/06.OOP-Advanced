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

        //V ENGINA NE TRQBVA DA IMAME MNOGO DUMICHKAtA 'new'.
        //DOBRA PRAKTIKA E DRUGI KLASOVE DA NI SUZDAVAT INSTANCIITE KOITO SHTE NI TRQBVAT.

        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            //POLZVAME SAMO COMMAND INTERPRETATORA, TRIEM DRUGITE PRIVATE POLETA ZASHTOTO SEGA SE 
            //SUDURJAT VUTRE V NEGO.
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

                    //PURVO NAMIRAME KOMANDATA 
                    //veche vrushta IExcecutable
                    IExecutable command = commandInterpreter
                        .InterpretCommand(data, commandName);
                    
                    //POSLE Q POLZVAME 
                    try
                    {

                        //vzimame metoda s REFLECTION i go invokvame S REFLECTION
                        MethodInfo method = typeof(IExecutable).GetMethods().First();

                        //kato go invoknem ni vrushta string, KASTVAME GO
                        string result = (string)method.Invoke(command, null);

                        Console.WriteLine(result);

                    }
                    catch (TargetInvocationException e)
                    {
                        //hvurlqme vutreshnata greshka
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
