using TheFinalBattle.Characters;
using TheFinalBattle.Gears;

namespace TheFinalBattle.Actions
{
    public class EquipGearAction : IAction
    {
        private readonly IGear _gear;

        public EquipGearAction(IGear gear)
        {
            _gear = gear;
        }

        public void Do(Battle battle, Character user)
        {
            if (user.Gear != null)
            {
                battle.GetPartyFor(user).Inventory.Gears.Add(user.Gear);
                Console.WriteLine($"{user.Name} has swapped his {user.Gear.Name} to {_gear.Name}.");
            }
            else
                Console.WriteLine($"{user.Name} has equipped {_gear.Name}.");

            user.Gear = _gear;
            battle.GetPartyFor(user).Inventory.Gears.Remove(_gear);
        }
    }
}
