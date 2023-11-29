public class Codewars
{
    public static void Main(string[] args)
    {
    }

    public record Node<T>
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T data, Node<T> left, Node<T> right)
        {
            Data = data;
            Left = left;
            Right = right;
        }
    }

    public class BinaryTree<T>
    {
        public T[] Nodes { get; set; }
        public bool GenerateNode(T input)
        {
            if (input != null)
            {
                Node<T> node = new(input, default, default);
                return true;
            }
            return false;
        }
    }

}