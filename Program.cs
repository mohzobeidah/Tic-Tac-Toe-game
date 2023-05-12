// See https://aka.ms/new-console-template for more information
using Tic_Tac_Toe_game;

Console.WriteLine("Hello, World!");


Console.WriteLine("enter first palyer name: ");
var player1 = Console.ReadLine();

Console.WriteLine("enter second palyer name: ");
var player2 = Console.ReadLine();

 List<Player> players = new List<Player> {
     new Player{ Id=1 ,Name=player1,Symbol="X" },
     new Player{ Id=1 ,Name=player2,Symbol="O" },
};
string ent="yes";
do{
Gameboard gameboard = new Gameboard(players);
Console.WriteLine(" new game started ");
gameboard.ToString();
while (gameboard.Trials!=gameboard.MaxTry)
{
  
    Console.WriteLine(" this turn of  "+players[gameboard.currentPlayerIndex].Name);
    var value = Console.ReadLine();
    if(!Int32.TryParse(value , out  int intval) )
    continue;
    if(!gameboard.Setvalue(intval,players[gameboard.currentPlayerIndex]))
    continue;
    if(gameboard.FinishGame){
    Console.WriteLine(" game finished");
    break;
    }
   
}
Console.WriteLine("play again yes or no ? ");
 ent = Console.ReadLine();
}
while("yes"==ent);

//gameboard.ToString();
