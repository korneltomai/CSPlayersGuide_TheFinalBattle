using TheFinalBattle;
using TheFinalBattle.Characters;
using TheFinalBattle.Items;
using TheFinalBattle.Gears;
using TheFinalBattle.Players;

Console.Write("What is your name? ");
string playerName = Console.ReadLine()?.ToUpper() ?? "TOG";
Console.Clear();

IPlayer player1 = new HumanPlayer();
IPlayer player2 = new ComputerPlayer();

Party heroes = new Party(
    player1, 
    [
        new TrueProgrammer(playerName, new Sword()), 
        new VinFletcher(new VinsBow()),
        new Ramosa(new HealersWand())
    ], 
    new Inventory(
        [new Potion(), new Potion(), new FireBomb()],
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
                    [new Potion(), new FireBomb()],
                    [new Dagger(), new Dagger()]
                )
            ),
            new Party(
                player,
                [new StoneAmarok(), new StoneAmarok()],
                new Inventory(
                    [new Potion()],
                    []
                )
            ),
            new Party(
                player,
                [new UncodedOne()],
                new Inventory(
                    [new Potion()],
                    []
                )
            )
            ];
}
