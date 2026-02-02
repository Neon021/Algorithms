namespace Main
{
    public class Program
    {
        public static void Main()
        {
            //["MyCircularDeque", "insertLast", "insertLast", "insertLast", "insertLast", "deleteFront", "deleteFront", "deleteFront", "insertLast", "insertLast"]
            //[[3], [1], [2], [3], [4], [], [], [], [4], [6]]
            MyCircularDeque myCircularDeque = new MyCircularDeque(3);
            myCircularDeque.InsertLast(1); // return true
            myCircularDeque.InsertLast(2); // return true
            myCircularDeque.InsertLast(3); // return true
            myCircularDeque.InsertLast(4); // return false, the deque is full
            myCircularDeque.DeleteFront();  // return true
            myCircularDeque.DeleteFront();  // return true
            myCircularDeque.DeleteFront();  // return true
            myCircularDeque.InsertLast(4); // return true
            myCircularDeque.InsertLast(6); // return true
        }
        public class Node
        {
            public int Value;
            public Node Next;
            public Node Previous;

            public Node(int val)
            {
                Value = val;
            }
        }

        public class MyCircularDeque
        {
            private Node _first;
            private Node _last;

            private int _length;
            private int _capacity;

            public MyCircularDeque(int k)
            {
                _capacity = k;
                _length = 0;
            }

            public bool InsertFront(int value)
            {
                if (_length == _capacity)
                    return false;

                Node newNode = new Node(value);

                if (_first == null)
                {
                    _first = newNode;
                    _last = _first;
                }
                else
                {
                    _first.Next = newNode;

                    Node tmp = _first;
                    _first = newNode;
                    _first.Previous = tmp;
                }

                _length++;
                return true;
            }

            public bool InsertLast(int value)
            {
                if (_length == _capacity)
                    return false;

                Node newNode = new Node(value);

                if (_last == null)
                {
                    _first = newNode;
                    _last = _first;
                }
                else
                {
                    _last.Previous = newNode;

                    Node tmp = _last;
                    _last = newNode;
                    _last.Next = tmp;
                }

                _length++;
                return true;
            }

            public bool DeleteFront()
            {
                if (_length == 0 || _first == null)
                    return false;

                if (_length == 1)
                {
                    _last = null;
                    _first = null;
                }
                else
                    _first = _first.Previous;

                _length--;
                return true;
            }

            public bool DeleteLast()
            {
                if (_length == 0 || _last == null)
                    return false;

                if (_length == 1)
                {
                    _last = null;
                    _first = null;
                }
                else
                    _last = _last.Next;

                _length--;
                return true;
            }

            public int GetFront()
            {
                if (_length == 0 || _first == null)
                    return -1;

                return _first.Value;
            }

            public int GetRear()
            {
                if (_length == 0 || _last == null)
                    return -1;

                return _last.Value;
            }

            public bool IsEmpty()
            {
                return _length == 0;
            }

            public bool IsFull()
            {
                return _length == _capacity;
            }
        }
    }
}