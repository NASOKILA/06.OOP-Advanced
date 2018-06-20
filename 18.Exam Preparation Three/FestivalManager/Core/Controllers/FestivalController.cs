namespace FestivalManager.Core.Controllers
{
	using System;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using Contracts;
	using Entities.Contracts;
    using FestivalManager.Entities.Factories.Contracts;
    using System.Collections.Generic;

    public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";
		private const string TimeFormatLong = "{0:2D}:{1:2D}";
		private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

		private readonly IStage stage;
		private ISetFactory setFactory;
		private IInstrumentFactory instrumentFactory;
		private IPerformerFactory performerFactory;
		private ISongFactory songFactory;

        public FestivalController(IStage stage, 
            ISetFactory setFactory, 
            IInstrumentFactory instrumentFactory, 
            IPerformerFactory performerFactory,
            ISongFactory songFactory)
		{
			this.stage = stage;
            this.setFactory = setFactory;
            this.instrumentFactory = instrumentFactory;
            this.performerFactory = performerFactory;
            this.songFactory = songFactory;
        }

		public string ProduceReport()
		{
			var result = string.Empty;

			var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

			result += ($"Festival length: {FormatTime(totalFestivalLength)}") + "\n";

			foreach (var set in this.stage.Sets)
			{
				result += ($"--{set.Name} ({FormatTime(set.ActualDuration)}):") + "\n";

				var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
				foreach (var performer in performersOrderedDescendingByAge)
				{
					var instruments = string.Join(", ", performer.Instruments
						.OrderByDescending(i => i.Wear));

					result += ($"---{performer.Name} ({instruments})") + "\n";
				}

				if (!set.Songs.Any())
					result += ("--No songs played") + "\n";
				else
				{
					result += ("--Songs played:") + "\n";
					foreach (var song in set.Songs)
					{
						result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
					}
				}
			}

			return result.ToString();
		}

        private string FormatTime(TimeSpan actualDuration)
        {
            
            string result = actualDuration.ToString(TimeFormat);

            if (actualDuration.Hours > 0)
            {

                string totalMinutes =
                    actualDuration.TotalMinutes.ToString() + ':' +
                    actualDuration.Seconds.ToString("d2");
                return totalMinutes;
            }
            
            return result;
        }

        public string RegisterSet(string[] args)
		{
            string name = args[0];
            string type = args[1];
            ISet set = this.setFactory.CreateSet(name, type);

            this.stage.AddSet(set);

            return string.Format(Messages.SetRegistered, type);
		}

		public string SignUpPerformer(string[] args)
		{
			var name = args[0];
			var age = int.Parse(args[1]);

			var instruments = args.Skip(2).ToArray();

			var instrumentsCreated = instruments
				.Select(i => this.instrumentFactory.CreateInstrument(i))
				.ToArray();

			IPerformer performer = this.performerFactory.CreatePerformer(name, age);

			foreach (var instrument in instrumentsCreated)
			{
				performer.AddInstrument(instrument);
			}

			this.stage.AddPerformer(performer);
            
            return string.Format(Messages.PerformerRegistered, name);
		}

		public string RegisterSong(string[] args)
		{
            string name = args[0];
            string time = args[1];

            List<string> tokens = time.Split(':').ToList();
            int minutes = int.Parse(tokens.First());
            int seconds = int.Parse(tokens.Last());

            TimeSpan duration = new TimeSpan(0,minutes, seconds);

            ISong song = this.songFactory.CreateSong(name, duration);

            this.stage.AddSong(song);

            var format = string.Format("{0:00}:{1:00}", song.Duration.Minutes, song.Duration.Seconds);
            
            return $"Registered song {name} ({format})";
		}

		public string AddSongToSet(string[] args)
		{
			var songName = args[0];
			var setName = args[1];

			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException("Invalid set provided");
			}

			if (!this.stage.HasSong(songName))
			{
				throw new InvalidOperationException("Invalid song provided");
			}

			var set = this.stage.GetSet(setName);
			var song = this.stage.GetSong(songName);

			set.AddSong(song);

            var format = string.Format("{0:00}:{1:00}", song.Duration.Minutes, song.Duration.Seconds);

            return $"Added {song.Name} ({format}) to {set.Name}";
		}
        
		public string AddPerformerToSet(string[] args)
		{
            string performerName = args[0];

            string setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            IPerformer performer = this.stage.GetPerformer(performerName);
            ISet set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return $"Added {performerName} to {setName}";
		}
        
		public string RepairInstruments(string[] args)
		{
			var instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear < 100)
				.ToArray();

			foreach (var instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

			return $"Repaired {instrumentsToRepair.Length} instruments";
		}
        
    }
}