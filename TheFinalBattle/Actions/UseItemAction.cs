using TheFinalBattle.Characters;
using TheFinalBattle.Items;

namespace TheFinalBattle.Actions
{
    public class UseItemAction : IAction
    {
        private readonly IItem _item;
        private readonly List<Character> _targets;

        public UseItemAction(IItem item, List<Character> targets)
        {
            _item = item;
            _targets = targets;
        }

        public void Do(Battle battle, Character user)
        {
            foreach (Character target in _targets)
            {
                if (user == target)
                    Console.WriteLine($"{user.Name} used {_item.Name} on THEMSELVES.");
                else
                    Console.WriteLine($"{user.Name} used {_item.Name} on {target.Name}.");

                _item.Use(battle, target);

                battle.GetPartyFor(user).Inventory.Items.Remove(_item);
            }
        }
    }
}
