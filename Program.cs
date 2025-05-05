namespace Main
{
    using Solution;

    public class Program
    {
        public static void Main()
        {
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

            BinaryTree tree = new(7);
            tree.insert_AVL(new Node(14), tree.Root);
            tree.insert_AVL(new Node(5), tree.Root);
            tree.BFS(tree.Root);
        }
    }
}

namespace Solution
{
    public class Node
    {
        public int Data;
        public int Height;
        public Node? Left;
        public Node? Right;

        public Node(int data)
        {
            Data = data;
        }
    }
    public class BinaryTree
    {
        private readonly Node _root;
        public Node Root;

        public BinaryTree(int data)
        {
            _root = new(data);
            Root = _root;
        }
        public void construct_AVL(Node root)
        {

        }

        public void insert_AVL(Node new_node, Node root, int curr_height = 0)
        {
            if (root.Left == null || root.Right == null)
            {
                if (root.Data > new_node.Data)
                    root.Left = new_node;
                else
                    root.Right = new_node;

                return;
            }

            if (root.Data > new_node.Data)
                insert_AVL(new_node, root.Left);
            else
                insert_AVL(new_node, root.Right);
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