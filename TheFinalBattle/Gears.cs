using TheFinalBattle.Attacks;

namespace TheFinalBattle
{
    public interface IGear
    {
        public string Name { get; }
        public IAttack Attack { get; }
    }

    public class Dagger : IGear
    {
        public string Name => "DAGGER";
        public IAttack Attack => new Stab();
    }

    public class Sword : IGear
    {
        public string Name => "SWORD";
        public IAttack Attack => new Slash();
    }

    public class VinsBow : IGear
    {
        public string Name => "VIN'S BOW";
        public IAttack Attack => new QuickShot();
    }
}
