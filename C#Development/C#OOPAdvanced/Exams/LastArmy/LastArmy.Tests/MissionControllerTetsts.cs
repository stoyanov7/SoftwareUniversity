using NUnit.Framework;

public class MissionControllerTetsts
{
    [Test]
    public void MissionControllerDisplaysFailMessage()
    {
        var army = new Army();
        var wareHouse = new WareHouse();
        var missionController = new MissionController(army, wareHouse);

        var mission = new Easy(1);
        var result = "";

        for (var counter = 0; counter < 4; counter++)
        {
            result = missionController.PerformMission(mission);
        }

        Assert.IsTrue(result.StartsWith("Mission declined - Suppression of civil rebellion"));
    }

    [Test]
    public void MissionControllerDisplaysSuccessMessage()
    {
        var army = new Army();
        var wareHouse = new WareHouse();
        var missionController = new MissionController(army, wareHouse);

        var mission = new Easy(0);
        var result = missionController.PerformMission(mission);


        Assert.IsTrue(result.StartsWith("Mission completed - Suppression of civil rebellion"));
    }
}
