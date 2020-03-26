using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Graph
{
    class FileReader
    {
        public static Tuple<int, List<int[]>> Read(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);

            int v = int.Parse(lines[0].Trim());
            int e = int.Parse(lines[1].Trim());

            List<int[]> edges = new List<int[]>();

            for (int i = 2; i < lines.Length; i++)
            {
                string[] points = lines[i].Trim().Split(' ');
                edges.Add(new int[] { int.Parse(points[0].Trim()), int.Parse(points[1].Trim()) });
            }

            return new Tuple<int, List<int[]>>(v, edges);
        }
    }
}
