namespace P04.Recharge
{
    using System;

    public class Employee : Worker, ISleeper
    {
        public Employee(string id) : base(id)
        {
        }

        public override void Work(int hours)
        {
            base.Work(hours);
        }

        public void Sleep()
        {
            //employee is sleeping ...
        }
    }
}
