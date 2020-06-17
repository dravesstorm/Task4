using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.BCProgSolve
{
    public interface IMastermindPlayer
    {
        string StartGame();
        string MakeMove();

        void TakeAnswer(string answer);  //answer is in string format like +1-2 or +0-2 etc..
    }
}
