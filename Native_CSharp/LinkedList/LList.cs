using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Native_CSharp.LinkedList
{
    class LList<T>
    {
        public LLNode<T> First
        { get; private set; }

        public LLNode<T> Last
        { get; private set; }

        public int Length
        { get; private set; }

        public LLNode<T> this[int index]
        {
            get
            {
                if (index >= Length)
                    throw new IndexOutOfRangeException();

                var node = First;
                for (int i = 0; i < index && node != null; i++) 
                {
                    node = node.NextNode;
                }
                return node;
            }
        }
        public LList()
        {
            First = null;
            Last  = null;

            Length = 0;
        }
        public T At(int index)
        {
            return this[index].Value;
        }
        public void AddLast(T value)
        {
            if (Last == null) 
            {
                Last = new LLNode<T>(value);
                First ??= Last;
            }
            else
            {
                Last.NextNode = new LLNode<T>(value, Last, null);
                Last = Last.NextNode;
            }
            Length++;
        }
        public void AddFirst(T value)
        {
            if (First == null)
            {
                First = new LLNode<T>(value);
                Last ??= First;
            }
            else
            {
                First.PrevNode = new LLNode<T>(value, null, First);
                First = First.PrevNode;
            }
            Length++;
        }
        public void Insert(T value, int index)
        {
            if (index < 0 || index >= Length) return;

            LLNode<T> nNode = this[index];
            LLNode<T> pNode = nNode.PrevNode;

            LLNode<T> node = new LLNode<T>(value, pNode, nNode);
            pNode.NextNode = node;
            nNode.PrevNode = node;

            Length++;
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Length) return;

            LLNode<T> node = this[index];

            if (node.PrevNode != null)
                node.PrevNode.NextNode = node.NextNode;
            if (node.NextNode != null)
                node.NextNode.PrevNode = node.PrevNode;

            if (Last.Equals(node)) {
                Last = node.PrevNode;
            }
            else if (First.Equals(node)) {
                First = node.NextNode;
            }
            Length--;
        }
        public T RemoveFirst()
        {
            if (First.NextNode != null)
            {
                First.NextNode.PrevNode = null;
                First = First.NextNode;
            }
            Length--;
            return First.Value;
        }
        public T RemoveLast()
        {
            if (Last.PrevNode != null)
            {
                Last.PrevNode.NextNode = null;
                Last = Last.PrevNode;
            }
            Length--;
            return Last.Value;
        }
    }
}
