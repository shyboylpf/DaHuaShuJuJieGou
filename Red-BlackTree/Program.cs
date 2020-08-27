using System;

namespace Red_BlackTree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RedBlackTree<int> redBlackTree = new RedBlackTree<int>();
            Random random = new Random();
            for (int i = 0; i < 10000; i++)
            {
                redBlackTree.Add(random.Next());
            }
            Console.WriteLine(redBlackTree.GetRootValue());
        }
    }
}