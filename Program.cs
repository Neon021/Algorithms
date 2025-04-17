namespace Main
{
    using Solution;

    public class Program
    {
        public static void Main()
        {
            //Balanced tree
            //Node root = new(5)
            //{
            //    Left = new Node(4)
            //    {
            //        Left = new Node(11)
            //        {
            //            Right = new Node(2),
            //            Left = new Node(7),
            //        },
            //    },
            //    Right = new Node(8)
            //    {
            //        Left = new Node(13),
            //        Right = new Node(4)
            //        {
            //            Right = new Node(1),
            //        }
            //    }
            //};

            //Unbalanced tree
            Node root = new(7)
            {
                Left = new Node(23)
                {
                    Left = new Node(11)
                    {
                        Left = new Node(5),
                        Right = new Node(4),
                    },
                },
                Right = new Node(3)
                {
                    Left = new Node(18),
                    Right = new Node(21)
                    }
            };

            BinaryTree tree = new();
            tree.BFS(tree.balance_bst_imperative(root));
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

        public Node(int data)
        {
            Data = data;
    }
    }
    public class BinaryTree
    {
        public void in_order_traverse_recursive(Node root, List<int> nodes)
        {
            if (root == null) return;

            in_order_traverse_recursive(root.Left, nodes);
            nodes.Add(root.Data);
            in_order_traverse_recursive(root.Right, nodes);
        }

        public Node? build_bst_recursive(List<int> nodes, int start, int end)
        {
            if (start > end) return null;

            int midIndex = (start + end) / 2;
            Node? rootNode = new(nodes[midIndex]);

            rootNode.Left = build_bst_recursive(nodes, start, midIndex - 1);
            rootNode.Right = build_bst_recursive(nodes, midIndex + 1, end);

            return rootNode;
        }

        public Node? balance_bst_recursive(Node root)
        {
            List<int> nodes = new();

            //store the nodes in_order in nodes list
            in_order_traverse_recursive(root, nodes);

            nodes.Sort();
            return build_bst_recursive(nodes, 0, nodes.Count - 1);
        }


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
        public void BFS(Node root)
        {
            if (root == null)
                return;

            //FIFO
            Queue<Node> queue = new();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node currNode = queue.Dequeue();
                Console.WriteLine(currNode.Data);

                if (currNode.Left != null)
                    queue.Enqueue(currNode.Left);
                if (currNode.Right != null)
                    queue.Enqueue(currNode.Right);
            }
        }
    }
}