namespace TheFinalBattle.Attacks
{
    public interface IAttack
    {
        public string Name { get; }
        public AttackData AttackData { get; }
    }
    public record AttackData(int Damage, DamageType DamageType = DamageType.Normal, Targeting Targeting = Targeting.SingleTarget, TargetTeam TargetTeam = TargetTeam.EnemyTeam, float HitChance = 1.0f);
    public enum DamageType { Normal, Decoding }
    public enum Targeting { SingleTarget, TeamTarget }
    public enum TargetTeam { OwnTeam, EnemyTeam }
}

