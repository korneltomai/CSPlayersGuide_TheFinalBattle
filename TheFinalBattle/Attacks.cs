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
        public AttackData AttackData => new AttackData(1);
    }

    public class BoneCrunch : IAttack
    {
        private readonly Random _random = new Random();
        public string Name => "BONE CRUNCH";
        public AttackData AttackData => new AttackData(_random.Next(2));
    }

    public class Bite : IAttack
    {
        public string Name => "BITE";
        public AttackData AttackData => new AttackData(1);
    }

    public class Unraveling : IAttack
    {
        private readonly Random _random = new Random();
        public string Name => "UNRAVELING";
        public AttackData AttackData => new AttackData(_random.Next(5), DamageType:DamageType.Decoding);
    }

    public class Stab : IAttack
    {
        public string Name => "STAB";
        public AttackData AttackData => new AttackData(1);
    }

    public class Slash : IAttack
    {
        public string Name => "SLASH";
        public AttackData AttackData => new AttackData(2);
    }

    public class QuickShot : IAttack
    {
        public string Name => "QUICK SHOT";
        public AttackData AttackData => new AttackData(3, hitChance:0.5f);
    }

    public record AttackData(int Damage, DamageType DamageType = DamageType.Normal, Targeting Targeting = Targeting.SingleTarget, TargetTeam TargetTeam = TargetTeam.EnemyTeam, float hitChance = 1.0f);
    public enum DamageType { Normal, Decoding }
}

