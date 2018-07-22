using System;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = Utility.CreateTree();
            var level = Utility.GetLeve(tree, 4);
            Utility.GetLevelAndValue(tree, 1);
            Console.ReadLine();
        }
    }

    // Node class
    public class Node
    {
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    };

    public class Utility
    {
        /* Utility function to create a new Binary Tree node */
        public static Node CreateTree()
        {
            var root = new Node(3);

            root.Left = new Node(2);
            root.Right = new Node(5);
            root.Left.Left = new Node(1);
            root.Left.Right = new Node(4);

            return root; 
        }

        /* Helper function for getLevel().  It returns level of the data if data is
        present in tree, otherwise returns 0.*/
        public static int GetLevelUtil(Node node, int data, int level)
        {
            if (node == null)
                return 0;
 
            if (node.Value == data)
                return level;
 
            int downlevel = GetLevelUtil(node.Left, data, level + 1);
            if (downlevel != 0)
                return downlevel;
 
            downlevel = GetLevelUtil(node.Right, data, level+1);
            return downlevel;
        }

        /* Returns level of given data value */
        public static int GetLeve(Node node, int data)
        {
            return GetLevelUtil(node, data,1);
        }

        /* Helper function for getLevel().  It returns level of the data if data is
        present in tree, otherwise returns 0.*/
        public static void GetLevelAndValue(Node node, int level)
        {
            if (node == null)
                return;

            Console.WriteLine($"Node value: {node.Value}, level: {level}");
            GetLevelAndValue(node.Left, level + 1);
            GetLevelAndValue(node.Right, level + 1);
            return;
        }
    }
}
