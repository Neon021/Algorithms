public class Codewars
{
    static void Main(string[] args)
    {
        // Scenario 1: No Intersection
        LinkedList<int> list1 = CreateList(new int[] { 1, 2, 3, 4 });
        LinkedList<int> list2 = CreateList(new int[] { 5, 6, 7 });
        TestIntersection(list1, list2, null);

        // Scenario 2: Intersection at End
        Node<int> sharedNode = new Node<int>(10);
        list1.AddLast(sharedNode);
        list2.AddLast(sharedNode);
        TestIntersection(list1, list2, sharedNode);

        // Scenario 3: Intersection in Middle
        LinkedList<int> list3 = CreateList(new int[] { 1, 2 });
        list3.AddLast(sharedNode);
        TestIntersection(list1, list3, sharedNode);

        // Scenario 4: One Empty List
        LinkedList<int> emptyList = new LinkedList<int>();
        TestIntersection(list1, emptyList, null);
    }

    static LinkedList<int> CreateList(int[] arr)
    {
        LinkedList<int> list = new LinkedList<int>();
        foreach (int val in arr)
        {
            list.AddLast(new Node<int>(val));
        }
        return list;
    }

    static void TestIntersection(LinkedList<int> list1, LinkedList<int> list2, Node<int> expectedIntersection)
    {
        Node<int>? result = list1.IntersectionPointofTwoLinkedLists(list2);
        bool isCorrect = result == expectedIntersection;

        Console.WriteLine(isCorrect
            ? "✓ Intersection point correctly identified"
            : "✗ Incorrect intersection point");
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
        public int Count { get; set; }

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
        public Node<T> LinkedListMiddle()
        {
            Node<T>? leftIdx = First, rightIdx = First;

            while (leftIdx != null)
            {
                leftIdx = leftIdx.Next?.Next;
                if (leftIdx != null)
                    rightIdx = rightIdx.Next;
            }

            return rightIdx;
        }

        public bool FindLoop()
        {
            if (First == null)
                return false;

            Node<T>? leftIdx = First, rightIdx = First;

            while (leftIdx != null)
            {
                leftIdx = leftIdx.Next?.Next;
                rightIdx = rightIdx.Next;

                if (leftIdx == rightIdx)
                    return true;
            }

            return false;
        }

        public void Reverse()
        {
            if (!(First == null || Count == 0))
            {
                Node<T>? prev = null;
                Node<T>? currNode = First;
                //If we hadn't nullable types, we would set this to First.
                Node<T>? nextNode = currNode.Next;

                do
                {
                    currNode.Next = prev;
                    prev = currNode;
                    currNode = nextNode;

                    nextNode = currNode?.Next;
                }
                while (currNode != null);

                First = prev;
            }
        }

        public Node<T>? NthNodeFromEnd(int n)
        {
            if (n <= Count)
            {
                Node<T>? q = First;
                Node<T>? p = First;

                for (int i = 0; i < n; i++)
                {
                    q = q?.Next;
                }

                while (q != null)
                {
                    q = q?.Next;
                    p = p?.Next;
                }

                return p;
            }

            return null;
        }

        public Node<T>? IntersectionPointofTwoLinkedLists(LinkedList<T> otherLinkedList)
        {
            if (otherLinkedList != null && otherLinkedList.First != null && First != null)
            {
                Node<T>? p = First;
                Node<T>? q = otherLinkedList.First;

                if (Count < otherLinkedList.Count)
                {
                    int skipCount = otherLinkedList.Count - Count;
                    while (q != null && skipCount != 0)
                    {
                        q = q?.Next;
                    }
                }
                else if (Count > otherLinkedList.Count)
                {
                    int skipCount = Count - otherLinkedList.Count;
                    while (p != null && skipCount != 0)
                    {
                        p = p?.Next;
                        skipCount--;
                    }
                }


                while (p?.Next != null && q?.Next != null)
                {
                    p = p.Next;
                    q = q.Next;
                    if (p == q)
                        return p;
                }
            }

            return null;
        }
    }
}