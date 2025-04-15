﻿using System;
using System.Diagnostics;

class BigONotationDemo 
{
    static void Main(string[] args)
    {
        int[] inputSizes = { 100, 1000, 10000, 100000};

        Console.WriteLine("Big O Notation Timer");

        foreach (var size in inputSizes)
        {
            MeasureTime(() => NotationO_1(size), "O(1)");
            MeasureTime(() => NotationO_N(size), "O(N)");
            MeasureTime(() => NotationO_N2(size), "O(N^2)");
        }
    }

    static void MeasureTime(Action functionToRun, string title) {
        const int iterations = 10;
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        for (int i = 0; i < iterations; i ++)
        {
            functionToRun();
        }
        stopWatch.Stop();

        TimeSpan ts = stopWatch.Elapsed;
        
        double averageTime = ts.TotalSeconds / iterations;
        
        Console.WriteLine("RunTime " + title + ": " + averageTime.ToString("F9"));
    }

    // Constant time complexity: The operation takes the same amount of time regardless of the size of the input.
    static int NotationO_1(int size)
    {
        int half = size * 2;
        return half;
    }

    // Linear time complexity: The time taken by this operation increases proportionally with the size of the input. 
    static int NotationO_N(int size)
    {
        int sum = 0;
        for (int i = 0; i <= size; i++)
        {
            sum += i;
        }

        return sum;
    }

    // Quadratic complexity: Time taken increases quadratically 
    static int NotationO_N2(int size)
    {
        int firstMatchSum = 0;
        for (int i = 0; i < size; i++) 
        {
            for (int j = size; j > 0; j--)
            {
                if (i == j)
                {
                    firstMatchSum = i + j;
                }
            }
        }

        return firstMatchSum;
    }

}