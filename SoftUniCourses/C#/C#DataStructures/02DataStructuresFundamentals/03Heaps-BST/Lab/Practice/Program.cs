using System;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> root = new Node<int>(1,
                new Node<int>(2,
                    new Node<int>(4),
                    new Node<int>(5)),
                new Node<int>(3, new Node<int>(6),
                    new Node<int>(7))
            );

            BT<int> binaryTree = new BT<int>(root);

            Console.WriteLine(binaryTree.PreOrderDfs(root, 0));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(binaryTree.InOrderDfs(root, 0));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(binaryTree.PostOrderDfs(root, 0));

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(binaryTree.PreOrderDfsSum(root));




        }
    }
}
