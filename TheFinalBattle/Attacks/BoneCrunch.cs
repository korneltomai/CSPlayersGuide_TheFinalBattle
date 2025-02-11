namespace TheFinalBattle.Attacks
{
    public class BoneCrunch : IAttack
    {
        private readonly Random _random = new Random();
        public string Name => "BONE CRUNCH";
        public AttackData AttackData => new AttackData(_random.Next(3));
    }

    
}

