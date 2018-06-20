using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class GameController
{
    private IArmy army;
    private IWareHouse wearHouse;
    private MissionController missionController;
    private ISoldierFactory soldierFactory;
    private IAmmunitionFactory ammunitionFactory;
    private IMissionFactory missionFactory;
    private IConsoleWriter writer;
    
    public GameController(IConsoleWriter writer)
    {
        this.army = new Army();
        this.wearHouse = new WareHouse();
        this.missionController = new MissionController(this.army, this.wearHouse);
        
        this.soldierFactory = new SoldierFactory();
        this.ammunitionFactory = new AmmunitionFactory();
        this.missionFactory = new MissionFactory();
        this.writer = writer;
    }
    
    //tuk izpulnqvame komandite
    public void GiveInputToGameController(string input)
    {
        var data = input.Split();

        //ako komandata ni e soldier
        if (data[0].Equals("Soldier"))
        {

            // i sled nego imame Regenerate znachi gi regenerirame vsichki voinici
            if (data[1].Equals("Regenerate"))
            {
                army.RegenerateTeam(data[2]);
            }
            else
            {
                //ako NE E REGENERATA ZNACHISUZDVAME NOV VOINIK

                var soldier = soldierFactory.CreateSoldier(
                    data[1], data[2], int.Parse(data[3]), double.Parse(data[4]), double.Parse(data[5]));
                //type, name, age, experience, endurance

                if (wearHouse.TryEquipSoldier(soldier))
                    army.AddSoldier(soldier);
                else
                {
                    throw new ArgumentException(
                        string.Format(OutputMessages.SoldierCannotBeEquipped, data[1], data[2]));
                }
            }
        }
        else if (data[0].Equals("WareHouse"))
        {
            string name = data[1];
            int number = int.Parse(data[2]);
            
            this.wearHouse.AddAmmunition(name, number); 
        }
        else if (data[0].Equals("Mission"))
        {
            string type = data[1];
            double scoreToComplete = double.Parse(data[2]);

            var mission = this.missionFactory.CreateMission(type, scoreToComplete);

            this.writer.AppendLine(missionController.PerformMission(mission).Trim());
        }
    }

    public void RequestResult()
    {
        //Sega vsichki OnHold Missiq stavat na Fail Misii
        missionController.FailMissionsOnHold();
        writer.AppendLine(OutputMessages.Result);

        //zakavhame uspeshnite misii
        writer.AppendLine(string.Format(OutputMessages.SuccessfulMissions, missionController.SuccessMissionCounter));

        //zakavhame NE uspeshnite misii
        writer.AppendLine(string.Format(OutputMessages.FailedMissions, missionController.FailedMissionCounter));
        writer.AppendLine(OutputMessages.Soldiers);

        //zakachame i voinicite podredeni po Overall Skill
        foreach (var soldier in this.army.Soldiers.OrderByDescending(s => s.OverallSkill))
            writer.AppendLine(soldier.ToString());
    }    
}
