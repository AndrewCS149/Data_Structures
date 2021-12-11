namespace BinarySearchTrees
{
    class Program
    {
        private static void Main(string[] args)
        {
            BinarySearchTree bst = new BinarySearchTree();
            bst.Insert(5, 3, 6, 2, 4, 7, 0);
            bst.PrintPostOrderRecursive();
            Console.WriteLine(bst.Depth());
        }
    }
}