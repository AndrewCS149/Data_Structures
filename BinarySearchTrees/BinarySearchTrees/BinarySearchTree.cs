using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees
{
    internal class BinarySearchTree
    {
        public Node Root { get; set; }
        public int Count { get; set; } = 0;

        public void Insert(params int[] values)
        {
            Array.ForEach(values, val => Insert(val));
        }

        public void Insert(int value)
        {
            Node newNode = new Node(value);
            if (Count++ == 0)
            {
                Root = newNode;
            }
            else
            {
                Insert(Root, newNode);
            }
        }

        public void Insert(Node root, Node newNode)
        {
            if (newNode.Value == root.Value) return;

            if (newNode.Value < root.Value)
            {
                if (root.LeftChild == null)
                    root.LeftChild = newNode;
                else
                    Insert(root.LeftChild, newNode);
            }
            else
            {
                if (root.RightChild == null)
                    root.RightChild = newNode;
                else
                    Insert(root.RightChild, newNode);
            }
        }

        public void PrintInOrder()
        {
            if (Count == 0) return;

            Stack<Node> stack = new Stack<Node>();
            stack.Push(Root);
            while (stack.Count > 0)
            {
                Node tmp = stack.Pop();
                if (tmp.RightChild != null)
                {
                    stack.Push(tmp.RightChild);
                }

                if (tmp.LeftChild != null)
                {
                    stack.Push(tmp.LeftChild);
                }

                Console.Write(tmp.Value + " - ");
            }

            Console.WriteLine();
        }
    }
}
