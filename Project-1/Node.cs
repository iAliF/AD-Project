namespace Project_1
{
    public class Node
    {
        public readonly int Key;
        public Node Left;
        public Node Parent;
        public Node Right;

        public Node(int key = 0, Node parent = null, Node left = null, Node right = null)
        {
            Key = key;
            Parent = parent;
            Left = left;
            Right = right;
        }
    }
}