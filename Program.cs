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
            int size = tree.SizeImperativePreOrderTraversal(root);
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
        public int SizeRecursive(Node root)
        {
            if (root == null)
                return 0;

            return SizeRecursive(root.Left) + SizeRecursive(root.Right) + 1;
        }

        public int SizeImperativePreOrderTraversal(Node root)
        {
            if (root == null)
                return 0;

            int answer = 1;
            Stack<Node> stack = new();
            stack.Push(root);

            while (stack.Count > 0)
            {
                Node currNode = stack.Pop();
                Console.WriteLine(currNode.Data);
                answer++;

                //Even though its a pre-order you should push right node first so that you don't pop it in the next iteration.
                if (currNode.Right != null)
                    stack.Push(currNode.Right);
                if (currNode.Left != null)
                    stack.Push(currNode.Left);
            }

            return answer;
        }
    }
}