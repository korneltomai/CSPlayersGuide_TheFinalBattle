namespace TheFinalBattle.Attacks
{
    public class Unraveling : IAttack
    {
        private readonly Random _random = new Random();
        public string Name => "UNRAVELING";
        public AttackData AttackData => new AttackData(_random.Next(5), DamageType:DamageType.Decoding);
    }

    
}

