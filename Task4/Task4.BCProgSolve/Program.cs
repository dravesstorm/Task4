using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.BCProgSolve
{
    class Program
    {
        static void Main(string[] args)
        {
            Opponent opponent = new Opponent();
            opponent.StartGame();

            Console.WriteLine("Guess 4-digit number without repeats");
            Console.WriteLine("\tenter to continue...");
            Console.ReadLine();
            Console.WriteLine("When you see this number on the screen, enter Y");
            Console.WriteLine("\tenter to continue...");
            Console.ReadLine();

            while (true)
            {
                if (!(opponent._PossibleTokens.Count == 0))
                {
                    Console.WriteLine(opponent.MakeMove());
                    Console.WriteLine("Enter answer in such format +{bulls}-{cows}:");
                    string answer = Console.ReadLine();
                    if (answer=="Y")
                    {
                        Console.WriteLine("Good game!");
                        break;
                    }
                    opponent.TakeAnswer(answer);
                }
                else
                {
                    Console.WriteLine("You answered wrong, try again");
                    break;
                }
            }

            Console.ReadKey();

        }
    }
}
