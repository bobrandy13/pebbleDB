using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Transactions;

namespace Datastructures
{

    public class Node(Node? left, Node? right, long key, long value, bool isLeaf)
    {
        public bool IsLeaf = isLeaf;
        public long Key = key;
        public long Value = value;


        public Node? Left = left;
        public Node? Right = right;
    }

    public class Tree
    {
        private int GetBalanceFactor(Node? node)
        {

            if (node == null) return 0;

            return GetBalanceFactor(node.Left) - GetBalanceFactor(node.Right);

        }

        public Node Insert(ref Node? root, long key, long value)
        {
            if (root == null)
            {
                return new Node(null, null, key, value, true);
            }
            else if (root.Key < key)
            {
                root.Left = Insert(ref root.Left, key, value);
            }
            else
            {
                root.Right = Insert(ref root.Right, key, value);
            }

            // Perform balancing operations 

            var balance_factor = this.GetBalanceFactor(root);

            if (balance_factor < -1)
            {
                // left leaning
                if (key < root.Left.Key)
                {
                    return this.RightRotate(ref root);
                }

            }
            else if (balance_factor > 1)
            {
                // right leaning
            }


            Console.WriteLine(balance_factor);

            return new Node(null, null, 45, 55, false);
        }

        public Node RightRotate(ref Node root)
        {

            return;
        }

        public void Remove(ref Node root, Node node_to_remove)
        {
            WriteNodeToFile("", node_to_remove);
            return;
        }

        public long Search(long key, Node root)
        {

            // we need to do some traversal; 

            while (root != null)
            {

                if (root.Equals(key))
                {
                    return key;
                }
            }

            // perform searching algorithm
            return -1;
        }


        public void Display(Node root)
        {
        }


        // Write each node that is the size of a block to filepath
        public void WriteNodeToFile(string filePath, Node node)
        {
            File.WriteAllText(filePath, "");
            return;
        }

        public List<Node> ReadNodes(string filePath)
        {

            string readText = File.ReadAllText(filePath);

            // TODO: Do some processing to convert the string to a list of BTreeNodes

            return new List<Node>();

        }


        static void Main(string[] args)
        {
            Console.WriteLine("hello world");


        }


    }


}

