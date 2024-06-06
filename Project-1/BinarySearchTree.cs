using System;
using System.Collections.Generic;

namespace Project_1
{
    public class BinarySearchTree
    {
        private Node _root;

        public BinarySearchTree()
        {
            _root = null;
        }

        public BinarySearchTree(int data)
        {
            _root = new Node(data);
        }

        public BinarySearchTree(Node root)
        {
            _root = root;
        }

        public Node MinimumNode(Node x)
        {
            while (x.Left != null)
                x = x.Left;

            return x;
        }

        public Node MaximumNode(Node x)
        {
            while (x.Right != null)
                x = x.Right;

            return x;
        }

        public Node SuccessorNode(Node x)
        {
            if (x.Right != null)
                return MinimumNode(x.Right);

            var y = x.Parent;
            while (y != null && x == y.Right)
            {
                x = y;
                y = y.Parent;
            }

            return y;
        }


        public Node PredecessorNode(Node x)
        {
            if (x.Left != null)
                return MaximumNode(x.Left);

            var y = x.Parent;
            while (y != null && x == y.Left)
            {
                x = y;
                y = y.Parent;
            }

            return y;
        }

        public Node SearchNode(int key)
        {
            var x = _root; // starts from root
            while (x != null && key != x.Key)
                if (key < x.Key)
                    x = x.Left;
                else
                    x = x.Right;

            return x;
        }


        public void InsertNode(int key)
        {
            InsertNode(new Node(key));
        }

        public void InsertNode(Node z)
        {
            var x = _root; // compared to Z
            Node y = null; // Will be parent of z

            while (x != null) // finding a leaf pos
            {
                y = x; // parent of x
                if (z.Key < x.Key)
                    x = x.Left;
                else
                    x = x.Right;
            }

            z.Parent = y;
            if (y == null)
                _root = z;
            else if (z.Key < y.Key)
                y.Left = z;
            else
                y.Right = z;
        }

        public void InsertNodes(List<Node> nodes)
        {
            foreach (var node in nodes)
                InsertNode(node);
        }

        public void TransplantNode(Node u, Node v)
        {
            if (u.Parent == null) // U is root
                _root = v;
            else if (u == u.Parent.Left) // is left child
                u.Parent.Left = v;
            else
                u.Parent.Right = v;

            if (v != null)
                v.Parent = u.Parent;
        }

        public void DeleteNode(Node z)
        {
            if (z.Left == null) // has no left child
            {
                TransplantNode(z, z.Right); // Replace by its right child
            }
            else if (z.Right == null)
            {
                TransplantNode(z, z.Left);
            }
            else
            {
                var y = MinimumNode(z.Right);
                if (y != z.Right)
                {
                    // Replace y by its right child
                    TransplantNode(y, y.Right);
                    y.Right = z.Right;
                    y.Right.Parent = y;
                }

                TransplantNode(z, y);
                y.Left = z.Left;
                y.Left.Parent = y;
            }
        }

        public void SearchAndDeleteNode(int key)
        {
            var node = SearchNode(key);
            if (node != null)
                DeleteNode(node);
        }

        public void Print()
        {
            Print(_root);
            Console.WriteLine();
        }

        public void Print(Node x)
        {
            if (x == null) return;
            Print(x.Left);
            Console.Write($"{x.Key} ");
            Print(x.Right);
        }

        public List<Node> FetchNodes()
        {
            return FetchNodes(_root);
        }

        public List<Node> FetchNodes(Node x)
        {
            var list = new List<Node>();
            if (x == null) return list;

            list.AddRange(FetchNodes(x.Left));
            list.Add(x);
            list.AddRange(FetchNodes(x.Right));
            return list;
        }

        public static BinarySearchTree MergeTrees(BinarySearchTree a, BinarySearchTree b)
        {
            var nodes = a.FetchNodes();
            nodes.AddRange(b.FetchNodes());

            var c = new BinarySearchTree();
            c.InsertNodes(nodes);
            return c;
        }
    }
}