// See https://aka.ms/new-console-template for more information
using Tic_Tac_Toe_game;

Console.WriteLine("Hello, World!");

 List<Player> players = new List<Player> {
     new Player{ Id=1 ,Name="mohamme",Symbol="X" },
     new Player{ Id=1 ,Name="Ahmmed",Symbol="O" },
};
Gameboard gameboard = new Gameboard(players);
gameboard.Setvalue(8,players[0]);
gameboard.Setvalue(7,players[1]);
gameboard.Setvalue(4,players[0]);
gameboard.Setvalue(1,players[1]);
gameboard.Setvalue(2,players[0]);

//gameboard.ToString();
