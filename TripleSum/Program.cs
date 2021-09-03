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

    // Complete the triplets function below.
    static long triplets(int[] a, int[] b, int[] c)
    {
        List<int> aa = (new SortedSet<int>(a)).ToList();
        List<int> bb = (new SortedSet<int>(b)).ToList();
        List<int> cc = (new SortedSet<int>(c)).ToList();

        // aa.ForEach(x => Console.Write(x + ", "));
        // Console.WriteLine();

        // bb.ForEach(x => Console.Write(x + ", "));
        // Console.WriteLine();

        // cc.ForEach(x => Console.Write(x + ", "));
        // Console.WriteLine();

        int ai = 0, bi = 0, ci = 0;
        long answer = 0;

        while (bi < bb.Count)
        {
            while (ai < aa.Count && aa[ai] <= bb[bi])
            {
                ai++;
            }

            while (ci < cc.Count && cc[ci] <= bb[bi])
            {
                ci++;
            }

            answer += ((long)ai * (long)ci);
            bi++;
        }

        return answer;
        // Array.Sort(a);
        // Array.Sort(b);
        // Array.Sort(c);
        // long count = 0;
        // Dictionary<string, int> seen = new Dictionary<string, int>();
        // for(int i = 0; i < a.Length; i++) {
        //     for(int j = 0; j < c.Length; j++) {
        //         for(int k = 0; k < b.Length; k++) {

        //             // Console.WriteLine("{0}, {1}, {2}", a[i], b[k], c[j]);
        //             if(b[k] >= c[j] && b[k] >= a[i]) {
        //                 // Console.WriteLine("b[k] is greater than both a[i] and c[j]");    
        //                 var v = a[i]+"-"+b[k]+"-"+c[j];
        //                 if(seen.ContainsKey(v)) {
        //                     continue;
        //                 } else {
        //                 count++;
        //                 seen.Add(v, a[i] + b[k] + c[j]); 
        //                 }
        //             }
        //         }
        //     }
        // }
        // return count;
    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        string[] t = File.ReadAllLines("input04.txt");

        string[] lenaLenbLenc = t[0].Split(' ');

        int lena = Convert.ToInt32(lenaLenbLenc[0]);

        int lenb = Convert.ToInt32(lenaLenbLenc[1]);

        int lenc = Convert.ToInt32(lenaLenbLenc[2]);

        int[] arra = Array.ConvertAll(t[1].Split(' '), arraTemp => Convert.ToInt32(arraTemp))
        ;

        int[] arrb = Array.ConvertAll(t[2].Split(' '), arrbTemp => Convert.ToInt32(arrbTemp))
        ;

        int[] arrc = Array.ConvertAll(t[3].Split(' '), arrcTemp => Convert.ToInt32(arrcTemp))
        ;
        long ans = triplets(arra, arrb, arrc);

        //textWriter.WriteLine(ans);

        //textWriter.Flush();
        //textWriter.Close();
        Console.WriteLine(ans);
    }
}
