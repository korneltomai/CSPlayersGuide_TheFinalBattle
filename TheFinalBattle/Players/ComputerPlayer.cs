using TheFinalBattle.Actions;
using TheFinalBattle.Attacks;
using TheFinalBattle.Characters;
using TheFinalBattle.Items;

namespace TheFinalBattle.Players
{
    public class ComputerPlayer : IPlayer
    {
        private readonly Random _random = new Random();

        public IAction GetAction(Battle battle, Character character)
        {
            IAction action = new NothingAction();

            IItem? potion = battle.GetPartyFor(character).Inventory.Items.FirstOrDefault(i => i.Name == "POTION");
            if (potion != null && 
                character.Health <= (character.MaxHealth / 4) &&
                _random.Next(100) < 25)
                    return new UseItemAction(potion, [character]);

            var gears = battle.GetPartyFor(character).Inventory.Gears;
            if (gears.Count > 0 && _random.Next(100) < 50)
                return new EquipGearAction(gears[_random.Next(gears.Count)]);

            int enemyPartySize = battle.GetEnemyPartyFor(character).Characters.Count();

            if (character.Gear != null)
            {
                AttackData attackData = character.GearAttack!.AttackData;
                var attackTargets = GetActionTargets(battle, character, attackData.Targeting, attackData.TargetTeam);
                return new AttackAction(character.GearAttack, attackTargets);
            }
            else
            {
                AttackData attackData = character.StandardAttack!.AttackData;
                var attackTargets = GetActionTargets(battle, character, attackData.Targeting, attackData.TargetTeam);
                return new AttackAction(character.StandardAttack, attackTargets);
            }
        }

        private List<Character> GetActionTargets(Battle battle, Character user, Targeting targeting, TargetTeam targetTeam)
        {
            var ownTeam = battle.GetPartyFor(user).Characters;
            var enemyTeam = battle.GetEnemyPartyFor(user).Characters;

            return (targeting, targetTeam) switch
            {
                (Targeting.SingleTarget, TargetTeam.OwnTeam) => [ownTeam[_random.Next(ownTeam.Count)]],
                (Targeting.TeamTarget, TargetTeam.OwnTeam) => ownTeam,
                (Targeting.SingleTarget, TargetTeam.EnemyTeam) => [enemyTeam[_random.Next(enemyTeam.Count)]],
                (Targeting.TeamTarget, TargetTeam.EnemyTeam) => enemyTeam,
                _ => throw new ArgumentException()
            };
        }
    }
}
