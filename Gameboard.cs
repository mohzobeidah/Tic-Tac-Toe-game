using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_game
{
    public class Gameboard
    {
        private int _maxCell = 0;
        private record CellPostitionWithValues(int x, int y, int CellValue, Player Player);
        private List<CellPostitionWithValues> CellPostitionValues = new List<CellPostitionWithValues>();
        private List<Player> players = new List<Player>();
        private int? currentPlayerIndex;

        public Gameboard(List<Player> players)
        {
            IntiazeGame();
            this.players = players;

        }
        public int[,] Cells { get; set; } = new int[3, 3];

        public override string ToString()
        {
            WriteLine("---------------------");
            for (int x = 0; x < Cells.GetLength(0); x++)
            {

                for (int y = 0; y < Cells.GetLength(1); y++)
                {
                    if (!CellPostitionValues.Any(z => z.x == x && z.y == y))
                        Write("|  {0,-5}", arg0: Cells[x, y]);
                    else
                        Write("|  {0,-5}", arg0: CellPostitionValues.First(z => z.x == x && z.y == y).Player.Symbol);
                }
                WriteLine("\n {0,-30}", arg0: "---------------------");
            }

            return base.ToString();
        }

        public void IntiazeGame()
        {

            for (int x = 0; x < Cells.GetLength(0); x++)
            {

                for (int y = 0; y < Cells.GetLength(1); y++)
                {
                    Cells[x, y] = _maxCell++;
                }
            }

        }
        public void Setvalue(int postition, Player player)
        {
            if (!CurrentPlayer(player)) return;
            if (!ValidateInput(postition)) return;
            int i = 0;
            for (int x = 0; x < Cells.GetLength(0); x++)
            {

                for (int y = 0; y < Cells.GetLength(1); y++)
                {
                    if (postition == i)
                    {
                        CellPostitionValues.Add(new CellPostitionWithValues(x, y, postition, player));

                    }
                    i++;
                }
            }

            this.ToString();
            if(ChecWin( player))
             Write(player.Name +" has win");
        }


        private bool ValidateInput(int postition)
        {
            WriteLine(CellPostitionValues.Count);
            if (CellPostitionValues.Any(z => z.CellValue == postition))
            {
                Write("has a value before");
                return false;
            }
            if (CellPostitionValues.Count >= _maxCell || postition < 0)
            {
                Write("can not add wrong value ");
                return false;
            }

            return true;
        }

        private bool CurrentPlayer(Player player)
        {

            int index = players.IndexOf(player);
            if (index == currentPlayerIndex)
            {
                Write("not your turn");
                return false;
            }
            currentPlayerIndex = index;
            return true;
        }

        private List<List<int>> WinList  => new List<List<int>>
        {
            new List<int>{0,1,2},
            new List<int>{3,4,5},
            new List<int>{6,7,8},
            new List<int>{0,3,6},
            new List<int>{1,4,7},
            new List<int>{2,5,8},
            new List<int>{0,4,8},
            new List<int>{2,4,6},
        };
    
        private bool ChecWin(Player player)
        {
           var playerlist = CellPostitionValues.Where(x=>x.Player==player).Select(x=>x.CellValue);
            return WinList.Any(list => list.OrderBy(x=>x).SequenceEqual(playerlist.OrderBy(x=>x)));
        }

        
    }
}