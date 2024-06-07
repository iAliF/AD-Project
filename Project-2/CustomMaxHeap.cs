using System;
using Heap;

namespace Project_2
{
    public class CustomMaxHeap : MaxHeap<Person>
    {
        public CustomMaxHeap(Person[] array, int maxSize = DefaultMaxSize) : base(array, maxSize)
        {
        }

        public new static CustomMaxHeap BuildMaxHeap(Person[] array)
        {
            var heap = new CustomMaxHeap(array);
            for (var i = array.Length / 2; i >= 0; i--)
                heap.MaxHeapify(i);
            return heap;
        }

        public void IncreaseSkillLevel(int index, char skillLevel)
        {
            var newP = new Person(_array[index].Age, skillLevel);
            IncreaseKey(index, newP);
        }

        public void FindAndIncrease(Person p, char skillLevel)
        {
            var index = Array.FindIndex(_array, row => row.CompareTo(p) == 0);
            IncreaseSkillLevel(index, skillLevel);
        }
    }
}