using System;

namespace Heap
{
    public class MaxHeap<TType> where TType : IComparable
    {
        protected const int DefaultMaxSize = 100;
        private readonly int _maxSize;
        protected readonly TType[] Array;

        private int _heapSize;

        public MaxHeap(TType[] array, int maxSize = DefaultMaxSize)
        {
            _maxSize = maxSize;
            _heapSize = array.Length;

            Array = new TType[maxSize];
            array.CopyTo(Array, 0);
        }

        public void MaxHeapify(int i)
        {
            var left = Left(i);
            var right = Right(i);
            int largest;

            if (_heapSize > left && Array[left].CompareTo(Array[i]) >= 0)
                largest = left;
            else
                largest = i;
            if (_heapSize > right && Array[right].CompareTo(Array[largest]) >= 0)
                largest = right;

            if (largest != i)
            {
                (Array[largest], Array[i]) = (Array[i], Array[largest]);
                MaxHeapify(largest);
            }
        }

        public static MaxHeap<TType> BuildMaxHeap(TType[] array)
        {
            var heap = new MaxHeap<TType>(array);
            for (var i = array.Length / 2; i >= 0; i--)
                heap.MaxHeapify(i);
            return heap;
        }

        public TType Maximum()
        {
            if (_heapSize < 1)
                throw new Exception("Heap underflow");

            return Array[0];
        }

        public TType ExtractMaximum()
        {
            var max = Maximum();
            Array[0] = Array[_heapSize - 1];
            _heapSize -= 1;
            MaxHeapify(0);
            return max;
        }

        public void IncreaseKey(int index, TType key)
        {
            if (key.CompareTo(Array[index]) < 0)
                throw new Exception("New key is smaller than current key");

            Array[index] = key;

            while (index >= 0 && Array[Parent(index)].CompareTo(Array[index]) < 0)
            {
                (Array[Parent(index)], Array[index]) = (Array[index], Array[Parent(index)]);
                index = Parent(index);
            }
        }

        public void Insert(TType x)
        {
            if (_heapSize == _maxSize - 1)
                throw new Exception("Heap overflow");

            Array[_heapSize] = x;
            _heapSize += 1;

            var index = _heapSize - 1;
            while (index >= 0 && Array[Parent(index)].CompareTo(Array[index]) < 0)
            {
                (Array[Parent(index)], Array[index]) = (Array[index], Array[Parent(index)]);
                index = Parent(index);
            }
        }

        public void Print()
        {
            for (var i = 0; i < _heapSize; i++)
                Console.WriteLine($"{i + 1}. {Array[i]}");
        }

        private static int Parent(int i)
        {
            return (i - 1) / 2;
        }

        private static int Left(int i)
        {
            return 2 * i + 1;
        }

        private static int Right(int i)
        {
            return 2 * i + 2;
        }
    }
}