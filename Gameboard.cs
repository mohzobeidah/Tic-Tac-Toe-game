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
        public int currentPlayerIndex { get; private set; } = 0;


        public int Trials => CellPostitionValues.Count;
        public int MaxTry => _maxCell;
        public bool FinishGame = false;
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
        public bool Setvalue(int postition, Player player)
        {
            if (!ValidateInput(postition)) return false;
            if (!CurrentPlayer(player)) return false;
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
            if (ChecWin(player))
            {
                Write(player.Name + " has win");
                FinishGame = true;
            }
            return true;
        }


        private bool ValidateInput(int postition)
        {
            WriteLine(CellPostitionValues.Count);
            if (CellPostitionValues.Any(z => z.CellValue == postition))
            {
                Write("has a value before");
                this.ToString();
                return false;
            }
            if (CellPostitionValues.Count >= _maxCell || postition < 0)
            {
                Write("can not add wrong value ");
                this.ToString();
                return false;
            }

            return true;
        }

        private bool CurrentPlayer(Player player)
        {

            int index = players.IndexOf(player);
            if (index != currentPlayerIndex)
            {
                Write("not your turn");
                return false;
                this.ToString();
            }
            index++;
            currentPlayerIndex = players.Count - 1 < index ? 0 : index;
            return true;
        }

         private List<List<int>> WinList => GetWinList();
        // {
        //     new List<int>{0,1,2},
        //     new List<int>{3,4,5},
        //     new List<int>{6,7,8},
        //     new List<int>{0,3,6},
        //     new List<int>{1,4,7},
        //     new List<int>{2,5,8},
        //     new List<int>{0,4,8},
        //     new List<int>{2,4,6},
        // };

        private bool ChecWin(Player player)
        {
            var playerlist = CellPostitionValues.Where(x => x.Player == player).Select(x => x.CellValue);
            return WinList.Any(list => list.OrderBy(x => x).SequenceEqual(playerlist.OrderBy(x => x)));
        }
        private List<List<int>> GetWinList()
        {

            List<List<int>> columnsList = new List<List<int>>();

            int numRows = Cells.GetLength(0); // Get the number of rows in the array
            int numCols = Cells.GetLength(1); // Get the number of columns in the array

            for (int col = 0; col < numCols; col++)
            {
                List<int> currentColumn = new List<int>();

                for (int row = 0; row < numRows; row++)
                {
                    currentColumn.Add(Cells[row, col]); // Add the element at the current row and column to the current column list
                }

                columnsList.Add(currentColumn); // Add the current column list to the columns list
            }

       

            List<List<int>> diagonalsList = new List<List<int>>();

            int size = Cells.GetLength(0); // Get the size of the square array

            // Iterate over the main diagonal (top-left to bottom-right)
            List<int> mainDiagonal = new List<int>();
            for (int i = 0; i < size; i++)
            {
                mainDiagonal.Add(Cells[i, i]);
            }
            diagonalsList.Add(mainDiagonal);

            // Iterate over the secondary diagonal (top-right to bottom-left)
            List<int> secondaryDiagonal = new List<int>();
            for (int i = 0; i < size; i++)
            {
                secondaryDiagonal.Add(Cells[i, size - 1 - i]);
            }
            diagonalsList.Add(secondaryDiagonal);


            

            List<List<int>> rowsList = new List<List<int>>();

            int numRowss = Cells.GetLength(0); // Get the number of rows in the array

            for (int row = 0; row < numRows; row++)
            {
                List<int> currentRow = new List<int>();
                int numColss = Cells.GetLength(1); // Get the number of columns in the array

                for (int col = 0; col < numColss; col++)
                {
                    currentRow.Add(Cells[row, col]); // Add the element at the current row and column to the current row list
                }

                rowsList.Add(currentRow); // Add the current row list to the rows list
            }
            return rowsList.Union(columnsList).Union(columnsList).ToList();
        }

    }
}