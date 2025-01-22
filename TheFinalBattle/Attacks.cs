using TheFinalBattle.Actions;

namespace TheFinalBattle.Attacks
{
    public interface IAttack
    {
        public string Name { get; }
        public AttackData AttackData { get; }
    }

    public class Punch : IAttack
    {
        public string Name => "PUNCH";
        public AttackData AttackData => new AttackData(1, Targeting.SingleTarget, TargetTeam.EnemyTeam);
    }

    public class BoneCrunch : IAttack
    {
        private readonly Random _random = new Random();
        public string Name => "BONE CRUNCH";
        public AttackData AttackData => new AttackData(_random.Next(2), Targeting.SingleTarget, TargetTeam.EnemyTeam);
    }

    public class Unraveling : IAttack
    {
        private readonly Random _random = new Random();
        public string Name => "UNRAVELING";
        public AttackData AttackData => new AttackData(_random.Next(3), Targeting.SingleTarget, TargetTeam.EnemyTeam);
    }

    public record AttackData(int Damage, Targeting Targeting, TargetTeam TargetTeam);
}

