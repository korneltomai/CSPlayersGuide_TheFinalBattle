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
            if (Heroes.TakeTurn(this))
                return WinningParty.Heroes;
            if (Monsters.TakeTurn(this))
                return WinningParty.Monsters;
            return WinningParty.None;
        }        

        public Party GetPartyFor(Character character)
        {
            foreach (Character c in Heroes.Characters)
                if (c == character)
                    return Heroes;
            return Monsters;
        }

        public Party GetEnemyPartyFor(Character character)
        {
            foreach (Character c in Heroes.Characters)
                if (c == character)
                    return Monsters;
            return Heroes;
        }

        public void DisplayStatus(Character currentCharacter)
        {
            Console.WriteLine();
            Helpers.PrintLineWithTextInMiddle('=', "BATTLE");
            Heroes.DisplayParty(currentCharacter);
            Helpers.PrintLineWithTextInMiddle('-', "VS");
            Monsters.DisplayParty(currentCharacter, true);
            Helpers.PrintLine('=');
            Console.WriteLine();
        }
    }

    public enum WinningParty { Heroes, Monsters, None }
}
