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
            tree.BFS(root);
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

        public int SizeImperativePostOrderTraversal(Node root)
        {
            if (root == null)
                return 0;

            int answer = 1;
            Stack<Node> stack = new();
            Node? lastNodeVisited = null;

            while (stack.Count > 0 || root != null)
            {
                if (root != null)
                {
                    stack.Push(root);
                    root = root.Left;
                }
                else
                {
                    Node peekNode = stack.Peek();

                    //we check here if a right sub-tree exists when peekNode is the left-most leaf. In which case peekNode.Right != null is true
                    //in the other constraint we avoid getting stuck on a subtree after printing both of its branches and now we'll print itself.
                    if (peekNode.Right != null && lastNodeVisited != peekNode.Right)
                        root = peekNode.Right;
                    else
                    {
                        Console.WriteLine(peekNode.Data);
                        answer++;
                        lastNodeVisited = stack.Pop();
                    }
                }
            }

            return answer;
        }

        public int SizeImperativeInOrderTraversal(Node root)
        {
            if (root == null)
                return 0;

            int answer = 1;
            Stack<Node> stack = new();

            while (stack.Count > 0 || root != null)
            {
                if (root != null)
                {
                    stack.Push(root);
                    root = root.Left;
                }
                else
                {
                    root = stack.Pop();
                    Console.WriteLine(root.Data);
                    answer++;
                    root = root.Right;
                }
            }

            return answer;
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