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

    public void RemoveCycleHashing()
    {
        Node<T>? prev = null;
        Node<T>? curr = this.First;
        HashSet<Node<T>> prevNodes = new();

        while (curr != null)
        {
            if (prevNodes.Contains(curr))
            {
                if (prev != null)
                {
                    prev.Next = null;
                }
                return;
            }


            prevNodes.Add(curr);
            prev = curr;
            curr = curr.Next;
        }
    }

    public Node<T>? FindLoop()
    {
        if (First == null)
            return null;

        Node<T>? leftIdx = First, rightIdx = First;

        while (leftIdx != null)
        {
            leftIdx = leftIdx.Next?.Next;
            rightIdx = rightIdx.Next;

            if (leftIdx == rightIdx)
                return rightIdx;
        }

        return null;
    }

    public void RemoveCycleFloydAlgoSlow(Node<T>? slow)
    {
        for (Node<T>? curr = this.First; curr != null; curr = curr.Next)
        {
            Node<T>? ptr = slow;

            //To make sure that ptr points to the first node in the cycle
            //NO THE ABOVE REASON IS NOT THE CASE FOR THIS WHIILE LOOP

            //Instead, it's here to get the "ptr" to the Node whose "Next" is "curr"; which will be the node that starts the cycle
            //In short, to find the node that points to the "curr" node
            //Also the reason for "&&" is to avoid stucking in the while loop
            //since "slow" doesn't guaranteed to point to the first node in the cycle,
            //it might be pointing to a middle node in the cycle.
            //FOR EXAMPLE
            //1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7
            //          ↑-------------------←
            //"curr" would be "1"
            //and "ptr" could be "6".
            //In that case, the first condition of the while will *never* be false
            //so we need to check if we circled back to "slow" pointer.
            //Actually, most of the time the second condition will break the loop;
            //in cases of where the first node is incorporated in the cycle,
            //that's when the first condition will be helpful.

            while (ptr?.Next != curr && ptr?.Next != slow)
                ptr = ptr?.Next;


            //When the "curr" will get to "3" this condiiton will be met
            if (ptr?.Next == curr)
            {
                ptr.Next = null;
                return;
            }
        }
    }

    public void RemoveCycleFloydAlgoFast(Node<T>? slow)
    {
        //FOR EXAMPLE
        //1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7
        //          ↑-------------------←


        //count of nodes in the cycle
        //k = 5
        int k = 1;
        //Condition here is Next not being slow since slow can be any node in the cycle.
        for (Node<T>? ptr = slow; ptr?.Next != slow; ptr = ptr?.Next)
            k++;

        //Get a pointer to the kth node starting from the head
        //curr = 6
        //why do we need the for loop tho? can't we just set curr to slow?
        //Node<T>? curr = slow;
        //Because slow is not guaranteed to be the first node in the cycle.
        Node<T>? curr = First;
        for (int i = 0; i < k; i++)
            curr = curr?.Next;

        Node<T>? head = this.First;
        //Capture the first node of the cycle!
        while (curr != head)
        {
            curr = curr?.Next;
            head = head?.Next;
        }

        //Go to the end node of the cycle.
        //Can we do it "k" times with for loop?
        //while (curr?.Next != head)
        //    curr = curr?.Next;
        for (int i = 1; i <= k; i++)
            curr = curr?.Next;

        if (curr != null)
            curr.Next = null;
    }
    public void PrintList()
    {
        Node<T>? curr = First;
        HashSet<Node<T>> visited = new();
        while (curr != null)
        {
            Console.Write($"{curr.Data} -> ");
            if (visited.Contains(curr))
            {
                Console.WriteLine($"(cycle detected at {curr.Data})");
                break;
            }
            visited.Add(curr);
            curr = curr.Next;
        }

        if (curr == null)
            Console.WriteLine("null");
    }
}