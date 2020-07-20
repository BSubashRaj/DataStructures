
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static void Display<T>(List<T> list)
        {
            var length = list.Count;
            Console.Write("[");
            for (var i = 0; i < length - 1; i++)
            {
                Console.Write($"{list[i]}, ");
            }
            if (length == 0)
                Console.WriteLine("]");
            else
                Console.WriteLine($"{list[length - 1]}]");
        }
    }
}
