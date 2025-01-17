using TheFinalBattle;
using TheFinalBattle.Characters;

Console.Write("What is your name? ");
string playerName = Console.ReadLine()?.ToUpper() ?? "TOG";
Console.Clear();

Player player1 = new Player(PlayerType.Human);
Player player2 = new Player(PlayerType.Computer);

Party heroes = new Party(player1);
Party monsters = new Party(player2);

Battle battle = new Battle(heroes, monsters);

heroes.Characters.Add(new TrueProgrammer(battle, playerName));

Game game = new Game(battle);
game.Run();
