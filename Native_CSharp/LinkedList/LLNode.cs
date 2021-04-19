using System;
using System.Collections.Generic;
using System.Text;

namespace Native_CSharp.LinkedList
{
    class LLNode<T>
    {
        public T Value;

        public LLNode<T> NextNode;
        public LLNode<T> PrevNode;

        public LLNode()
        {
            NextNode = null;
            PrevNode = null;
        }
        public LLNode(T value)
        {
            Value = value;

            NextNode = null;
            PrevNode = null;
        }
        public LLNode(LLNode<T> prev, LLNode<T> next)
        {
            PrevNode = prev;
            NextNode = next;
        }
        public LLNode(T value, LLNode<T> prev, LLNode<T> next)
        {
            Value = value;

            PrevNode = prev;
            NextNode = next;
        }
    }
}
