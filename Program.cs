namespace Main
{
    using Solution;

    public class Program
    {
        public static void Main()
        { 
            // Create a test binary tree:
            //        1
            //       / \
            //      2   3
            //     / \
            //    4   5

            Node root = new()
            {
                Data = 1,
                Left = new Node
                {
                    Data = 2,
                    Left = new Node { Data = 4 },
                    Right = new Node { Data = 5 }
                },
                Right = new Node
                {
                    Data = 3
                }
            };

            BinaryTree tree = new();
            int size = tree.Size(root);
            Console.WriteLine("Size of the tree: " + size);
        }
    }
}

namespace Solution
{
    public class Node
    {
        public int Data;
        public Node? Left;
        public Node? Right;
    }

    public class BinaryTree
    {
        public int Size(Node root)
        {
            if (root == null)
                return 0;

            return Size(root.Left) + Size(root.Right) + 1;
        }
    }
}