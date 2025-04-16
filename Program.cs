namespace Main
{
    using Solution;

    public class Program
    {
        public static void Main()
        {
            //Node root = new();
            //Node leftMostLeaf = new()
            //{
            //    Data = 7,
            //    InOrderSuccessor = root,
            //};
            //Node rightMostLeaf = new()
            //{
            //    Data = 7,
            //    InOrderSuccessor = root,
            //};
            //Node leftMostLeafPredecessor = new Node
            //{
            //    Data = 11,
            //    Right = rightMostLeaf,
            //    Left = leftMostLeaf
            //};

            //root.Data = 5;
            //root.Left = new Node
            //{
            //    Data = 4,
            //    Left = leftMostLeafPredecessor,
            //};
            //root.Right = new Node
            //{
            //    Data = 8,
            //    Left = new Node { Data = 13 },
            //    Right = new Node
            //    {
            //        Data = 4,
            //        Right = new Node { Data = 1 },
            //    }
            //};
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
            tree.morris_travel(root);
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
        public Node? InOrderSuccessor;
    }

    public class BinaryTree
    {
        public void morris_travel(Node root)
        {
            if (root == null) return;

            Node? curr, prev;
            curr = root;

            while (curr != null)
            {
                if (curr.Left == null)
                {
                    Console.WriteLine(curr.Data);
                    curr = curr.Right;
                }
                else
                {
                    prev = curr.Left;
                    while (prev.Right != null && prev.Right != curr)
                        prev = prev.Right;

                    if (prev.Right == null)
                    {
                        prev.Right = curr;
                        curr = curr.Left;
                    }
                    else
                    {
                        prev.Right = null;
                        Console.WriteLine(curr.Data);
                        curr = curr.Right;
                    }
                }
            }
        }
    }
}