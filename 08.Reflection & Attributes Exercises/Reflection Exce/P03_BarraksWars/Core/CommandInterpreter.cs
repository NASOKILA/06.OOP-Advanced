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
            Assembly assembly = Assembly.GetCallingAssembly();

            Type commandType = assembly.GetTypes()
                .FirstOrDefault(c => c.Name.ToLower() == commandName + "command");

            if (commandType == null)
                throw new ArgumentException("Invalid Command");

            if (!typeof(IExecutable).IsAssignableFrom(commandType))
                throw new ArgumentException($"{commandName} is not a Command ");
            
            var constructor = commandType.GetConstructor(
                new[] { typeof(string[]), typeof(IRepository), typeof(IUnitFactory) });

            FieldInfo[] fieldsToInject = commandType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute))).ToArray();

            object[] injectArgs = fieldsToInject
                .Select(f => this.serviceProvider.GetService(f.FieldType)).ToArray(); 

            object[] args = new object[] { data }.Concat(injectArgs).ToArray();
            
            IExecutable instance = (IExecutable)constructor.Invoke(args);

            return instance;
        }     
    }
}