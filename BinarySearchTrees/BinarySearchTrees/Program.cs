namespace BinarySearchTrees
{
    class Program
    {
        private static void Main(string[] args)
        {
            BinarySearchTree bst = new BinarySearchTree();
            bst.Insert(5, 3, 6, 2, 4);
            bst.PrintInOrderIterative();
        }
    }
}