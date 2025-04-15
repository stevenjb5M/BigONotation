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
            MeasureTime(() => NotationO_1(size), "O(1)");
            MeasureTime(() => NotationO_N(size), "O(N)");
            MeasureTime(() => NotationO_N2(size), "O(N^2)");
            MeasureTime(() => NotationO_LogN(size), "O(log N)");   

            int[] test = TwoSum(9);
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

    // Constant time complexity O(1): The operation takes the same amount of time regardless of the size of the input.
    static int NotationO_1(int size)
    {
        int half = size * 2;
        return half;
    }

    // Linear time complexity O(N): The time taken by this operation increases proportionally with the size of the input. 
    static int NotationO_N(int size)
    {
        int sum = 0;
        for (int i = 0; i <= size; i++)
        {
            sum += i;
        }

        return sum;
    }

    // Quadratic complexity O(N^2): Time taken increases quadratically 
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

    // Logarithmic Complexity O(log N): The number of steps grows very slowy as N increase
    static bool NotationO_LogN(int size)
    {
        int low = 0;
        int high = size;
        int searchNumber = new Random().Next(low, high);
        
        while (low <= high)
        {
            int mid = (low + high) / 2;

            if (searchNumber == mid)
            {
                return true;
            } 
            else if (searchNumber > mid)
            {
                low = mid + 1;
            }
            else 
            {
                high = mid - 1;
            }
        }

        return false;
    }

    // Given an array of integers nums and an integer target, return the indices of the two numbers such that they add up to the target.
    static int[] TwoSum(int target)
    {
        int[] nums = [ 2, 4, 5, 3, 6, 7];

        Dictionary<int, int> seen = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (seen.ContainsKey(complement))
            {
                return new int[] { seen[complement], i};
            }

            if (!seen.ContainsKey(nums[i]))
            {
                seen[nums[i]] = i;
            }
        }

        throw new ArgumentException("No solution found");
    }

}