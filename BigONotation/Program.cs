using System;
using System.Diagnostics;

class BigONotationDemo 
{
    static void Main(string[] args)
    {
        int[] inputSizes = { 10, 100, 1000, 10000};

        Console.WriteLine("Big O Notation Timer");

        foreach (var size in inputSizes)
        {
            MeasureTime(() => NotationO1(size));
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

    static int NotationO1(int size)
    {
        int half = size / 2;
        return half;
    }


}