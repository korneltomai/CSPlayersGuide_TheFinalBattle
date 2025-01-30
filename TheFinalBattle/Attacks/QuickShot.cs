namespace TheFinalBattle.Attacks
{

    public class QuickShot : IAttack
    {
        public string Name => "QUICK SHOT";
        public AttackData AttackData => new AttackData(3, hitChance:0.5f);
    }

    
}

