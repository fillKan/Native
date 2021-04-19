using System;
using System.Collections.Generic;
using Native_CSharp.LinkedList;
using Native_CSharp.CodingTest;

namespace Native_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var sq = new Stack_Queue_01();

            Console.WriteLine("Case 1:"); // 8
            Console.WriteLine(sq.Solution(2, 10, new int[4] { 7, 4, 5, 6 }));

            Console.WriteLine("Case 2:"); // 101
            Console.WriteLine(sq.Solution(100, 100, new int[1] { 10 }));

            Console.WriteLine("Case 3:"); // 110
            Console.WriteLine(sq.Solution(100, 100, new int[10] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }));
        }
    }
}
