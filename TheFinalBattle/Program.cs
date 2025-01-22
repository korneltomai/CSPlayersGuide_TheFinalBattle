using TheFinalBattle;
using TheFinalBattle.Characters;
using TheFinalBattle.Items;
using TheFinalBattle.Players;

Console.Write("What is your name? ");
string playerName = Console.ReadLine()?.ToUpper() ?? "TOG";
Console.Clear();

IPlayer player1 = new HumanPlayer();
IPlayer player2 = new ComputerPlayer();

Party heroes = new Party(
    player1, 
    [new TrueProgrammer(playerName, new Sword()), new VinFletcher(new VinsBow())], 
    new Inventory(
        [new Potion(), new Potion(), new Potion()],
        []
        )
    );

Battle battle = new(heroes);

Game game = new Game(battle, GetWaves(player2));
game.Run();

Party[] GetWaves(IPlayer player)
{
    return [
            new Party(
                        player,
                        [new Skeleton(new Dagger())],
                        new Inventory(
                            [new Potion()],
                            []
                            )
                        ),
                    new Party(
                        player,
                        [new Skeleton(), new Skeleton()],
                        new Inventory(
                            [new Potion()],
                            [new Dagger(), new Dagger()]
                            )
                        ),
                    new Party(
                        player,
                        [new UncodedOne()],
                        new Inventory(
                            [new Potion()],
                            []
                            )
                        ),
                ];
}
