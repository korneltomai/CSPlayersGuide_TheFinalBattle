namespace TheFinalBattle.Attacks
{
    public class GreaterHeal : IAttack
    {
        private readonly Random _random = new Random();
        public string Name => "GREATER HEAL";
        public AttackData AttackData => new AttackData(-1 * _random.Next(3), Targeting:Targeting.TeamTarget, TargetTeam: TargetTeam.OwnTeam);
    }
}