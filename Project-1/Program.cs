using System;
using Heap;

namespace Project_1
{
    internal static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Project 1");

            /*var root = new Node(23);
            var bst = new BinarySearchTree(root);
            var nums = new[] { 11, 21, 24, 56, 3, 7, 22, 51 };
            foreach (var num in nums)
                bst.InsertNode(num);

            bst.Print();
            bst.SearchAndDeleteNode(22);
            bst.Print();
            var nodes = bst.LargestNodes(4);
            foreach (var node in nodes) Console.Write($"{node.Key} ");*/

            var arr = new[] { 1, 2, 7, 6, 22, 3, 4 };
            var heap = MaxHeap<int>.BuildMaxHeap(arr);
            Console.WriteLine(heap.ExtractMaximum());
            Console.WriteLine(heap.ExtractMaximum());
            Console.WriteLine(heap.ExtractMaximum());
            heap.Insert(27);
            heap.Insert(11);
            Console.WriteLine(heap.ExtractMaximum());

            Console.Read();
        }
    }
}