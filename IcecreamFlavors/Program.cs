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

    // Complete the whatFlavors function below.
    static void whatFlavors(int[] cost, int money)
    {
        Dictionary<int, int> costIndex = new Dictionary<int, int>();

        // for(int i = 0; i < cost.Length; i++) {
        //     List<int> value = null;
        //     if(costIndex.ContainsKey(cost[i])) {
        //         value = costIndex[cost[i]];
        //         value.Add(i + 1);
        //         costIndex[cost[i]] = value;
        //     } else {
        //         value = new List<int>();
        //         value.Add(i + 1);
        //         costIndex.Add(cost[i], value);
        //     }
        // }

        // Array.Sort(cost);

        for (int j = 0; j < cost.Length; j++)
        {
            // if(cost[j] >= money) {
            //     continue;
            // }
            // List<int> indexes = null;
            // int firstIndex = costIndex[cost[j]][0];
            //bool found = false;
            // Console.WriteLine(firstIndex);
            if (costIndex.ContainsKey(money - cost[j]))
            {
                // indexes = costIndex[money - cost[j]];
                // foreach(int k in indexes) {
                // if(k != firstIndex) {
                int k = costIndex[money - cost[j]];
                Console.WriteLine("{0} {1}", Math.Min(j + 1, k), Math.Max(j + 1, k));
                //found = true;
                break;
                // }
                // }
                // if(found) {
                //     break;
                // }
            }
            else
            {
                costIndex[cost[j]] =  j + 1;
            }
        }
    }

    static void Main(string[] args)
    {
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();
        string[] t = File.ReadAllLines("input_testcase13.txt");
        //int t = Convert.ToInt32(Console.ReadLine());
        int i = 0;
        for (int tItr = 1; tItr <= int.Parse(t[0]); tItr++)
        {
            int money = Convert.ToInt32(t[(i * 3) + 1]);

            int n = Convert.ToInt32(t[(i * 3) + 2]);

            int[] cost = Array.ConvertAll(t[(i * 3) + 3].Split(' '), costTemp => Convert.ToInt32(costTemp));
            whatFlavors(cost, money);
            i++;
        }

        watch.Stop();
        Console.WriteLine(watch.ElapsedMilliseconds);
    }
}
