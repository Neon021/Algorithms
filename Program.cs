public class Codewars
{
    public static void Main(string[] args)
    {
        ArrayList<int> arrayList = new(3);
        arrayList.Push(1);
        arrayList.Push(2);
        arrayList.Push(3);
        arrayList.Push(4);
        arrayList.Push(5);
        arrayList.Push(6);
        arrayList.Enqueue(7);
        arrayList.Dequeue();
        Console.WriteLine(arrayList.Get(0));
        Console.WriteLine(arrayList.Get(1));
        Console.WriteLine(arrayList.Get(2));
        Console.WriteLine(arrayList.Get(3));
        Console.WriteLine(arrayList.Get(4));
        Console.WriteLine(arrayList.Get(5));
        Console.WriteLine(arrayList.Get(6));
    }

    public class ArrayList<T>
    {
        public int Length { get; set; } = 0;
        public int Capacity { get; set; }
        private T[] Array { get; set; }

        public ArrayList(int Capacity)
        {
            this.Capacity = Capacity;
            Array = new T[Capacity];
        }

        //index <= length - 1???
        public T? Get(int index) => (Length > 0) && (index >= 0 && index < Length) ? Array[index] : default(T);

        public void Push(T value)
        {
            if (Length + 1 <= Capacity)
            {
                this.Array[Length] = value;
                Length++;
            }
            else
            {
                T[] newArray = new T[Capacity * 2];
                for (int i = 0; i < this.Length; i++)
                {
                    newArray[i] = this.Array[i];
                }
                Capacity *= 2;
                newArray[Length] = value;
                Length += 1;
                this.Array = newArray;
            }
        }

        public T? Pop() => Length > 0 ? this.Array[Length - 1] : default(T);

        public void Enqueue(T value)
        {
            if (Length + 1 <= Capacity)
            {
                for (int i = Length - 1; i >= 0; i--)
                {
                    this.Array[i + 1] = this.Array[i];
                }
                this.Array[0] = value;
            }
            else
            {
                T[] newArray = new T[Capacity * 2];
                for (int i = Length - 1; i >= 0; i--)
                {
                    newArray[i + 1] = this.Array[i];
                }
                Capacity *= 2;
                newArray[0] = value;
                Length += 1;
                this.Array = newArray;
            }
        }

        public void Dequeue()
        {
            for (int i = 0; i < Length - 1; i++)
            {
                this.Array[i] = this.Array[i + 1];
            }
            Length--;
            this.Array[Length] = default(T);
        }
    }
}