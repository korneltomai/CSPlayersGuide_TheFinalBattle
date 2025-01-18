using TheFinalBattle;
using TheFinalBattle.Characters;
using TheFinalBattle.Players;

Console.Write("What is your name? ");
string playerName = Console.ReadLine()?.ToUpper() ?? "TOG";
Console.Clear();

IPlayer player1 = new HumanPlayer();
IPlayer player2 = new ComputerPlayer();

Party heroes = new Party(player1, [new TrueProgrammer(playerName)]);
Party monsters = new Party(player2, [new Skeleton()]);

Battle battle = new Battle(heroes, monsters);

Game game = new Game(battle);
game.Run();
