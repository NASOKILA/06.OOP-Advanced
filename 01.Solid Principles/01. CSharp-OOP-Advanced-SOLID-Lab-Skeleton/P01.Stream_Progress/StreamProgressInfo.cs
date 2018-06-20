using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreamProgress file;

        // If we want to stream a music file, we can't   
        
        // POLZVAME INTERFEIS SUS OBSHTOTO MEJDU Music I File !!!!!!!!!!!!!!!!

        public StreamProgressInfo(IStreamProgress file)
        {
            this.file = file;
        }

        //Tuk polzvame samo bytesSent i Length  OBACHE NE MOJEHME DA POLZVAME MUSIC ZATOVA SI NAPRAVIHME OBSHT INTERFEIS    
        public int CalculateCurrentPercent()
        {
            return (this.file.BytesSent * 100) / this.file.Length;
        }
    }
}
