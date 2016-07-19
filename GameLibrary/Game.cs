using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class Game
    {
        Player[] players;
        Player activePlayer;
        IAmGame handler;
        Board board;

        public Game(IAmGame handler, int boardRows, int boardCols, string boardSpaceSeperator)
        {
            players = new Player[2];
            this.handler = handler;
            board = new Board(boardRows, boardCols, boardSpaceSeperator);

            //Random names from http://www.behindthename.com/random/ 
            //The names are Greek ;)
            players[0] = new Player() { Name = "Player 1: Theophania", Token = 'X' }; //using object initialization syntax
            players[1] = new Player() { Name = "Player 2: Xenon", Token = 'O' };
        }

        public void Start()
        {
            int indexOfCurrentPlayer = 1;

            do
            {
                //select the other player
                indexOfCurrentPlayer = (indexOfCurrentPlayer == 0) ? 1 : 0;
                activePlayer = players[indexOfCurrentPlayer];
                handler.DisplayBoard();
                handler.TakeTurn(activePlayer);
                

                //Added this slight delay for user experience.  Without it it's harder to notice the board repaint
                //try commenting it out and check out the difference.  Which do you prefer?
                //System.Threading.Thread.Sleep(300);
            } while (!handler.GameOver(activePlayer));
            handler.DisplayWinner(activePlayer);
        }

        public Board GetBoard()
        {
            return board;
        }
    }
}
