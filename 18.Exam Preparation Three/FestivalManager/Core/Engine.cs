
using System;
using System.Linq;
namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
	using IO.Contracts;
    
	class Engine : IEngine
	{
	    public IReader reader;
	    public IWriter writer;

        public IFestivalController festivalCоntroller; 
        public ISetController setCоntroller;


        public Engine(IReader reader, IWriter writer, IFestivalController festivalCоntroller, ISetController setCоntroller)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalCоntroller = festivalCоntroller;
            this.setCоntroller = setCоntroller;
        }
        
		public void Run()
		{
			while (true) // for job security
			{
				var input = reader.ReadLine();

				if (input == "END")
					break;

				try
				{
					string.Intern(input);

					var result = this.ProcessCommand(input);
					this.writer.WriteLine(result);
				}
				catch (Exception ex) // in case we run out of memory
				{
					this.writer.WriteLine("ERROR: " + ex.Message);
				}
			}

			var end = this.festivalCоntroller.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(end);
		}

		public string ProcessCommand(string input)
		{
			var tokens = input.Split(" ".ToCharArray().First());

			var command = tokens.First();
			var args = tokens.Skip(1).ToArray();

            if (command == "LetsRock")
            {
                var sets = this.setCоntroller.PerformSets();
                return sets;
            }
            

            var festivalcontrolfunction = this.festivalCоntroller.GetType()
				.GetMethods()
				.FirstOrDefault(x => x.Name == command);

			string result;

			try
			{
				result = (string)festivalcontrolfunction.Invoke(this.festivalCоntroller, new object[] { args });
			}
			catch (Exception e)
			{
                result = "ERROR: " + e.InnerException.Message;
			}

			return result;
		}
        
    }
}