
// we might want to read from files idk lol ¯\_(ツ)_/¯
namespace FestivalManager.Core.IO
{
    using FestivalManager.Core.IO.Contracts;
    using System.IO;
    using System;

    public class Reader : IReader
	{
        public string ReadLine()
        {
            string result = Console.ReadLine();
            return result;
        }
        
	}
}