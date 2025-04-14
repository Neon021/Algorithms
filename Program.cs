namespace Main
{
    using Solution;

    public class Program
    {
        public static void Main()
        {
            Node root = new()
            {
                Data = 7,
                Left = new Node
                {
                    Data = 23,
                    Left = new Node { Data = 5 },
                    Right = new Node { Data = 4 }
                },
                Right = new Node
                {
                    Data = 3,
                    Left = new Node { Data = 18, Left = new Node { Data = 18, Left = new Node { Data = 18, Left = new Node { Data = 18, Left = new Node { Data = 18 } } } } },
                    Right = new Node { Data = 21 }
                }
            };

            BinaryTree tree = new();
            Console.WriteLine(tree.max_depth_imperative_pre_order(root));
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
        public int max_depth_recursive(Node root)
        {
            if (root == null)
                return 0;

            return Math.Max(max_depth_recursive(root.Left), max_depth_recursive(root.Right)) + 1;
        }

        public int max_depth_imperative_pre_order(Node root)
        {
            if (root == null)
                return -1;

            int answer = 1;
            Stack<(Node, int)> stack = new();
            stack.Push((root, 1));

            while (stack.Count > 0)
            {
                (Node, int) currNode = stack.Pop();

                if (currNode.Item1 != null)
                {
                    answer = Math.Max(answer, currNode.Item2);
                    stack.Push((currNode.Item1.Left, currNode.Item2 + 1));
                    stack.Push((currNode.Item1.Right, currNode.Item2 + 1));
                }
            }

            return answer;
        }
    }
}