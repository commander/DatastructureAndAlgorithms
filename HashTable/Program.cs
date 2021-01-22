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

    // Complete the checkMagazine function below.
    static void checkMagazine(string[] magazine, string[] note)
    {
        Dictionary<string, int> magazineDict = new Dictionary<string, int>();
        foreach (string word in magazine)
        {
            if (!magazineDict.ContainsKey(word))
            {
                magazineDict.Add(word, 0);
            } else
            {
                var count = magazineDict[word];
                magazineDict[word] = ++count;
            }
        }

        bool no = false;
        foreach (string word in note)
        {
            if (magazineDict.TryGetValue(word, out int count))
            {
                if (count <= 0)
                {
                    no = true;
                    break;
                }
                else
                {
                    magazineDict[word] = --count;
                }
            }
            else
            {
                no = true;
                break;
            }
        }
        if (no)
        {
            Console.WriteLine("No");
        }
        else
        {
            Console.WriteLine("Yes");
        }
    }

    static void Main(string[] args)
    {
        string[] input = File.ReadAllLines("input.txt");
        string[] mn = input[0].Split(' '); //Console.ReadLine().Split(' ');

        int m = Convert.ToInt32(mn[0]);

        int n = Convert.ToInt32(mn[1]);

        string[] magazine = input[1].Split(' '); //Console.ReadLine().Split(' ');

        string[] note = input[2].Split(' '); // Console.ReadLine().Split(' ');

        checkMagazine(magazine, note);
    }
}
