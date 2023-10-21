using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] Point = {4,7,9,6,13};
        Console.WriteLine($"Точки: {Point[0]}, {Point[1]}, {Point[2]}, {Point[3]}, {Point[4]}.");
        int minPoint = int.MaxValue;
        int i_min = -1;
        for (int i = 0; i < Point.Length; i++)
        {
            //поиск левой крайней точки
            if (minPoint > Point[i])
            {
                i_min = i;
                minPoint = Point[i]; 
            }
        }
        Console.WriteLine($"Вывод крайней левой точки:{minPoint} и её индекса:{i_min}");
        Console.WriteLine("Отрезки для покрытия точек:");
        // Массив содержащий в себе координаты отрезков где i - первая координата, j - вторая координата; 
        int[,] section_arr = new int[Point.Length,2];
        section_arr[0,0] = minPoint;
        Point[i_min] = -1;
        minPoint = int.MaxValue;
        for (int i = 0; i < Point.Length; i++)
        {            
            if (Point[i] != -1)
            {
                if (minPoint > Point[i])
                {
                    i_min = i;
                    minPoint = Point[i];
                    section_arr[0, 1] = minPoint;
                    Point[i] = -1;
                }
            } 
        }
        





        for (int i = 0; i < Point.Length; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.Write($"{section_arr[i, j]} \t");
            }
            Console.WriteLine();
        }
        Console.ReadLine();
    }
}



/* Функция ActSel
 * 
 * using System;
using System.Collections.Generic;

class Program
{
    static List<Tuple<int, int>> ActSel(params int[] points)
    {
        List<Tuple<int, int>> result = new List<Tuple<int, int>>();
        List<Tuple<int, int>> segments = new List<Tuple<int, int>>();

        if (points.Length % 2 != 0)
        {
            throw new ArgumentException("Количество аргументов должно быть четным.");
        }

        for (int i = 0; i < points.Length; i += 2)
        {
            int l = points[i];
            int r = points[i + 1];
            segments.Add(Tuple.Create(l, r));
        }

        while (segments.Count > 0)
        {
            Tuple<int, int> minRightSegment = null;
            int minRightEnd = int.MaxValue;

            foreach (var segment in segments)
            {
                if (segment.Item2 < minRightEnd)
                {
                    minRightEnd = segment.Item2;
                    minRightSegment = segment;
                }
            }

            if (minRightSegment != null)
            {
                result.Add(minRightSegment);
                segments.RemoveAll(s => s.Item1 <= minRightEnd);
            }
        }

        return result;
    }

    static void Main()
    {
        int[] inputSegments = { 1, 3, 2, 4, 3, 5, 4, 6 };
        List<Tuple<int, int>> solution = ActSel(inputSegments);

        Console.WriteLine("Решение:");
        foreach (var segment in solution)
        {
            Console.WriteLine($"[{segment.Item1}, {segment.Item2}]");
        }
    }
}
*/


/*Улучшеный  ActSel
 using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Tuple<int, int>> ActSel(params int[] points)
    {
        List<Tuple<int, int>> result = new List<Tuple<int, int>>();
        List<Tuple<int, int>> segments = new List<Tuple<int, int>>();

        if (points.Length % 2 != 0)
        {
            throw new ArgumentException("Количество аргументов должно быть четным.");
        }

        for (int i = 0; i < points.Length; i += 2)
        {
            int l = points[i];
            int r = points[i + 1];
            segments.Add(Tuple.Create(l, r));
        }

        // Сортируем отрезки по правым концам
        segments = segments.OrderBy(s => s.Item2).ToList();

        while (segments.Count > 0)
        {
            Tuple<int, int> minRightSegment = segments[0];
            result.Add(minRightSegment);
            int minRightEnd = minRightSegment.Item2;
            segments.RemoveAll(s => s.Item1 <= minRightEnd);
        }

        return result;
    }

    static void Main()
    {
        int[] inputSegments = { 1, 3, 2, 4, 3, 5, 4, 6 };
        List<Tuple<int, int>> solution = ActSel(inputSegments);

        Console.WriteLine("Решение:");
        foreach (var segment in solution)
        {
            Console.WriteLine($"[{segment.Item1}, {segment.Item2}]");
        }
    }
}
 
 
 
 */