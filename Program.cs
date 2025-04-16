namespace Main
{
    using Solution;

    public class Program
    {
        public static void Main()
        {
            Node root = new()
            {
                Data = 5,
                Left = new Node
                {
                    Data = 4,
                    Left = new Node
                    {
                        Data = 11,
                        Right = new Node { Data = 2, },
                        Left = new Node { Data = 7 },
                    },
                },
                Right = new Node
                {
                    Data = 8,
                    Left = new Node { Data = 13 },
                    Right = new Node
                    {
                        Data = 4,
                        Right = new Node { Data = 1 },
                    }
                }
            };

            BinaryTree tree = new();
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
    }
}