using System;
using System.Collections.Generic;
using System.Text;

namespace Native_CSharp.CodingTest
{
    class Stack_Queue_03
    {
        public int Solution(int[] priorities, int location)
        {
            int answer = 0;
            Queue<int> values = new Queue<int>(priorities);

            int[] temp = new int[priorities.Length];
            priorities.CopyTo(temp, 0);
            
            //
            for (int i = 0; i < temp.Length; i++)
            {
                for (int j = 0; j < temp.Length; j++)
                {
                    if (temp[i] > temp[j])
                    {
                        int t = temp[i];
                        temp[i] = temp[j];
                        temp[j] = t;
                    }
                }
            }
            //
            Queue<int> rank = new Queue<int>(temp);
            // 1, 1, 9, 1, 1, 1
            while (rank.Count > 0)
            {
                if (rank.Peek() != values.Peek())
                {
                    values.Enqueue(values.Dequeue());

                    if (location == 0) {
                        location = values.Count - 1;
                    }
                    else
                        location--;
                }
                else
                {
                    rank.Dequeue();
                    values.Dequeue();

                    answer++;

                    if (location == 0) {
                        break;
                    }
                    location--;
                }
            }
            return answer;
        }
    }
}
