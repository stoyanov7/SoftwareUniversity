using System.Collections.Generic;

public class SpecialForce : Soldier
{
    private const int regenerateIncrease = 30;
    private const double overallSkillMiltiplier = 3.5;

    private readonly List<string> weaponsAllowed = new List<string>
    {
        "Gun",
        "AutomaticMachine",
        "MachineGun",
        "RPG",
        "Helmet",
        "Knife",
        "NightVision"
    };


    public SpecialForce(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }

    protected override double OverallSkillMultiplier => overallSkillMiltiplier;

    protected override IEnumerable<string> WeaponsAllowed => this.weaponsAllowed;

    protected override int RegenerateIncrease => regenerateIncrease;
}