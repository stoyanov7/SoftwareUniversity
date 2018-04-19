using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private const int baseRegenerateIncrease = 10;
    private const double maxEndurance = 100;

    private double endurance;

    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.Weapons = new Dictionary<string, IAmmunition>();

        foreach (var weapon in this.WeaponsAllowed)
        {
            this.Weapons.Add(weapon, null);
        }
    }


    public string Name {get; }

    public int Age { get; }

    public double Experience { get; private set; }

    public double Endurance
    {
        get => this.endurance;

        private set => this.endurance = Math.Min(value, maxEndurance);
    }

    protected abstract double OverallSkillMultiplier { get; } 

    public double OverallSkill => (this.Age + this.Experience) * this.OverallSkillMultiplier;

    protected abstract IEnumerable<string> WeaponsAllowed { get; }

    public IDictionary<string, IAmmunition> Weapons { get; }

    protected virtual int RegenerateIncrease => baseRegenerateIncrease;

    public void CompleteMission(IMission mission)
    {
        this.Experience += mission.EnduranceRequired;
        this.Endurance -= mission.EnduranceRequired;

        foreach (var weapon in this.Weapons.Values.Where(w=>w!=null).ToList())
        {
            weapon.DecreaseWearLevel(mission.WearLevelDecrement);

            if (weapon.WearLevel <= 0)
            {
                this.Weapons[weapon.Name] = null;
            }
        }
    }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        var hasAllEquipment = this.Weapons
            .Values
            .All(weapon => weapon != null);

        if (!hasAllEquipment)
        {
            return false;
        }
        
        return this.Weapons
            .Values
            .All(weapon => weapon.WearLevel > 0);
    }

    public void Regenerate()
    {
        this.Endurance += this.Age + this.RegenerateIncrease;
    }

    public override string ToString()
    {
        return string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
    }
}