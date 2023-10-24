using System;

namespace ConsoleApp3
{
    class Program
    {
        static public Tuple<int, int>[] segments = new Tuple<int, int>[10]; // Массив отрезков

        static void Main(string[] args)
        {
            InitializeSegments();

            Console.WriteLine("Исходные отрезки:");
            PrintSegments(segments);

            Array.Sort(segments, (a, b) => a.Item2.CompareTo(b.Item2)); // Сортировка по правому концу

            Tuple<int, int> currentSegment = segments[0];
            Console.WriteLine($"\nМинимальный отрезок: ({currentSegment.Item1}, {currentSegment.Item2})");

            for (int i = 1; i < segments.Length; i++)
            {
                if (segments[i].Item1 > currentSegment.Item2)
                {
                    currentSegment = segments[i];
                    Console.WriteLine($"({currentSegment.Item1}, {currentSegment.Item2})");
                }
            }

            Console.ReadKey();
        }

        static void InitializeSegments()
        {
            Random random = new Random();

            for (int i = 0; i < segments.Length; i++)
            {
                int start = random.Next(1, 9);
                int end = random.Next(start + 1, 10); // Гарантия, что конец больше начала
                segments[i] = Tuple.Create(start, end);
            }
        }

        static void PrintSegments(Tuple<int, int>[] segments)
        {
            foreach (var segment in segments)
                Console.WriteLine($"({segment.Item1}, {segment.Item2})");
        }
    }
}
