namespace HeepTree
{
    public class Heep<T> where T : IComparable<T>
    {
        public T[] tree;
        public int Count;
        public Heep()
        {
            Count = 0;
            tree = new T[4];
        }
        public void insert(T inP)
        {
            if (tree.Length == Count)
            {
                T[] temp = new T[tree.Length * 2];
                for (int i = 0; i < tree.Length; i++)
                {
                    temp[i] = tree[i];
                }
                tree = temp;
            }

            tree[Count] = inP;
            HeapifyUp(Count);
            Count++;
        }
        int parent(int i)
        {
            return (i - 1) / 2;
        }
        int childR(int i)
        {
            return (2 * i) + 2;
        }
        int childL(int i)
        {
            return (2 * i) + 1;
        }
        void HeapifyUp(int pos)
        {
            if (pos == 0) return;
            int paren = (pos - 1) / 2;
            if (tree[pos].CompareTo(tree[paren]) > 0) return;
            (tree[pos], tree[paren]) = (tree[paren], tree[pos]);
            HeapifyUp(paren);
        }
        public T pop()
        {
            T done = tree[0];
            (tree[0], tree[Count - 1]) = (tree[Count - 1], tree[0]);
            Count--;
            HeapifyDown(0);
            return done;
        }
        void HeapifyDown(int pos)
        {
            if (childL(pos)>=Count )
            {
                return;
            }
            if (childR(pos)>=Count)
            {
                if (tree[childL(pos)].CompareTo(tree[pos])<0)
                {
                    (tree[pos], tree[childL(pos)]) = (tree[childL(pos)], tree[pos]);
                }
                    return;
            }
            if (tree[childR(pos)].CompareTo(tree[childL(pos)]) < 0)
            {
                (tree[pos], tree[childR(pos)]) = (tree[childR(pos)], tree[pos]);
                HeapifyDown(childR(pos));
                return;
            }
            (tree[pos], tree[childL(pos)]) = (tree[childL(pos)], tree[pos]);
            HeapifyDown(childL(pos));
            return;
        }

    }
}
