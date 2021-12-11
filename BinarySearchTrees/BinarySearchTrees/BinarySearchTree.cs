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
            if (Count != 0)
                Remove(Root, value);
        }

        private Node Remove(Node root, int value)
        {
            if (value < root.Value)
                root.LeftChild = Remove(root.LeftChild, value);
            else if (value > root.Value)
                root.RightChild = Remove(root.RightChild, value);
            else
            {
                Count--;
                if (root.LeftChild == null && root.RightChild == null)
                    root = null;
                else if (root.LeftChild == null)
                    root = root.RightChild;
                else if (root.RightChild == null)
                    root = root.LeftChild;
                else
                {
                    int max = Max(root.LeftChild);
                    root.Value = max;
                    root.LeftChild = Remove(root.LeftChild, max);
                }
            }

            return root;
        }

        public void Insert(int value)
        {
            Node newNode = new Node(value);
            if (Count == 0)
            {
                Count++;
                Root = newNode;
            }
            else
                Insert(Root, newNode);
        }

        private void Insert(Node root, Node newNode)
        {
            if (newNode.Value < root.Value)
            {
                if (root.LeftChild == null)
                {
                    Count++;
                    root.LeftChild = newNode;
                }
                else
                    Insert(root.LeftChild, newNode);
            }
            else if (newNode.Value > root.Value)
            {
                if (root.RightChild == null)
                {
                    Count++;
                    root.RightChild = newNode;
                }
                else
                    Insert(root.RightChild, newNode);
            }
            else
                return;
        }

        public void Insert(params int[] values)
        {
            Array.ForEach(values, val => Insert(val));
        }

        public int Depth()
        {
            if (Count == 0) return -1;

            int depth = 0;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                Node tmp = queue.Dequeue();

                if (tmp.LeftChild != null || tmp.RightChild != null)
                    depth++;

                if (tmp.LeftChild != null)
                    queue.Enqueue(tmp.LeftChild);

                if (tmp.RightChild != null)
                    queue.Enqueue(tmp.RightChild);
            }

            return depth;
        }
        public bool Contains(int value)
        {
            if (Count == 0) return false;

            Stack<Node> stack = new Stack<Node>();
            stack.Push(Root);
            while (stack.Count > 0)
            {
                Node tmp = stack.Pop();

                if (tmp.Value == value)
                    return true;

                if (tmp.RightChild != null)
                    stack.Push(tmp.RightChild);

                if (tmp.LeftChild != null)
                    stack.Push(tmp.LeftChild);
            }

            return false;
        }

        public void PrintLevelOrder()
        {
            if (Count == 0) return;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                Node tmp = queue.Dequeue();
                Console.Write(tmp.Value + " - ");

                if (tmp.LeftChild != null)
                    queue.Enqueue(tmp.LeftChild);

                if (tmp.RightChild != null)
                    queue.Enqueue(tmp.RightChild);
            }

            Console.WriteLine();
        }



        public void PrintInOrderRecursive()
        {
            if (Count != 0)
                PrintInOrderRecursive(Root);

            Console.WriteLine();
        }
        private void PrintInOrderRecursive(Node root)
        {
            if (root.LeftChild != null)
                PrintInOrderRecursive(root.LeftChild);

            Console.Write(root.Value + " - ");

            if (root.RightChild != null)
                PrintInOrderRecursive(root.RightChild);
        }

        public void PrintPostOrderRecursive()
        {
            if (Count != 0)
                PrintPostOrderRecursive(Root);

            Console.WriteLine();
        }
        private void PrintPostOrderRecursive(Node root)
        {
            if (root.LeftChild != null)
                PrintPostOrderRecursive(root.LeftChild);

            if (root.RightChild != null)
                PrintPostOrderRecursive(root.RightChild);

            Console.Write(root.Value + " - ");
        }


        public void PrintPreOrderRecursive()
        {
            if (Count != 0)
                PrintPreOrderRecursive(Root);

            Console.WriteLine();
        }
        private void PrintPreOrderRecursive(Node root)
        {
            Console.Write(root.Value + " - ");

            if (root.LeftChild != null)
                PrintPreOrderRecursive(root.LeftChild);

            if (root.RightChild != null)
                PrintPreOrderRecursive(root.RightChild);
        }

        public void PrintPreOrderIterative()
        {
            if (Count == 0) return;

            Stack<Node> stack = new Stack<Node>();
            stack.Push(Root);
            while (stack.Count > 0)
            {
                Node tmp = stack.Pop();
                Console.Write(tmp.Value + " - ");

                if (tmp.RightChild != null)
                    stack.Push(tmp.RightChild);

                if (tmp.LeftChild != null)
                    stack.Push(tmp.LeftChild);
            }

            Console.WriteLine();
        }
    }
}
