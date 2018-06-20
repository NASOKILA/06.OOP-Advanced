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
/*
            Logger combatLog = new CombatLogger();
            Logger eventLog = new EventLogger();

            combatLog.SetSuccessor(eventLog);

            var warrior = new Warrior("Torsten", 10, combatLog);
            var warrior2 = new Warrior("Rolo", 15, combatLog);

            IAttackGroup group = new Group();
            group.AddMember(warrior);
            group.AddMember(warrior2);

            ITarget dragon = new Dragon("Transilvanian White", 200, 25, combatLog);
            
            IExecutor executor = new CommandExecutor();


            ICommand groupTarget = new GroupTargetCommand(group, dragon);
            ICommand groupAttack = new GroupAttackCommand(group);
            */
        }
    }
}
