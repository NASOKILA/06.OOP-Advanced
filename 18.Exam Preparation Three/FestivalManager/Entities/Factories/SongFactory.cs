namespace FestivalManager.Entities.Factories
{
	using System;
	using Contracts;
	using Entities.Contracts;
    using System.Reflection;
    using System.Linq;

    public class SongFactory : ISongFactory
	{
		public ISong CreateSong(string name, TimeSpan duration)
		{
			
            Type @class = Assembly.GetCallingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name == "Song");

            ISong song = (ISong)Activator.CreateInstance(@class, name, duration) as ISong;

            return song;

        }
	}
}