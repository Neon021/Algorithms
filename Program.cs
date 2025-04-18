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


        public void in_order_traverse_imperative(Node root, List<int> nodes)
        {
            if (root == null) return;

            Stack<Node> stack = new();
            stack.Push(root);
            root = root.Left;

            while (stack.Count > 0 || root != null)
            {
                if (root != null)
                {
                    stack.Push(root);
                    root = root.Left;
                }
                else
                {
                    Node curr_node = stack.Pop();
                    nodes.Add(curr_node.Data);
                    root = curr_node.Right;
                }
            }
        }

        public Node? build_bst_imperative_queue(List<int> nodes)
        {
            int start = 0;
            int end = nodes.Count - 1;
            int midIndex = (start + end) / 2;
            Node rootNode = new(nodes[midIndex]);

            Queue<(Node parent, int currStart, int currEnd)> queue = new();

            //Push rootNode for left and right subtree
            queue.Enqueue((rootNode, start, midIndex - 1));
            queue.Enqueue((rootNode, midIndex + 1, end));

            while (queue.Count > 0)
            {
                (Node parent, int currStart, int currEnd) = queue.Dequeue();
                if (currStart > currEnd)
                    continue;

                int currMidIndex = (currStart + currEnd) / 2;
                Node currNode = new(nodes[currMidIndex]);

                if (currNode.Data < parent.Data)
                    parent.Left = currNode;
                else
                    parent.Right = currNode;


                // Check if any node remaining in the left subtree of the currNode
                queue.Enqueue((currNode, currStart, currMidIndex - 1));
                // Check if any node remaining in the right subtree of the currNode
                queue.Enqueue((currNode, currMidIndex + 1, currEnd));
            }

            return rootNode;
        }
        public Node? build_bst_imperative_stack(List<int> nodes)
        {
            int start = 0;
            int end = nodes.Count - 1;
            int midIndex = (start + end) / 2;
            Node rootNode = new(nodes[midIndex]);

            Stack<(Node parent, int currStart, int currEnd)> stack = new();

            //Push rootNode for left and right subtree
            stack.Push((rootNode, start, midIndex - 1));
            stack.Push((rootNode, midIndex + 1, end));

            while (stack.Count > 0)
            {
                (Node parent, int currStart, int currEnd) = stack.Pop();
                if (currStart > currEnd)
                    continue;

                int currentMidIndex = (currStart + currEnd) / 2;
                Node currentNode = new(nodes[currentMidIndex]);

                if (currentNode.Data < parent.Data)
                    parent.Left = currentNode;
                else
                    parent.Right = currentNode;


                // Push sub-trees onto the stack (right first to process left earlier)
                stack.Push((currentNode, currentMidIndex + 1, currEnd));
                stack.Push((currentNode, currStart, currentMidIndex - 1));
            }

            return rootNode;
        }

        public Node? build_bst_imperative_with_struct(List<int> nodes)
        {
            int start = 0;
            int end = nodes.Count - 1;
            int midIndex = (start + end) / 2;
            Node rootNode = new(nodes[midIndex]);

            Stack<SortedNode> stack = new();
            //RootNode for left sub-tree
            stack.Push(new SortedNode { parent = rootNode, currStart = start, currEnd = midIndex - 1 });
            //RootNode for right sub-tree
            stack.Push(new SortedNode { parent = rootNode, currStart = midIndex + 1, currEnd = end });

            while (stack.Count > 0)
            {
                SortedNode parentNode = stack.Pop();

                if (parentNode.currStart > parentNode.currEnd) continue;

                int currMidIndex = (parentNode.currStart + parentNode.currEnd) / 2;
                Node childNode = new(nodes[currMidIndex]);

                if (childNode.Data < parentNode.parent.Data)
                    parentNode.parent.Left = childNode;
                else
                    parentNode.parent.Right = childNode;

                //RootNode for left sub-tree
                stack.Push(new SortedNode { parent = childNode, currStart = parentNode.currStart, currEnd = currMidIndex - 1 });
                //RootNode for right sub-tree
                stack.Push(new SortedNode { parent = childNode, currStart = currMidIndex + 1, currEnd = parentNode.currEnd });
            }

            return rootNode;
        }

        //public Node? build_bst_imperative(List<int> nodes)
        //{
        //    int start, end;
        //    start = 0; end = nodes.Count - 1;

        //    int midIndex = (start + end) / 2;
        //    Node rootNode = new(nodes[midIndex]);
        //    Node? leftLastNode = rootNode.Left;
        //    Node? rightLastNode = rootNode.Right;
        //    start++;

        //    while (start <= end)
        //    {
        //        int mid_index = (start + end) / 2;
        //        Node curr_node = new(nodes[mid_index]);
        //        if (rootNode.Data >= curr_node.Data)
        //        {
        //            if (leftLastNode != null)
        //            {
        //                if (leftLastNode!.Data >= curr_node.Data)
        //                    leftLastNode.Left = curr_node;

        //                else
        //                    leftLastNode.Right = curr_node;

        //                leftLastNode = curr_node;
        //            }
        //            else
        //            {
        //                leftLastNode = curr_node;
        //                rootNode.Left = leftLastNode;
        //            }
        //        }
        //        else
        //        {
        //            if (rightLastNode != null)
        //            {
        //                if (rightLastNode!.Data >= curr_node.Data)
        //                    rightLastNode.Left = curr_node;

        //                else
        //                    rightLastNode.Right = curr_node;

        //                rightLastNode = curr_node;
        //            }
        //            else
        //            {
        //                rightLastNode = curr_node;
        //                rootNode.Right = rightLastNode;
        //            }
        //        }

        //        start++;
        //    }

        //    return rootNode;
        //}
        public Node? balance_bst_imperative(Node root)
        {
            List<int> nodes = new();

            in_order_traverse_imperative(root, nodes);

            nodes.Sort();
            return build_bst_imperative_with_struct(nodes);
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

    public struct SortedNode
    {
        public Node parent;
        public int currStart;
        public int currEnd;
    }
}