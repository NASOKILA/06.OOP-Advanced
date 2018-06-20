namespace FestivalManager.Entities
{
	using System.Collections.Generic;
	using Contracts;
    using System.Linq;

    public class Stage : IStage
	{
		// да си вкарват през полетата бе
		public readonly List<ISet> sets;
		public readonly List<ISong> songs;
		public readonly List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => sets;

        public IReadOnlyCollection<ISong> Songs => songs;

        public IReadOnlyCollection<IPerformer> Performers => performers;

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSet(ISet set)
        {
            this.sets.Add(set);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            IPerformer performer = this.performers.FirstOrDefault(p => p.Name == name);
            return performer;
        }

        public ISet GetSet(string name)
        {
            ISet set = this.sets.FirstOrDefault(s => s.Name == name);
            return set;
        }

        public ISong GetSong(string name)
        {
            ISong song = this.songs.FirstOrDefault(s => s.Name == name);
            return song;
        }

        public bool HasPerformer(string name)
        {
            return this.performers.Any(p => p.Name == name);
        }

        public bool HasSet(string name)
        {
            return this.sets.Any(s => s.Name == name);
        }

        public bool HasSong(string name)
        {
            bool result = this.songs.Any(s => s.Name == name);
            return result;
        }
    }
}
