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
        public AttackData AttackData => new AttackData(1.0f, 1, Targeting.SingleTarget, TargetTeam.EnemyTeam);
    }

    public class BoneCrunch : IAttack
    {
        private readonly Random _random = new Random();
        public string Name => "BONE CRUNCH";
        public AttackData AttackData => new AttackData(1.0f, _random.Next(2), Targeting.SingleTarget, TargetTeam.EnemyTeam);
    }

    public class Unraveling : IAttack
    {
        private readonly Random _random = new Random();
        public string Name => "UNRAVELING";
        public AttackData AttackData => new AttackData(1.0f, _random.Next(3), Targeting.SingleTarget, TargetTeam.EnemyTeam);
    }

    public class Stab : IAttack
    {
        public string Name => "STAB";
        public AttackData AttackData => new AttackData(1.0f, 1, Targeting.SingleTarget, TargetTeam.EnemyTeam);
    }

    public class Slash : IAttack
    {
        public string Name => "SLASH";
        public AttackData AttackData => new AttackData(1.0f, 2, Targeting.SingleTarget, TargetTeam.EnemyTeam);
    }

    public class QuickShot : IAttack
    {
        public string Name => "QUICK SHOT";
        public AttackData AttackData => new AttackData(0.5f, 3, Targeting.SingleTarget, TargetTeam.EnemyTeam);
    }

    public record AttackData(float hitChance, int Damage, Targeting Targeting, TargetTeam TargetTeam);
}

