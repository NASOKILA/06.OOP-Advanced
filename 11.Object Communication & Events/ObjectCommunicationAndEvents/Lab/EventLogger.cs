using System;

namespace Object_Communication_and_Events_Lab
{
    public class EventLogger : Logger
    {
        public override void Handle(LogType type, string message)
        {

            switch (type)
            {
                case LogType.ATTACK:
                Console.WriteLine(type.ToString() + ": " + message);
                    break;
                case LogType.MAGIC:
                Console.WriteLine(type.ToString() + ": " + message);
                    break;
                case LogType.TARGET:
                Console.WriteLine(type.ToString() + ": " + message);
                    break;
                case LogType.ERROR:
                Console.WriteLine(type.ToString() + ": " + message);
                    break;
                case LogType.EVENT:
                Console.WriteLine(type.ToString() + ": " + message);
                    break;
            }

            this.PassToSuccessor(type, message);
        }
    }
}