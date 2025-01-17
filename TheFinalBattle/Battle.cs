using TheFinalBattle.Characters;

namespace TheFinalBattle
{
    public class Battle
    {
        public Party Heroes { get; }
        public Party Monsters { get; set; }

        public Battle(Party heroes, Party monsters) 
        {
            Heroes = heroes;
            Monsters = monsters;
        }

        public WinningParty PlayRound()
        {
            if (Heroes.TakeTurn())
                return WinningParty.Heroes;
            if (Monsters.TakeTurn())
                return WinningParty.Monsters;
            return WinningParty.None;
        }        

        public List<Character> GetPartyFor(Character character)
        {
            foreach (Character c in Heroes.Characters)
                if (c == character)
                    return Heroes.Characters;
            return Monsters.Characters;
        }

        public List<Character> GetEnemyPartyFor(Character character)
        {
            foreach (Character c in Heroes.Characters)
                if (c == character)
                    return Monsters.Characters;
            return Heroes.Characters;
        }
    }

    public enum WinningParty { Heroes, Monsters, None }
}
