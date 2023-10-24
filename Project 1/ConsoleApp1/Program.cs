using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] s = {1,3,6,7,8,5};
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
                if (Segment[i,k] == s[i])
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
                Console.Write($"[{Segment[i,k]}, ");
                k = 1;
                Console.Write($"{Segment[i, k]}]");
                Console.WriteLine();
            }
        }
    }
}
