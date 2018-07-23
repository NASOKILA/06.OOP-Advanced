using System;

namespace Object_Communication_and_Events_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            CombatLogger logger = new CombatLogger();

            IHandler handler = new Handler();
            logger.SetSuccessor(handler);
            logger.Handle(LogType.ATTACK, "Hello");
             
            Logger combatLog = new CombatLogger();
            Logger eventLog = new EventLogger();

            combatLog.SetSuccessor(eventLog);
            var warrior = new Warrior("gosho", 100, combatLog);
            var dragon = new Dragon("Peter", 100, 25, combatLog);

            warrior.SetTarget(dragon);
            dragon.Register(warrior);

            warrior.Attack();

            IExecutor executor = new CommandExecutor();
            ICommand command = new TargetCommand(warrior, dragon);
            ICommand attack = new AttackCommand(warrior);
        }
    }
}