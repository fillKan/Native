using System;
using System.Collections.Generic;
using System.Text;

namespace Native_CSharp.CodingTest
{
    class Stack_Queue_02
    {
        public int[] Solution(int[] prices)
        {
            int index = 0;
            var result = new Queue<int>();
            
            while (index < prices.Length)
            {
                int distance = 0;
                for (int i = index + 1; i < prices.Length; i++)
                {
                    distance++;

                    if (prices[index] > prices[i])
                        break;
                }
                result.Enqueue(distance);
                index++;
            }
            int[] answer = new int[prices.Length];

            for (int i = 0; i < prices.Length; i++)
                answer[i] = result.Dequeue();

            return answer;
        }
    }
}
