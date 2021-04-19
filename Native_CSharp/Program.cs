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
            var sq = new Stack_Queue_03();

            Console.WriteLine(sq.Solution(new int[6] { 1, 1, 9, 1, 1, 1 }, 0));
        }
    }
}
