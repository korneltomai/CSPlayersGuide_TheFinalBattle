namespace TheFinalBattle.Attacks
{
    public class Heal : IAttack
    {
        private readonly Random _random = new Random();
        public string Name => "HEAL";
        public AttackData AttackData => new AttackData(-1 * (_random.Next(3) + 3), TargetTeam:TargetTeam.OwnTeam);
    }
}