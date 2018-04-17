using System.Collections.Generic;
using System.Text;

public class SpecialForce : Soldier
{
    private const double OverallSkillMiltiplier = 3.5;
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
        this.OverallSkill *= OverallSkillMiltiplier;
    }

    protected override IReadOnlyList<string> WeaponsAllowed => weaponsAllowed;

    public override void Regenerate()
    {
        base.Regenerate();
        this.Endurance += 20;
    }
}