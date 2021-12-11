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

        public int Max(Node root)
        {
            return root.RightChild != null ? Max(root.RightChild) : root.Value;
        }

        public int Min(Node root)
        {
            return root.LeftChild != null ? Min(root.LeftChild) : root.Value;
        }

        public void Remove(int value)
        {
            if (Count == 0) return;
            Remove(Root, value);
        }

        public Node Remove(Node root, int value)
        {
            if (value < root.Value)
            {
                root.LeftChild = Remove(root.LeftChild, value);
            }
            else if (value > root.Value)
            {
                root.RightChild = Remove(root.RightChild, value);
            }
            else
            {
                Count--;
                if (root.LeftChild == null && root.RightChild == null)
                {
                    root = null;
                }
                else if (root.LeftChild == null)
                {
                    root = root.RightChild;
                }
                else if (root.RightChild == null)
                {
                    root = root.LeftChild;
                }
                else
                {
                    int max = Max(root.LeftChild);
                    root.Value = max;
                    root.LeftChild = Remove(root.LeftChild, max);
                }
            }

            return root;
        }

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

        public void PrintInOrderRecursive()
        {
            if (Count == 0) return;
            PrintInOrderRecursive(Root);
            Console.WriteLine();
        }
        public void PrintInOrderRecursive(Node root)
        {
            if (root.LeftChild != null)
            {
                PrintInOrderRecursive(root.LeftChild);
            }

            Console.Write(root.Value + " - ");

            if (root.RightChild != null)
            {
                PrintInOrderRecursive(root.RightChild);
            }
        }

        public void PrintPostOrderRecursive()
        {
            if (Count == 0) return;

            PrintPostOrderRecursive(Root);
            Console.WriteLine();
        }
        private void PrintPostOrderRecursive(Node root)
        {
            if (root.LeftChild != null)
            {
                PrintPostOrderRecursive(root.LeftChild);
            }

            if (root.RightChild != null)
            {
                PrintPostOrderRecursive(root.RightChild);
            }

            Console.Write(root.Value + " - ");
        }


        public void PrintPreOrderRecursive()
        {
            if (Count == 0) return;

            PrintPreOrderRecursive(Root);
            Console.WriteLine();
        }
        private void PrintPreOrderRecursive(Node root)
        {
            Console.Write(root.Value + " - ");

            if (root.LeftChild != null)
            {
                PrintPreOrderRecursive(root.LeftChild);
            }

            if (root.RightChild != null)
            {
                PrintPreOrderRecursive(root.RightChild);
            }
        }


        public void PrintInOrderIterative()
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
