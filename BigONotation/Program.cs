using System;
using System.Diagnostics;

class BigONotationDemo 
{
    static void Main(string[] args)
    {
        int[] inputSizes = { 100, 1000, 10000, 100000};

        Console.WriteLine("Big O Notation Timer");

        foreach (var size in inputSizes)
        {
            MeasureTime(() => NotationO_1(size));
            MeasureTime(() => NotationO_N(size));
        }
    }

    static void MeasureTime(Action functionToRun) {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        functionToRun();
        stopWatch.Stop();

        TimeSpan ts = stopWatch.Elapsed;
        
        Console.WriteLine("RunTime " + ts);
    }

    static int NotationO_1(int size)
    {
        int half = size * 2;
        return half;
    }

    static int NotationO_N(int size)
    {
        int sum = 0;
        for (int t = 0; t < size; t++)
        {
            sum+=t;
        }

        return sum;
    }


}