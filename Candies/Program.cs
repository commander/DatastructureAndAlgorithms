using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    // Complete the candies function below.
    static long Candies(int n, int[] arr)
    {
        long[] candyCount = new long[arr.Length];

        // initialize with 1
        for(int i = 0; i < candyCount.Length; i++)
        {
            candyCount[i] = 1;
        }

        // if the j th child has more rating then j-1 th child, give them more
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > arr[i - 1])
            {
                candyCount[i] = candyCount[i - 1] + 1;
            }
        }

        // if j the child has more rating then the j+1 the child, give them more
        for (int i = arr.Length - 2; i >= 0; i--)
        {
            if (arr[i] > arr[i + 1] && candyCount[i] <= candyCount[i + 1])
            {
                candyCount[i] = candyCount[i + 1] + 1;
            }
        }
        return candyCount.Sum();
    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        string[] t = File.ReadAllLines("input12.txt");
        int n = Convert.ToInt32(t[0]);

        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
        {
            int arrItem = Convert.ToInt32(t[i+1]);
            arr[i] = arrItem;
        }

        long result = Candies(n, arr);

        Console.WriteLine(result);
    }
}
