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
    
    public void GiveInputToGameController(string input)
    {
        var data = input.Split();

        if (data[0].Equals("Soldier"))
        {

            if (data[1].Equals("Regenerate"))
            {
                army.RegenerateTeam(data[2]);
            }
            else
            {
                var soldier = soldierFactory.CreateSoldier(
                    data[1], data[2], int.Parse(data[3]), double.Parse(data[4]), double.Parse(data[5]));
              
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
        missionController.FailMissionsOnHold();
        writer.AppendLine(OutputMessages.Result);

        writer.AppendLine(string.Format(OutputMessages.SuccessfulMissions, missionController.SuccessMissionCounter));

        writer.AppendLine(string.Format(OutputMessages.FailedMissions, missionController.FailedMissionCounter));
        writer.AppendLine(OutputMessages.Soldiers);

        foreach (var soldier in this.army.Soldiers.OrderByDescending(s => s.OverallSkill))
            writer.AppendLine(soldier.ToString());
    }    
}