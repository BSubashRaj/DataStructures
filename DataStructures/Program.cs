using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new Array<int>(5);
            array.Insert(1);
            array.Insert(2);
            array.Insert(3);
            array.Insert(4);
            array.Insert(5);
            array.Insert(6);
            array.Insert(1);
            array.Insert(2);
            array.Insert(3);
            array.Insert(4);
            array.Insert(5);
            array.Insert(6);
            array.Insert(7);
            Console.WriteLine(array);
            Console.WriteLine(array.Size());
            Console.WriteLine(array.Capacity);
            array.RemoveAtIndex(6);
            array.RemoveAtIndex(11);
            Console.WriteLine(array);
            Console.WriteLine(array.Size());
            Console.WriteLine(array.Capacity);
            array.RemoveAtIndex(1);
            array.RemoveAtIndex(1);
            array.RemoveAtIndex(1);
            array.RemoveAtIndex(1);
            Console.WriteLine(array);
            Console.WriteLine(array.Size());
            Console.WriteLine(array.Capacity);
            Console.WriteLine(array.LastIndexOf(12));
            Console.WriteLine(array.Find(a => a == 5));
            array.ForEach((ole) =>
            {
                Console.WriteLine(ole);
            });
            Console.WriteLine(array.Contains(7));
        }
    }
}
