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

    // Complete the freqQuery function below.
    static List<int> freqQuery(List<List<int>> queries)
    {
        Dictionary<long, int> numbersWithFrequencies = new Dictionary<long, int>();
        Dictionary<int, int> frequencyCount = new Dictionary<int, int>();
        List<int> output = new List<int>();
        for (int i = 0; i < queries.Count; i++)
        {
            int currentFrequency = 0;
            int newFrequency = 0;
            if (queries[i][0] == 1)
            {
                if (numbersWithFrequencies.ContainsKey(queries[i][1]))
                {
                    currentFrequency = numbersWithFrequencies[queries[i][1]];
                    newFrequency = currentFrequency + 1;

                    numbersWithFrequencies[queries[i][1]] = newFrequency;
                }
                else
                {
                    numbersWithFrequencies.Add(queries[i][1], 1);
                    newFrequency = 1;
                }
            }

            if (queries[i][0] == 2)
            {
                if (numbersWithFrequencies.ContainsKey(queries[i][1]))
                {
                    currentFrequency = numbersWithFrequencies[queries[i][1]];
                    newFrequency = currentFrequency - 1;

                    if(newFrequency == 0)
                    {
                        numbersWithFrequencies.Remove(queries[i][1]);
                    } else
                    {
                        numbersWithFrequencies[queries[i][1]] = newFrequency;
                    }
                }
            }

            if (frequencyCount.ContainsKey(newFrequency))
            {
                frequencyCount[newFrequency] += 1;
            }
            else
            {
                frequencyCount.Add(newFrequency, 1);
            }

            if (frequencyCount.ContainsKey(currentFrequency))
            {
                frequencyCount[currentFrequency] -= 1;
            }
            else
            {
                frequencyCount.Add(currentFrequency, 1);
            }

            if (queries[i][0] == 3)
            {
                if (frequencyCount.TryGetValue(queries[i][1], out int frequency))
                {
                    if(frequency > 0)
                    {
                        Console.WriteLine($"Frequency matched: {queries[i][1]}");
                        output.Add(1);
                    }
                    else
                    {
                        output.Add(0);
                    }   
                }
                else
                {
                    output.Add(0);
                }
            }
        }
        return output;
    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        string[] input = File.ReadAllLines("testcase_8.txt");
        //int q = Convert.ToInt32(Console.ReadLine().Trim());
        int q = Convert.ToInt32(input[0].Trim());
        List<List<int>> queries = new List<List<int>>();

        for (int i = 0; i < q; i++)
        {
            //queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
            queries.Add(input[i].TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
        }

        List<int> ans = freqQuery(queries);

        //textWriter.WriteLine(String.Join("\n", ans));

        //textWriter.Flush();
        //textWriter.Close();
        Console.WriteLine($"1: {ans.Count(x => x == 1)}, 0: {ans.Count(x => x == 0)}");
        //Console.WriteLine(String.Join("\n", ans));
        Console.Read();
    }
}
