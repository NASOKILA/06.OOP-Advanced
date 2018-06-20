using NUnit.Framework;
using System;

public class MissionControllerTests
{
    [Test]
    public void MissionControllerDisplaysFailMessage()
    {
        var army = new Army();
        var warehouse = new WareHouse();

        var missionController = new MissionController(army, warehouse);
        var mission = new Easy(1);

        string result = "";
        for (int counter = 0; counter < 4; counter++)
        {
            result = missionController.PerformMission(mission);
        }

        //pone vednuj trqbva da ima fail

        Assert.IsTrue(result.Contains("declined"));

    }

    [Test]
    public void MissionControllerDisplaysSuccessMessage()
    {
        var army = new Army();
        var warehouse = new WareHouse();

        var missionController = new MissionController(army, warehouse);
        var mission = new Easy(1);

        string result = "";
        for (int counter = 0; counter < 4; counter++)
        {
            result = missionController.PerformMission(mission);
        }

        //pone vednuj trqbva da ima fail
        Assert.IsTrue(result.Contains("completed"));
    }
}

