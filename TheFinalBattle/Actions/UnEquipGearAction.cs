using TheFinalBattle.Characters;
using TheFinalBattle.Gears;

namespace TheFinalBattle.Actions
{
    public class UnEquipGearAction : IAction
    {
        private readonly IGear _gear;

        public UnEquipGearAction(IGear gear)
        {
            _gear = gear;
        }

        public void Do(Battle battle, Character user)
        {
            battle.GetPartyFor(user).Inventory.Gears.Add(user.Gear!);
            user.Gear = null;

            Console.WriteLine($"{user.Name} has unequipped his {_gear.Name}.");
        }
    }
}
