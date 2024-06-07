using System;

namespace Heap
{
    public class MaxHeap<TType> where TType : IComparable
    {
        public const int DefaultMaxSize = 100;
        protected readonly TType[] _array;
        private readonly int _maxSize;

        private int _heapSize;

        public MaxHeap(TType[] array, int maxSize = DefaultMaxSize)
        {
            _maxSize = maxSize;
            _heapSize = array.Length;

            _array = new TType[maxSize];
            array.CopyTo(_array, 0);
        }

        public void MaxHeapify(int i)
        {
            var left = Left(i);
            var right = Right(i);
            int largest;

            if (_heapSize > left && _array[left].CompareTo(_array[i]) >= 0)
                largest = left;
            else
                largest = i;
            if (_heapSize > right && _array[right].CompareTo(_array[largest]) >= 0)
                largest = right;

            if (largest != i)
            {
                (_array[largest], _array[i]) = (_array[i], _array[largest]);
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

            return _array[0];
        }

        public TType ExtractMaximum()
        {
            var max = Maximum();
            _array[0] = _array[_heapSize - 1];
            _heapSize -= 1;
            MaxHeapify(0);
            return max;
        }

        public void IncreaseKey(int index, TType key)
        {
            if (key.CompareTo(_array[index]) < 0)
                throw new Exception("New key is smaller than current key");

            _array[index] = key;

            while (index >= 0 && _array[Parent(index)].CompareTo(_array[index]) < 0)
            {
                (_array[Parent(index)], _array[index]) = (_array[index], _array[Parent(index)]);
                index = Parent(index);
            }
        }

        public void Insert(TType x)
        {
            if (_heapSize == _maxSize - 1)
                throw new Exception("Heap overflow");

            _array[_heapSize] = x;
            _heapSize += 1;

            var index = _heapSize - 1;
            while (index >= 0 && _array[Parent(index)].CompareTo(_array[index]) < 0)
            {
                (_array[Parent(index)], _array[index]) = (_array[index], _array[Parent(index)]);
                index = Parent(index);
            }
        }

        public int Parent(int i)
        {
            return (i - 1) / 2;
        }

        public int Left(int i)
        {
            return 2 * i + 1;
        }

        public int Right(int i)
        {
            return 2 * i + 2;
        }
    }
}