namespace FestivalManager
{
	using System.IO;
	using System.Linq;
	using Core;
	using Core.Contracts;
	using Core.Controllers;
	using Core.Controllers.Contracts;
	using Core.IO;
	using Core.IO.Contracts;
	using Entities;
	using Entities.Contracts;
    using FestivalManager.Entities.Factories.Contracts;
    using FestivalManager.Entities.Factories;

    public static class StartUp
	{
		public static void Main(string[] args)
		{
			IStage stage = new Stage();
            ISetFactory setFactory = new SetFactory();
            IInstrumentFactory instrumentFactory = new InstrumentFactory();
            ISongFactory songFactory = new SongFactory();
            IPerformerFactory performerFactory= new PerformerFactory();

            IReader reader = new Reader();
            IWriter writer = new Writer();

            IFestivalController festivalController = new FestivalController(stage, setFactory, instrumentFactory, performerFactory, songFactory);
			ISetController setController = new SetController(stage);

			var engine = new Engine(reader, writer, festivalController, setController);

			engine.Run();
		}
	}
}