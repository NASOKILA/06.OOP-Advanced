using _03BarracksFactory.Contracts;
using P03_BarraksWars.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace P03_BarraksWars.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        
        private IServiceProvider serviceProvider;
        
        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }


        public IExecutable InterpretCommand(string[] data, string commandName)
        {

            //vzimame si proekta koito se izpulnqva
            Assembly assembly = Assembly.GetCallingAssembly();

            //vzimame si pravilniq tip na comandata
            Type commandType = assembly.GetTypes()
                .FirstOrDefault(c => c.Name.ToLower() == commandName + "command");

            //ako tipa na komandata e 'null' vhurlqme greshka
            if (commandType == null)
                throw new ArgumentException("Invalid Command");

            //ako ne implementira interfeisa vhurlqme greshka
            if (!typeof(IExecutable).IsAssignableFrom(commandType))
                throw new ArgumentException($"{commandName} is not a Command ");
            
            //vzimame konstruktura i suzdavame obekt
            var constructor = commandType.GetConstructor(
                new[] { typeof(string[]), typeof(IRepository), typeof(IUnitFactory) });

            FieldInfo[] fieldsToInject = commandType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute))).ToArray();


            //za vsqko pole ot nashiq konteiner vzimame ot servisa
            object[] injectArgs = fieldsToInject
                .Select(f => this.serviceProvider.GetService(f.FieldType)).ToArray(); 

            //Pravim si instanciq
            object[] args = new object[] { data }.Concat(injectArgs).ToArray();
            
            IExecutable instance = (IExecutable)constructor.Invoke(args);

            //vrushtame instanciqta
            return instance;
        }

        
    }
}