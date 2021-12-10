namespace Stacks
{
    class Program
    {
        private static void Main(string[] args)
        {
            Stack stack = new Stack();
            stack.Push(5, 4, 3, 2, 1);
            stack.Print();
            stack.Pop();
            stack.Print();
        }
    }
}