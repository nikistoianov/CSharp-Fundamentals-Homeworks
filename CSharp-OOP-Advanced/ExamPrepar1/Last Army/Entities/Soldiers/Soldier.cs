using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    public IDictionary<string, IAmmunition> Weapons { get; }
    
    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public double Experience { get; private set; }

    private double endurance;
    public double Endurance
    {
        get => endurance;
        protected set
        {
            endurance = value > 100 ? 100 : value;
        }
    }

    public double OverallSkill { get; protected set; }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) == 0;
    }

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> keys = this.Weapons.Keys.ToList();
        foreach (string weaponName in keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);

    public Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.OverallSkill = age + experience;
    }

    public virtual void Regenerate()
    {
        this.Endurance += 10 + this.Age;
    }

    public void CompleteMission(IMission mission)
    {
        throw new System.NotImplementedException();
    }

    public bool CheckIfSoldierCanJoinTeam()
    {
        //todo
        return true;
    }
}