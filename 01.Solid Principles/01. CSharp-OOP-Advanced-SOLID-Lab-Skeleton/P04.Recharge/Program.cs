namespace P04.Recharge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {

            //mojem da katnem robot kum Irechargable
            IRechargeable robot = new Robot("1", 100);

            //mojem da katnem employee kum ISleeper
            ISleeper employee = new Employee("1");
            
            //Moga da mu podam robot no ne i employee zashtotot ne e rechargable
            ChargingStation cs = new ChargingStation(robot);  //employee



        }
    }
}
