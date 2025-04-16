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
            Random random = new();
            int sum = random.Next(0, 99);
            Console.WriteLine($"Desired root-path value: {sum}");
            Console.WriteLine(tree.has_path_sum_imperative(root, sum));
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
        #region PrintPostOrder
        //public void print_post_order_recursive(Node root)
        //{
        //    if (root == null) return;

        //    print_post_order_recursive(root.Left);
        //    print_post_order_recursive(root.Right);
        //    Console.WriteLine(root.Data);
        //}
        //public void print_post_order(Node root)
        //{
        //    if (root == null) return;

        //    Stack<Node> stack = new();
        //    stack.Push(root);
        //    root = root.Left;
        //    Node? lastVisitedNode = null;

        //    while (stack.Count > 0)
        //    {
        //        if (root != null)
        //        {
        //            stack.Push(root);
        //            root = root.Left;
        //        }
        //        else
        //        {
        //            Node peekedNode = stack.Peek();

        //            //try to conjure a simple binary tree with 3 nodes
        //            //      2
        //            //     / \
        //            //    1   3
        //            //   / \ / \
        //            //  ---NULL---
        //            //In order to print in this order => 1,3,2, you need to first travel all to way to the left-most leaf
        //            //and stack root nodes with their left child along the way.
        //            //Then you should firs peek the node on top of the stack to check if its a root node by checking its right child,
        //            //if it has a right child set the root to that node and push it on to the stack in the next iteration.
        //            //After pushing it set the root to its left node to see if its also a root node by itself.
        //            //The need for lasVisitedNode variable is to avoid getting stuck on the right child of a root node, if you wouldn't have that
        //            //you'd keep checking the peekedNode's right child(which is available since its a root node) push it on to stack, print and pop it,
        //            //only to push it again in the next iteration because you didn't print the root node just yet; for that we need to check if the lastvisitedNode
        //            //is the right child of the root node.
        //            if (peekedNode.Right != null && lastVisitedNode != peekedNode.Right)
        //                root = peekedNode.Right;
        //            else
        //            {
        //                Console.WriteLine(peekedNode.Data);
        //                lastVisitedNode = stack.Pop();
        //            }

        //        }
        //    }
        //}
        #endregion

        public int has_path_sum_recursive(Node root, int currSum, int desiredSum)
        {
            if (root == null)
                return 0;

            if (root.Left == null && root.Right == null)
                return currSum + root.Data;
            else
            {
                currSum += root.Data;
                int leftBranchSum = has_path_sum_recursive(root.Left, currSum, desiredSum);
                int rightBranchSum = has_path_sum_recursive(root.Right, currSum, desiredSum);
                if (rightBranchSum == desiredSum || leftBranchSum == desiredSum)
                    return desiredSum;
            }

            return 0;
        }


        public bool has_path_sum_imperative(Node root, int sum)
        {
            Stack<(Node, int)> stack = new();

            stack.Push((root, root.Data));
            Node? lastVisitedNode = root;
            root = root.Left;

            while (stack.Count > 0)
            {
                if (root != null)
                {
                    int currPathSum = stack.Peek().Item2 + root.Data;
                    stack.Push((root, currPathSum));
                    root = root.Left;
                }
                else
                {
                    (Node peekedNode, int currPathSum) tuple = stack.Peek();

                    //First condition is to not miss the right child of a node, the second is to avoid getting stuck on the right child
                    if (tuple.peekedNode.Right != null && lastVisitedNode != tuple.peekedNode.Right)
                        root = tuple.peekedNode.Right;
                    else
                    {
                        Console.WriteLine(tuple.peekedNode.Data);
                        //Ensure the peekedNode is a leaf
                        if ((tuple.peekedNode.Left == null && tuple.peekedNode.Right == null) && tuple.currPathSum == sum)
                            return true;
                        lastVisitedNode = stack.Pop().Item1;
                    }
                }
            }

            return false;
        }
    }
}