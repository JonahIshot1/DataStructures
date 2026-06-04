using System.ComponentModel;

namespace ContingSort
{
    internal class Program
    {
        static int[] sort(int[] list)
        {
            int max = 0;
            for(int i =0; i <list.Length;i++)
            {
                if (list[i] > max)
                { max = list[i]; }
            }
            int[] outP = new int[max];
            for(int i =0; i < list.Length;i++)
            {
                outP[list[i]]++;
            }
            for(int i =0; i<list.Length;i++)
            {
                list[i]= outP
            }
            return outP;
        }
        static void Main(string[] args)
        {
            
        }
    }
}
