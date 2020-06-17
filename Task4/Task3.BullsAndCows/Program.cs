using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.BullsAndCows
{
    class Program
    {
        static void Main()
        {
            const int NmaxAnswers = 10; // число попыток
            int[] a = new int[4];  // загадываемое число
            int[] b = new int[4];  // Ваш ответ
            GenSetN(4, 10, a);
            // Диалог
            Console.WriteLine("Игра_Быки_и_Коровы");
            int nAnswers = 1;
            while (nAnswers <= NmaxAnswers)
            {
                if (Answer(b))  // ответ
                    if (NumberCompare(a, b))
                    {
                        Console.WriteLine("Вы угадали число c {0} попытки!", nAnswers);
                        Console.ReadKey();
                        return;
                    }
                int[,] d = new int[4, 2];
                // угаданная цифра d[i,1], бык(d[i,0]=2) корова(d[i,0]=1)
                // АНАЛИЗ. n - число угаданных цифр
                int n = BullsAndСows(a, b, d);
                for (int i = 0; i < n; i++)
                {
                    if (d[i, 0] == 1)
                        Console.WriteLine("КОРОВА ({0})", d[i, 1]);
                    else
                        Console.WriteLine("БЫК ({0})", d[i, 1]);
                }
                if (n == 0)
                    Console.WriteLine("В Вашем числе нет загаданных цифр");
                nAnswers++;
            }
        }

        // Сравнение заданного и введенного чисел 
        static int BullsAndСows(int[] a, int[] b, int[,] d)
        {
            int k = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (a[i] == b[j])
                    {
                        d[k, 1] = a[i];
                        if (i == j)
                            d[k, 0] = 2;
                        else
                            d[k, 0] = 1;
                        k++;
                    }
                }
            }
            return k;
        }

        // ответ пользователя (строка в число)
        static bool Answer(int[] b)
        {
            bool bb = true;
            Console.Write("Введите Ваше 4-значное число: ");
            string ss = Console.ReadLine();
            // посимвольная разборка
            for (int i = 0; i < 4; i++)
            {
                char c = ss[i];
                if (char.IsDigit(c))
                    b[i] = Convert.ToInt32(c - 48);
                else
                {
                    Console.WriteLine("Вы ввели НЕ 4-х значное число!");
                    bb = false;
                    return bb;
                }
            }
            return bb;
        }
        // Сравнение на чистое совпадение
        static bool NumberCompare(int[] a, int[] b)
        {
            bool d = true;
            for (int i = 0; i < 4; i++)
            {
                if (a[i] != b[i])
                {
                    d = false;
                    break;
                }
            }
            return d;
        }

        // Генератор множества Nq не повторяющихся 
        // целых чисел в диапазоне от 0 до Nm-1 (RVA)
        static void GenSetN(int Nq, int Nm, int[] qN)
        {
            Random r = new Random();
            int p, k = 0;
            while (k < Nq)
            {
                p = r.Next(Nm);
                bool b = true;
                for (int i = 0; i < k; i++)
                    if (p == qN[i])
                    {
                        b = false;
                        break;
                    }
                if (b)
                {
                    qN[k] = p;
                    k++;
                }
            }
        }
    }
}
