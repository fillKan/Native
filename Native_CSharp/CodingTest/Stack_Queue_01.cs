using System;
using System.Collections.Generic;
using System.Text;

namespace Native_CSharp.CodingTest
{
    class Stack_Queue_01
    {
        public class Truck
        {
            public int Weight;
            public int Time;

            public Truck(int weight)
            {
                Weight = weight;
                Time = 0;
            }
        }
        public void TimeUpdate(ref int answer, Queue<Truck> onBridge, int bridge_length, ref int weightSum)
        {
            bool dequeueAble = false;
            answer++;

            foreach (var item in onBridge)
            {
                if (item.Time++ == bridge_length)
                {
                    weightSum -= item.Weight;
                    dequeueAble = true;
                }
            }
            if (dequeueAble)
            {
                onBridge.Dequeue();
            }
        }
        public int Solution(int bridge_length, int weight, int[] truck_weights)
        {
            int answer = 0;
            int weightSum = 0;

            Queue<Truck> waiting = new Queue<Truck>();
            Queue<Truck> onBridge = new Queue<Truck>();

            for (int i = 0; i < truck_weights.Length; i++)
            {
                waiting.Enqueue(new Truck(truck_weights[i]));
            }
            do
            {
                while (waiting.Count > 0)
                {
                    bool dequeueAble = false;

                    foreach (var item in onBridge)
                    {
                        if (item.Time == bridge_length)
                        {
                            weightSum -= item.Weight;
                            dequeueAble = true;
                        }
                    }
                    if (dequeueAble)
                    {
                        onBridge.Dequeue();
                    }
                    if (waiting.Peek().Weight + weightSum <= weight)
                    {
                        var truck = waiting.Dequeue();
                        onBridge.Enqueue(truck);
                        weightSum += truck.Weight;

                        if (waiting.Count == 0)
                            break;
                    }
                    TimeUpdate(ref answer, onBridge, bridge_length, ref weightSum);
                }
                TimeUpdate(ref answer, onBridge, bridge_length, ref weightSum);

            } while (waiting.Count > 0 || onBridge.Count > 0);

            return answer;
        }
    }
}
