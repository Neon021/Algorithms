using System.ComponentModel;

public class Codewars
{
    public static void Main(string[] args)
    {

    }

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; internal set; }

        public Node(T data)
        {
            this.Data = data;
        }
    }
    public class Queue<T>
    {
        public int Length { get; internal set; }
        private Node<T>? Head { get; set; }
        private Node<T>? Tail { get; set; }

        public Queue()
        {
            this.Head = this.Tail = null;
            this.Length = 0;
        }

        public void Enqueue(T data)
        {
            Node<T> node = new(data);
            this.Length++;
            if (this.Tail is null)
            {
                this.Tail = this.Head = node;
                return;
            }

            this.Tail.Next = node;
            this.Tail = node;
        }
        public T? Deque<T>() where T : class
        {
            if (this.Head == null)
            {
                return null;
            }

            this.Length--;

            var head = this.Head;
            this.Head = this.Head.Next;

            // free
            head.Next = null;

            if (this.Length == 0)
            {
                this.Tail = null;
            }

            return head.Data as T;
        }

        public T? Peek<T>() where T : class
        {
            return this.Head is not null ? this.Head.Data as T : null;
        }
    }
}