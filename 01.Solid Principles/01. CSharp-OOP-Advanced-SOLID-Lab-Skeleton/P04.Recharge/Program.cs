namespace P04.Recharge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            IRechargeable robot = new Robot("1", 100);
			
            ISleeper employee = new Employee("1");
            
            ChargingStation cs = new ChargingStation(robot); 
        }
    }
}