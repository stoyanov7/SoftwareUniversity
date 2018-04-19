using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private readonly Dictionary<string, int> ammunitionsQuantities;
    private readonly IAmmunitionFactory ammunitionFactory;

    public WareHouse()
    {
        this.ammunitionsQuantities = new Dictionary<string, int>();
        this.ammunitionFactory = new AmmunitionFactory();
    }

    public void AddAmmunition(string ammunition, int quantity)
    {
        if(this.ammunitionsQuantities.ContainsKey(ammunition))
        {
            this.ammunitionsQuantities[ammunition] += quantity;
        }
        else
        {
            this.ammunitionsQuantities.Add(ammunition, quantity);
        }
    }

    public void EquipArmy(IArmy army)
    {
        foreach (var soldier in army.Soldiers)
        {
            this.TryEquipSoldier(soldier);
        }
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        var wornOutWeapons = soldier
            .Weapons
            .Where(w => w.Value == null)
            .Select(w => w.Key)
            .ToList();

        var isSoldierEquiped = true;

        foreach (var weapon in wornOutWeapons)
        {
            if(this.ammunitionsQuantities.ContainsKey(weapon)
                && this.ammunitionsQuantities[weapon] > 0)
            {
                soldier.Weapons[weapon] = this.ammunitionFactory.CreateAmmunition(weapon);
                this.ammunitionsQuantities[weapon]--;
            }
            else
            {
                isSoldierEquiped = false;
            }
        }

        return isSoldierEquiped;
    }
}