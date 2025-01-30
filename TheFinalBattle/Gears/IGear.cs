using TheFinalBattle.Attacks;

namespace TheFinalBattle.Gears
{
    public interface IGear
    {
        public string Name { get; }
        public IAttack Attack { get; }
    }
}
