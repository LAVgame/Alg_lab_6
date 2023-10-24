using System;

namespace ConsoleApp3
{
    class Program
    {
        static public (int, int)[] s = new (int, int)[10];
        static public (int, int)[] resultList = new (int, int)[10];

        static void Main(string[] args)
        {
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                s[i] = (random.Next(1, 9), random.Next(1, 9));
            }

            Console.WriteLine("Initial Data:");
            foreach (var item in s)
            {
                Console.WriteLine($"{item.Item1}, {item.Item2}");
            }

            ProcessData();

            Console.WriteLine("\nUpdated Data:");
            foreach (var item in s)
            {
                Console.WriteLine($"{item.Item1}, {item.Item2}");
            }

            Console.WriteLine("\nResult List:");
            foreach (var item in resultList)
            {
                Console.WriteLine($"{item.Item1}, {item.Item2}");
            }

            Console.ReadKey();
        }

        static void ProcessData()
        {
            for (int i = 0; i < 10; i++)
            {
                if (s[i].Item1 != 0)
                {
                    for (int cf = 0; cf < 10; cf++)
                    {
                        if (s[i].Item2 < resultList[cf].Item2) //min 
                        {
                            if (resultList[cf].Item1 == 0)
                            {
                                resultList[cf] = s[i];
                                break;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int cf = 0; cf < 10; cf++)
                {
                    if (s[i].Item1 != 0 && s[i].Item2 < resultList[cf].Item2) //min 
                    {
                        if (resultList[cf] == s[i])
                        {
                            s[i] = (0, 0);
                        }
                    }
                }
            }
        }
    }
}
