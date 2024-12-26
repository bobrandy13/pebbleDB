namespace Datastructures
{

    public class BTreeNode
    {
        public bool IsLeaf { get; set; }
        public int MaxKeys { get; set; } // Maximum keys this node can hold
        public List<long> Keys { get; set; } = new List<long>();
        public List<long> Values { get; set; } = new List<long>(); // For leaf nodes
        public List<BTreeNode> Child_Pointers { get; set; } = new List<BTreeNode>(); // For internal nodes
        public long? NextLeafPointer { get; set; } = null; // For leaf nodes
    }


    public class BPlusTree
    {
        readonly static int MIN_DEGREE = 3;
        readonly static int MAX_DEGREE = 2 * MIN_DEGREE - 1;

        public void Insert(ref BTreeNode root, long key, long value)
        {
            if (root == null)
            {
                var leaf_node = new BTreeNode();

                root = leaf_node;
                root.IsLeaf = true;
                root.Keys.Add(key);
                root.Values.Add(value);

                return;
            }
            else if (root.Keys.Count < MAX_DEGREE)
            {
                // If the root is not full 
                root.Keys.Add(key);
                return;
            }
            else
            {
                // Perform the 
                SplitChild(root);
            }


            for (int i = 0; i < root.Keys.Count; i++)
            {
                if (key < root.Keys[i])
                {
                    var child = root.Child_Pointers[i];
                    Insert(ref child, key, value);
                    root.Child_Pointers[i] = child;
                    return;
                }
            }

            return;
        }

        public bool SearchForLeaf(ref BTreeNode root, long key)
        {
            for (int i = 0; i < root.Keys.Count; i++)
            {
                if (root.IsLeaf)
                {
                    return true;
                }
                if (key < root.Keys[i])
                {
                    var child = root.Child_Pointers[i];
                    SearchForLeaf(ref child, key);
                }
            }
            return false; 
        }

        public void Remove(ref BTreeNode root, BTreeNode node_to_remove)
        {
            WriteNodeToFile("", node_to_remove);
            return;
        }

        public long Search(long key, BTreeNode root)
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

        public void SplitChild(BTreeNode Node)
        {
            var Node_a = new BTreeNode();
            var Node_b = new BTreeNode();

            WriteNodeToFile("", Node_a);
            WriteNodeToFile("", Node_b);

            return;
        }

        public void MergeNode(BTreeNode Node_A, BTreeNode Node_B)
        {
            return;
        }

        public void Display(BTreeNode root)
        {
        }


        // Write each node that is the size of a block to filepath
        public void WriteNodeToFile(string filePath, BTreeNode node)
        {
            File.WriteAllText(filePath, "");
            return;
        }

        public List<BTreeNode> ReadNodes(string filePath)
        {

            string readText = File.ReadAllText(filePath);

            // TODO: Do some processing to convert the string to a list of BTreeNodes

            return new List<BTreeNode>();

        }

    }
}
