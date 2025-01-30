namespace TheFinalBattle.Attacks
{
    public class Punch : IAttack
    {
        public string Name => "PUNCH";
        public AttackData AttackData => new AttackData(1);
    }

    
}

