using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        { 
            MaxHeap<int> heap1 = new MaxHeap<int>();

            heap1.Add(4);
            heap1.Add(3);
            heap1.Add(2);
            heap1.Add(1);
            heap1.Add(5);
            heap1.Add(9);
            heap1.Add(1000);
            heap1.Add(277);
            heap1.Add(9);
            heap1.Add(0);
            heap1.Add(88);
            heap1.Add(9999);
            heap1.Add(77);
            heap1.Add(1);
            heap1.Add(0);
            Console.WriteLine(heap1.Count);

            Console.WriteLine(heap1.ExtractMax());

            

        }
    }
}

