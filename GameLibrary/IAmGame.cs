using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public interface IAmGame
    {
        bool GameOver(Player activePlayer);
        void TakeTurn(Player activePlayer);
        void DisplayBoard();
        void DisplayWinner(Player activePlayer);
    }
}
