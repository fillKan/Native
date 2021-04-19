using System;
using System.Collections.Generic;
using System.Text;

namespace Native_CSharp.CodingTest
{
    class Stack_Queue_04
    {
        public int[] Solution(int[] progresses, int[] speeds)
        {
            Queue<int> taskes = new Queue<int>(progresses);
            Queue<int> result = new Queue<int>();

            int front = 0;
            while (taskes.Count > 0)
            {
                while (progresses[front] < 100)
                {
                    for (int i = front; i < progresses.Length; i++)
                    {
                        progresses[i] += speeds[i];
                    }
                }
                int resultCount = 0;
                for (int i = front; i < progresses.Length; i++)
                {
                    if (progresses[i] >= 100)
                    {
                        front++;
                        resultCount++;

                        taskes.Dequeue();
                    }
                    else break;
                }
                if (resultCount > 0)
                    result.Enqueue(resultCount);
            }
            int[] answer = new int[result.Count];

            for (int i = 0; i < answer.Length; i++)
                answer[i] = result.Dequeue();

            return answer;
        }
    }
}
