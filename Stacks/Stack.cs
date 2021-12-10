using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stacks
{
    internal class Stack
    {
        public int Count { get; set; } = 0;
        public Node Top { get; set; }

        public bool Contains(int value)
        {
            Node current = Top;
            while (current != null)
            {
                if (current.Value == value)
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }
        public int Pop()
        {
            int topValue = Top.Value;
            Top = Top.Next;
            return topValue;
        }

        public int Peek()
        {
            return Top.Value;
        }

        public void Push(params int[] values)
        {
            Array.ForEach(values, val => Push(val));
        }
        public void Push(int value)
        {
            Count++;
            Node newNode = new Node(value);

            if (Top == null)
            {
                Top = newNode;
                return;
            }

            newNode.Next = Top;
            Top = newNode;
        }

        public void Print()
        {
            if (Count == 0) return;

            Node current = Top;
            while (current != null)
            {
                Console.Write(current.Value + " - ");
                current = current.Next;
            }

            Console.WriteLine();
        }
    }
}
