using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    public string solution(string[] A, string[] B, string P)
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        SortedDictionary<string, string> names = new SortedDictionary<string, string>();
        for(int i = 0; i < B.Length; i++)
        {
            if(B[i].Contains(P))
            {
                names.Add(A[i], A[i]);
            }
        }

        if(names.Count > 0)
        {
            List<string> keys = names.Keys.ToList();
            return names[keys[0]];
        }
        else
        {
            return "No Contact";
        }
    }
}

//class Solution
//{
//    string[] months = new string[] {"January", "February", "March", "April", "May", "June",
//        "July", "August", "September", "October", "November", "December"};

//    int[] monthDays = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
//    public int solution(int Y, string A, string B, string W)
//    {
//        return 0;
//    }
//}

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
