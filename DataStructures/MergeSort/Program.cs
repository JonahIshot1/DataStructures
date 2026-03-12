namespace MergeSort
{
    internal class Program
    {
        static void MergeSort<T>(T[] items )where T : IComparable<T>
        {
            if (items.Length == 1) { return; }
            T[] a = new T[items.Length/2];
            T[] b = new T[items.Length - a.Length];
            for (int i = 0; i <a.Length; i++)
            {
                a[i] = items[i];
            }
            for (int i = a.Length; i < items.Length; i++)
            {
                b[i - a.Length] = items[i];
            }

            MergeSort(a);
            MergeSort(b);
            Merge(a, b, items);

        }
        static void Merge<T>(T[] a, T[] b, T[] combinedList) where T:IComparable<T>
        {
            int p1 = 0;
            int p2 = 0;
            for (int i = 0; i < a.Length + b.Length; i++)
            {
                if (p1>a.Length-1)
                {
                    combinedList[i] = b[p2];
                    p2++;
                    continue;
                }
                if (p2 > b.Length - 1)
                {
                    combinedList[i] = a[p1];
                    p1++;
                    continue;
                }
                if (a[p1].CompareTo(b[p2]) > 0)
                {
                    combinedList[i] = b[p2];
                    p2++;
                    continue;
                }
                combinedList[i] = a[p1];
                p1++;
            }
        }
        static void Main(string[] args)
        {
            String[] p = { "hacker", "mainframe", "acseess granted", "i love ferrets", "nikia looks like a tortilla" };
            MergeSort(p);
        }
    }
}
