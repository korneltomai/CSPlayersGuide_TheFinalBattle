using TheFinalBattle.Attacks;

namespace TheFinalBattle.Gears
{
    public class HealersWand : IGear
    {
        public string Name => "HEALER'S WAND";
        public IAttack Attack => new GreaterHeal();
    }
}
