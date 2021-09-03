using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class TernaryGraphPath
    {
        public static string[] TernaryTreePaths(Node root)
        {
            if (root == null)
            {
                return null;
            }
            var parents = new List<int>();
            var paths = new List<string>();

            Dfs(root, parents, paths);

            return paths.ToArray();
        }

        public static void Dfs(Node node, List<int> parents, List<string> paths)
        {
            if(node.Children[0] == null && node.Children[1] == null && node.Children[2] == null)
            {
                parents.Add(node.Val);
                paths.Add(string.Join("->", parents));
                return;
            }

            for(int i = 0; i < 3; i++)
            {
                if(node.Children[i] != null)
                {
                    List<int> parentsSoFar = new List<int>(parents);
                    parentsSoFar.Add(node.Val);
                    Dfs(node.Children[i], parentsSoFar, paths);
                }
            }


        }

        public static void Main(string[] args)
        {

            string[] inputs = { "1 2 5 x x x x x 3 x x x 4 x x x", "1 2 3 x x x 4 x x x 7 x x x 5 x x x 6 x x x" };
            for (int i = 0; i < inputs.Length; i++)
            {
                Node root = null;
                int start = 0;
                root = Node.BuildTree(root, inputs[i].Split(" "), ref start);
                Console.WriteLine("Ternary tree paths : " + String.Join(',', TernaryTreePaths(root)));
            }

        }
    }

    class Node
    {
        public int Val;
        public Node[] Children;

        public Node(int val, Node[] children)
        {
            this.Val = val;
            this.Children = children;
        }

        public static Node BuildTree(Node node, string[] nodes, ref int index)
        {
            if(nodes[index] == "x")
            {
                return null;
            }

            if(node == null)
            {
                node = new Node(int.Parse(nodes[index]), new Node[3]);
            }
            
            for(int j = 0; j < 3; j++)
            {
                index = index + 1;
                node.Children[j] = BuildTree(node.Children[j], nodes, ref index);
            }
            return node;
        }
    }
}
