using static Algorithms;

public class Program
{
    public static void Main()
    {

    }
}
public class Node<T>
{
    public T Data { get; set; }
    public Node<T>? Next { get; internal set; }

    public Node(T data)
    {
        this.Data = data;
    }
}

public class LinkedList<T>
{
    public Node<T>? First { get; private set; }
    public int Count { get; private set; }

    public LinkedList()
    {
        this.First = null;
    }

    public void AddLast(Node<T> node)
    {
        if (First == null)
            First = node;
        else
        {
            Node<T>? curr = First;
            while (curr.Next != null)
            {
                curr = curr.Next;
            }
            curr.Next = node;
        }
        Count++;
    }

    public Node<T>? GetIntersectionNode(Node<T>? otherListHead)
    {
        if (First != null)
        {
            Node<T>? currListHead = First;
            HashSet<Node<T>?> nodes = new();

            while (otherListHead != null)
            {
                nodes.Add(otherListHead);
                otherListHead = otherListHead.Next;
            }

            while (currListHead != null)
            {
                if (nodes.Contains(currListHead))
                    return currListHead;
                currListHead = currListHead.Next;
            }
        }

        return null;
    }
}