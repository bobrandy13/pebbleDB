namespace Datastructures
{
    public class BTreeNode
    {
        public bool IsLeaf { get; set; }
	public List<long> Keys { get; set; } = []; 
	public List<long> Child_Pointers { get; set; } = [];
    }

    public class BPlusTree
    {
	    public void Insert(ref BTreeNode root, BTreeNode node_to_insert) {
		    if (root == null) {
		    }

			// perform balancing algorithm


			// write the affected nodes back to the file; 
			WriteNodeToFile("", node_to_insert); 

		    return; 
	    }

	    public void Remove(ref BTreeNode root, BTreeNode node_to_remove) {


			WriteNodeToFile("", node_to_remove); 
            return; 
	    }

	    public long Search(long key, BTreeNode root) {

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

	    public void SplitChild(BTreeNode Node) {
			var Node_a = new BTreeNode();
			var Node_b = new BTreeNode();

			WriteNodeToFile("", Node_a);
			WriteNodeToFile("", Node_b);

            return; 
	    }

	    public void MergeNode(BTreeNode Node_A, BTreeNode Node_B) {
		    return;
	    }

	    public void Display(BTreeNode root) {
	    }


	    // Write each node that is the size of a block to filepath
	    public void WriteNodeToFile(string filePath, BTreeNode node) {
		    File.WriteAllText(filePath, "");
			return; 
	    }

	    public List<BTreeNode> ReadNodes(string filePath) {

		    string readText = File.ReadAllText(filePath);

            // TODO: Do some processing to convert the string to a list of BTreeNodes

            return []; 

        }

    }
}
