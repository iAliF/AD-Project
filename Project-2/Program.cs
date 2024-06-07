using System;

namespace Project_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Project 2");

            var a = new Person(25, 'A');

            var c = CustomMaxHeap.BuildMaxHeap(
                new[]
                {
                    new Person(25, 'D'),
                    new Person(25, 'B'),
                    new Person(24, 'D'),
                    a
                });

            Console.WriteLine(c.ExtractMaximum());
            c.FindAndIncrease(a, 'F');
            Console.WriteLine(c.ExtractMaximum());
            Console.WriteLine(c.ExtractMaximum());
            Console.WriteLine(c.ExtractMaximum());

            Console.ReadKey();
        }
    }
}