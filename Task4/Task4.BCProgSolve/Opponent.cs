using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.BCProgSolve
{
    class Opponent
    {

        char[] _ValidDigits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public List<string> _PossibleTokens;
        string _LastMove;

        private List<string> GetAllPossibleTokens()
        {
            List<string> tokens = new List<string>();
            for (int d1 = 0; d1 < _ValidDigits.Length; d1++)
                for (int d2 = 0; d2 < _ValidDigits.Length; d2++)
                    for (int d3 = 0; d3 < _ValidDigits.Length; d3++)
                        for (int d4 = 0; d4 < _ValidDigits.Length; d4++)
                        {
                            if (d1 != d2 && d1 != d3 && d1 != d4
                                   && d2 != d3 && d2 != d4
                                    && d3 != d4)
                            {
                                tokens.Add((_ValidDigits[d1].ToString() + _ValidDigits[d2].ToString() + _ValidDigits[d3].ToString() + _ValidDigits[d4].ToString()));
                            }
                        }
            return tokens;
        }
        private void PrunePossibleMovesForTheAnswer(string guess, string answer)
        {
            for (int i = 0; i < _PossibleTokens.Count; i++)
            {
                string token = _PossibleTokens[i];
                if (AnswerToGuess(token, guess) != answer)
                    _PossibleTokens.RemoveAt(i--);
            }
        }
        private string AnswerToGuess(string token, string guess)
        {
            int p = 0, m = 0;

            for (int i = 0; i < guess.Length; i++)
            {
                int pos = token.IndexOf(guess[i]);
                if (pos >= 0)
                {
                    if (pos == i) p++;
                    else m++;
                }
            }
            return "+" + p + "-" + m;
        }


        public string MakeMove()
        {
            
            _LastMove = _PossibleTokens[new Random(DateTime.Now.Millisecond).Next(_PossibleTokens.Count)];
            return _LastMove;
        }

        public string StartGame()
        {
            _PossibleTokens = GetAllPossibleTokens();
            _LastMove = String.Empty;
            return _PossibleTokens[new Random(DateTime.Now.Millisecond).Next(_PossibleTokens.Count)];
        }

        public void TakeAnswer(string answer)
        {
            if (!String.IsNullOrEmpty(_LastMove))
            {
                PrunePossibleMovesForTheAnswer(_LastMove, answer);
            }
        }

    }
}

