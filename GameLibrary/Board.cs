using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class Board
    {
        char[,] spaces;
        string spaceSeperator;

        public Board(int rows, int cols, string spaceSeperator)
        {
            spaces = new char[rows, cols];
            this.spaceSeperator = spaceSeperator;
        }

        public override string ToString()
        {
            string temp = "";
            for (int row = 0; row <= spaces.GetUpperBound(0); row++)
            {
                for (int column = 0; column <= spaces.GetUpperBound(1); column++)
                {
                    temp += spaces[row, column];

                    //only print the dashes for the inner columns
                    if (column < spaces.GetUpperBound(1))
                    {
                        temp += spaceSeperator;
                    }
                }
                if (row < spaces.GetUpperBound(0))
                {
                    temp += "\n";
                }
            }
            return temp;
        }

        public void TakeSquare(int row, int col, char token)
        {
            spaces[row, col] = token;
        }

        public char GetSquare(int row, int col)
        {
            return spaces[row, col];
        }
    }
}
