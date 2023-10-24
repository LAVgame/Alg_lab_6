using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] s = new int[10];
            //сортируем в начале 
             
            for (int i = 0; i < s.Length; i++)
            {
                int temp = new Random().Next(1, 9);
                if (!s.Contains(temp)) s[i] = temp;

            }
            Array.Sort(s);

            int xm = int.MaxValue;
            int[,] Segment = new int[s.Length, 2];

            int k = 0;
            for (int i = 0; i < s.Length; i++)
            {
                for (int ji = 0; ji < s.Length; ji++)
                {
                    if (s[i] != -1)
                    {
                        xm = Math.Min(xm, s[i]);
                    }
                }
                k = 0;
                Segment[i, k] = xm;
                if (Segment[i, k] == s[i])
                {
                    s[i] = -1;
                }
                k = 1;
                Segment[i, k] = xm + 1;
                if (Segment[i, k] == s[i])
                {
                    s[i] = -1;
                }
                xm = int.MaxValue;
            }
            for (int i = 0; i < s.Length; i++)
            {

                k = 0;
                Console.Write($"[{Segment[i, k]}, ");
                k = 1;
                Console.Write($"{Segment[i, k]}]");
                Console.WriteLine();
            }
        }
    }
}
