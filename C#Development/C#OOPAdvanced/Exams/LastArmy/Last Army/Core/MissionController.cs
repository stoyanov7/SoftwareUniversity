using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MissionController
{
    private readonly Queue<IMission> missionQueue;
    private readonly IArmy army;
    private readonly IWareHouse wareHouse;

    public MissionController(IArmy army, IWareHouse wareHouse)
    {
        this.army = army;
        this.wareHouse = wareHouse;
        this.missionQueue = new Queue<IMission>();
    }

    public int SuccessMissionCounter { get; private set; }

    public int FailedMissionCounter { get; private set; }

    public Queue<IMission> Missions => this.missionQueue;

    public string PerformMission(IMission mission)
    {
        var sb = new StringBuilder();

        if (this.missionQueue.Count >= 3)
        {
            sb.AppendLine(string.Format(OutputMessages.MissionDeclined, this.missionQueue.Dequeue().Name));
            this.FailedMissionCounter++;
        }

        this.missionQueue.Enqueue(mission);

        var currentMissionsCount = this.missionQueue.Count;
        for (var i = 0; i < currentMissionsCount; i++)
        {
            this.wareHouse.EquipArmy(this.army);
            var currentMission = this.missionQueue.Dequeue();
            var missionTeam = this.CollectMissionTeam(mission);
            var successful = this.ExecuteMission(currentMission, missionTeam);

            if (successful)
            {
                sb.AppendLine(string.Format(OutputMessages.MissionSuccessful, currentMission.Name));
            }
            else
            {
                this.missionQueue.Enqueue(currentMission);
                sb.AppendLine(string.Format(OutputMessages.MissionOnHold, currentMission.Name));
            }
        }

        return sb.ToString();
    }

    private bool ExecuteMission(IMission mission, List<ISoldier> missionTeam)
    {
        if (missionTeam.Sum(w => w.OverallSkill) >= mission.ScoreToComplete)
        {
            foreach (var soldier in missionTeam)
            {
                soldier.CompleteMission(mission);
            }

            this.SuccessMissionCounter++;
            return true;
        }

        return false;
    }

    private List<ISoldier> CollectMissionTeam(IMission mission)
    {
        var missionTeam = this.army
            .Soldiers
            .Where(s => s.ReadyForMission(mission))
            .ToList();

        return missionTeam;
    }

    public void FailMissionsOnHold()
    {
        while (this.missionQueue.Count > 0)
        {
            this.FailedMissionCounter++;
            this.missionQueue.Dequeue();
        }
    }
}