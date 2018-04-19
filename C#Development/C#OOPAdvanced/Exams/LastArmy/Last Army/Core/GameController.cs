using System;
using System.Linq;

public class GameController
{
    private readonly IArmy army;
    private readonly IWareHouse wareHouse;
    private readonly MissionController missionController;
    private readonly ISoldierFactory soldierFactory;
    private readonly IMissionFactory missionFactory;
    private readonly IWriter writer;

    public GameController(IWriter writer)
    {
        this.army = new Army();
        this.wareHouse = new WareHouse();
        this.missionController = new MissionController(this.army, this.wareHouse);
        this.soldierFactory = new SoldierFactory();
        this.missionFactory = new MissionFactory();
        this.writer = writer;
    }
    
    public void GiveInputToGameController(string input)
    {
        var data = input.Split();

        if (data[0].Equals("Soldier"))
        {
            if(data[1] == "Regenerate")
            {
                this.army.RegenerateTeam(data[2]);
            }
            else
            {
                var soldier = this.soldierFactory
                    .CreateSoldier(data[1], data[2], int.Parse(data[3]),
                    double.Parse(data[4]), double.Parse(data[5]));

                if (this.wareHouse.TryEquipSoldier(soldier))
                {
                    this.army.AddSoldier(soldier);
                }
                else
                {
                    throw new ArgumentException(
                        string.Format(OutputMessages.SoldierCannotBeEquiped, data[1], data[2]));
                }
            }

        }
        else if (data[0].Equals("WareHouse"))
        {
            var name = data[1];
            var number = int.Parse(data[2]);

            this.wareHouse.AddAmmunition(name, number);
        }
        else if (data[0].Equals("Mission"))
        {
            var mission = this.missionFactory.CreateMission(data[1], double.Parse(data[2]));
            this.writer.AppendLine(this.missionController.PerformMission(mission).Trim());
        }
    }

    public void RequestResult()
    {
        this.missionController.FailMissionsOnHold();
        this.writer.AppendLine(OutputMessages.Results);
        this.writer.AppendLine(string.Format(OutputMessages.SuccessfullMissionsCount, this.missionController.SuccessMissionCounter));
        this.writer.AppendLine(string.Format(OutputMessages.FailedMissionsCount, this.missionController.FailedMissionCounter));
        this.writer.AppendLine(OutputMessages.Soldiers);

        foreach (var soldier in this.army.Soldiers.OrderByDescending(s => s.OverallSkill))
        {
            this.writer.AppendLine(soldier.ToString());
        }
    }
    
}