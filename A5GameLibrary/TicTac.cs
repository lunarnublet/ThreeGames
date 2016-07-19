using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary;

namespace TicTacToe
{
    public class TicTac : IAmGame
    {
        const int numRows = 3;
        const int numCols = 3;
        string boardSpaceSeperator = " - ";
        Board board;
        static void Main(string[] args)
        {
            TicTac p = new TicTac();
            p.Start();
        }


        /// <summary>
        /// Calls Game's start to start game's loop
        /// </summary>
        private void Start()
        {
            Game g = new Game(this, numRows, numCols, boardSpaceSeperator);
            board = g.GetBoard();
            g.Start();
        }

        public void TakeTurn(Player activePlayer)
        {
            int[] position = PiecePlacement(activePlayer);

            board.TakeSquare(position[0], position[1], activePlayer.Token);
        }

        public int[] PiecePlacement(GameLibrary.Player activePlayer)
        {
            //you need to be using the .NET framework 4.6 for this line to work (C# 6)
            Console.WriteLine();
            Console.WriteLine($"{activePlayer.Name}, it's your turn:");
            Console.WriteLine("Make your move by entering the number of the square you'd like to take:");

            //todo: Prevent returning a location that's already been used

            return ConvertToArrayLocation(Console.ReadLine());
        }

        public int[] ConvertToArrayLocation(string boardPosition)
        {
            int position;
            if (!Int32.TryParse(boardPosition, out position))
            {
                return new int[] { 2, 2 };
            }
            if (position > (numRows * numCols))
            {
                return new int[] { 2, 2 };
            }
            position--; //reduce position to account for 1-based board map (done for user experience)
            int row = position / numRows;
            int column = position % numCols;
            return new int[] { row, column }; //inline array initialization
        }

        public bool GameOver(Player activePlayer)
        {
            for (int i = 0; i < numRows; ++i)
            {
                if ((board.GetSquare(i, 0) == activePlayer.Token) &&
                    (board.GetSquare(i, 1) == activePlayer.Token) &&
                    (board.GetSquare(i, 2) == activePlayer.Token))
                {
                    return true;
                }
            }
            for (int i = 0; i < numCols; ++i)
            {
                if ((board.GetSquare(0, i) == activePlayer.Token) &&
                    (board.GetSquare(1, i) == activePlayer.Token) &&
                    (board.GetSquare(2, i) == activePlayer.Token))
                {
                    return true;
                }
            }
            if (((board.GetSquare(0, 0) == activePlayer.Token) &&
                    (board.GetSquare(1, 1) == activePlayer.Token) &&
                    (board.GetSquare(2, 2) == activePlayer.Token))
                    ||
                    ((board.GetSquare(2, 0) == activePlayer.Token) &&
                    (board.GetSquare(1, 1) == activePlayer.Token) &&
                    (board.GetSquare(0, 2) == activePlayer.Token)))
            {
                return true;
            }

            return false;
        }

        public void DisplayBoard()
        {
            Console.Clear();
            Console.WriteLine(board.ToString());
        }

        public void DisplayWinner(Player activePlayer)
        {
            Console.Clear();
            Console.WriteLine(board.ToString());
            Console.WriteLine(activePlayer.Token + " Player won!");
        }
    }
}
